namespace DIFramework;

using Attributes;
using Contracts;

public abstract class AbstractModule : IModule
{
    private readonly IDictionary<Type, Dictionary<string, Type>> implementations;
    private readonly IDictionary<Type, object> instances;

    protected AbstractModule()
    {
        implementations = new Dictionary<Type, Dictionary<string, Type>>();
        instances = new Dictionary<Type, object>();
    }

    public abstract void Configure();

    public Type? GetMapping(Type currentInterface, object attribute)
    {
        var currentImplementation = implementations[currentInterface];

        Type? type = attribute switch
        {
            Inject when currentImplementation.Count != 1 
                => throw new ArgumentException("No available mapping for class: " + currentInterface.FullName),
            Inject => currentImplementation.Values.First(),
            Named named => currentImplementation[named.Name],
            _ => null
        };

        return type;
    }

    public object? GetInstance(Type implementation)
    {
        instances.TryGetValue(implementation, out object? value);
        return value;
    }

    public void SetInstance(Type implementation, object? instance)
    {
        if (!instances.ContainsKey(implementation))
        {
            instances.Add(implementation, instance);
        }
    }

    protected void CreateMapping<TInter, TImpl>()
    {
        if (!implementations.ContainsKey(typeof(TInter)))
        {
            implementations[typeof(TInter)] = new Dictionary<string, Type>();
        }

        implementations[typeof(TInter)].Add(typeof(TImpl).Name, typeof(TImpl));
    }
}