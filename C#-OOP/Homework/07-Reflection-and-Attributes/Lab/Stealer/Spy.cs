namespace Stealer
{
    using System;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldNames)
        {
            var sb = new StringBuilder($"Class under investigation: {className + Environment.NewLine}");
            Type type = Type.GetType(className);

            foreach (string fieldName in fieldNames)
            {
                FieldInfo field = type.GetField(fieldName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                sb.AppendLine($"{field.Name} = {field.GetValue(Activator.CreateInstance(type))}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            var sb = new StringBuilder();
            MemberInfo[] members = Type.GetType(GetType().Namespace + '.' + className).GetMembers((BindingFlags)60);

            foreach (MemberInfo member in members)
            {
                switch (member.MemberType)
                {
                    case MemberTypes.Field:
                        if (!((FieldInfo)member).IsPrivate)
                            sb.AppendLine($"{member.Name} must be private!");
                        break;
                    case MemberTypes.Property:
                        PropertyInfo property = (PropertyInfo)member;
                        if (!property!.GetMethod.IsPublic)
                            sb.AppendLine($"{property.GetMethod.Name} have be public!");
                        if (!property.SetMethod.IsPrivate)
                            sb.AppendLine($"{property.SetMethod.Name} have to be private!");
                        break;
                }
            }

            return sb.ToString().Trim();
            /*
            With methods:
            var sb = new StringBuilder();
            MemberInfo[] members = Type.GetType(GetType().Namespace + '.' + className).GetMembers((BindingFlags)60);

            foreach (MemberInfo member in members)
            {
                switch (member.MemberType)
                {
                    case MemberTypes.Field:
                        if (!((FieldInfo)member).IsPrivate)
                            sb.AppendLine($"{member.Name} must be private!");
                        break;
                    case MemberTypes.Method:
                        MethodInfo method = (MethodInfo)member;
                        if (method.Name.StartsWith("get") && !method.IsPublic)
                            sb.AppendLine($"{member.Name} have be public!");
                        if (method.Name.StartsWith("set") && !method.IsPrivate)
                            sb.AppendLine($"{member.Name} have to be private!");
                        break;
                }
            }

            return sb.ToString().Trim();
            */
        }

        public string RevealPrivateMethods(string className)
        {
            var sb = new StringBuilder($"All Private Methods of Class: {className}{Environment.NewLine}");

            Type type = Type.GetType(className);
            sb.AppendLine($"Base Class: {type.BaseType.Name}");

            foreach (MethodInfo methodInfo in type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic))
            {
                sb.AppendLine(methodInfo.Name);
            }

            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            var sb = new StringBuilder();

            foreach (PropertyInfo property in Type.GetType(className).GetProperties((BindingFlags)60))
            {
                if (property.GetMethod != null)
                    sb.AppendLine($"{property.GetMethod.Name} will return {property.GetMethod.ReturnType}");
                if (property.SetMethod != null)
                    sb.AppendLine($"{property.SetMethod.Name} will set field of {property.PropertyType}");
            }

            return sb.ToString().Trim();
        }
    }
}