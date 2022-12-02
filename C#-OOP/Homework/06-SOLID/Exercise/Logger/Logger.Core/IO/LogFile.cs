namespace Logger.Core.IO;

using System.Text;

using Contracts;
using Exceptions;

public class LogFile : ILogFile
{
    private const string DefaultName = "log.txt";
    private const string DefaultPath = "../../../Logs";

    private readonly string? name;
    private readonly string? path;
    private readonly StringBuilder content;

    public LogFile() : this(DefaultName, DefaultPath) { }

    public LogFile(string name, string path)
    {
        content = new StringBuilder();
        Name = name;
        Path = path;
    }

    public string Name
    {
        get => name!;
        private init
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new EmptyFileNameException();

            name = value;
        }
    }

    public string Path
    {
        get => path!;
        private init
        {
            if (!Directory.Exists(value))
                throw new InvalidDirectoryException($"Directory {value} does not exist!");

            path = value;
        }
    }

    public int Size => File.ReadAllText(FileFullPath).Where(char.IsLetter).Sum(c => c);
    private string FileFullPath => System.IO.Path.GetFullPath(Path) + '/' + Name;

    public void Write(string text) => content.Append(text);

    public void SaveContent()
    {
        File.AppendAllText(FileFullPath,
            (string.IsNullOrEmpty(File.ReadAllText(FileFullPath)) ? string.Empty : Environment.NewLine) + content);
        content.Clear();
    }
}