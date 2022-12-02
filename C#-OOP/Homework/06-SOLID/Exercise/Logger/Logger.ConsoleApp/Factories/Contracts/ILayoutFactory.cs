namespace Logger.ConsoleApp.Factories.Contracts;

using Logger.Core.Models.Contracts;

public interface ILayoutFactory
{
    ILayout CreateLayout(string type);
}