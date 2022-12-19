namespace SingletonDemo.Models;

using Contracts;

public class SingletonDataContainer : ISingletonContainer
{
    private static SingletonDataContainer? instance;

    private Dictionary<string, int> _capitals = new Dictionary<string, int>();

    private SingletonDataContainer()
    {
        Console.WriteLine("Initializing singleton object");

        var elements = File.ReadAllLines("capitals.txt");
        for (int i = 0; i < elements.Length; i += 2)
        {
            _capitals.Add(elements[i], int.Parse(elements[i + 1]));
        }
    }

    public static SingletonDataContainer Instance => instance ??= new SingletonDataContainer();

    public int GetPopulation(string name) => _capitals[name];
}