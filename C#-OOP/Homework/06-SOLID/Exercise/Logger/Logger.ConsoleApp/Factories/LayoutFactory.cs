namespace Logger.ConsoleApp.Factories;

using Contracts;
using Models;

using Logger.Core.Models;
using Logger.Core.Models.Contracts;

public class LayoutFactory : ILayoutFactory
{
    public ILayout CreateLayout(string type)
        => type switch
        {
            "SimpleLayout" => new SimpleLayout(),
            "XmlLayout" => new XmlLayout(),
            _ => throw new ArgumentException($"{type} is not a valid layout type!")
        };
}