namespace DIFramework;

using System.Reflection;

using Attributes;
using Contracts;

public class Injector
{
    private readonly IModule module;

    public Injector(IModule module)
    {
        this.module = module;
    }

    public TClass? Inject<TClass>()
    {
        bool hasConstructorAttribute = CheckForConstructorInjection<TClass>();
        bool hasFieldAttribute = CheckForFieldInjection<TClass>();

        if (hasConstructorAttribute && hasFieldAttribute)
            throw new ArgumentException("There must be only field or constructor annotated with Inject attribute");

        if (hasConstructorAttribute)
            return CreateConstructorInjection<TClass>();

        return hasFieldAttribute ? CreateFieldInjection<TClass>() : default;
    }

    private bool CheckForFieldInjection<TClass>() 
        => typeof(TClass).GetFields((BindingFlags)62).Any(field => field.GetCustomAttributes(typeof(Inject), true).Any());

    private bool CheckForConstructorInjection<TClass>()
        => typeof(TClass).GetConstructors().Any(constructor => constructor.GetCustomAttributes(typeof(Inject), true).Any());

    private TClass? CreateConstructorInjection<TClass>()
    {
        Type desireClass = typeof(TClass);

        foreach (ConstructorInfo constructor in desireClass.GetConstructors())
        {
            var injectAttributes = constructor.GetCustomAttributes(typeof(Inject), true);
            if (!injectAttributes.Any()) continue;

            var inject = (Inject)injectAttributes.First();
            var parameterTypes = constructor.GetParameters();
            var constructorParams = new object?[parameterTypes.Length];

            int i = 0;

            foreach (ParameterInfo parameterType in parameterTypes)
            {
                Attribute? named = parameterType.GetCustomAttribute(typeof(Named));
                Type? dependency = module.GetMapping(parameterType.ParameterType, named ?? inject);

                if (!parameterType.ParameterType.IsAssignableFrom(dependency)) continue;
                object? instance = module.GetInstance(dependency);

                if (instance == null)
                {
                    instance = Activator.CreateInstance(dependency);
                    module.SetInstance(parameterType.ParameterType, instance);
                }

                constructorParams[i++] = instance;
            }

            return (TClass?)Activator.CreateInstance(desireClass, constructorParams);
        }

        return default;
    }

    private TClass? CreateFieldInjection<TClass>()
    {
        Type desireClass = typeof(TClass);
        var desireClassInstance = module.GetInstance(desireClass);

        if (desireClassInstance == null)
        {
            desireClassInstance = Activator.CreateInstance(desireClass);
            module.SetInstance(desireClass, desireClassInstance);
        }

        foreach (FieldInfo field in desireClass.GetFields((BindingFlags)62))
        {
            var injectAttributes = field.GetCustomAttributes(typeof(Inject), true);
            if (!injectAttributes.Any()) continue;

            Type? dependency = module.GetMapping(field.FieldType,
                field.GetCustomAttribute(typeof(Named), true) ?? (Inject)injectAttributes.First());

            if (!field.FieldType.IsAssignableFrom(dependency)) continue;

            object? instance = module.GetInstance(dependency);

            if (instance == null)
            {
                instance = Activator.CreateInstance(dependency);
                module.SetInstance(dependency, instance);
            }

            field.SetValue(desireClassInstance, instance);
        }

        return (TClass?)desireClassInstance;
    }
}