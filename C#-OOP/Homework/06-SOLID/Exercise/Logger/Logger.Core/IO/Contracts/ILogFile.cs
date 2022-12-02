namespace Logger.Core.IO.Contracts;

public interface ILogFile
{
    string Name { get; }
    string Path { get; }
    int Size { get; }

    void Write(string text);

    void SaveContent();
}