namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmdArgs = args.Split();

            Type commandType = Assembly.GetEntryAssembly()
                .GetTypes()
                .Where(t => typeof(ICommand).IsAssignableFrom(t))
                .SingleOrDefault(c => c.Name == cmdArgs[0] + "Command");

            MethodInfo executeMethod = commandType.GetMethod("Execute");
            
            return (string)executeMethod.Invoke(Activator.CreateInstance(commandType), new object[] { cmdArgs.Skip(1).ToArray() });
        }
    }
}