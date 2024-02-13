namespace _10Chronometer;

using System.Diagnostics;

public class Chronometer : IChronometer
{
    private readonly Stopwatch stopwatch = new();

    private readonly IList<string> laps = new List<string>();

    public string GetTime => stopwatch.Elapsed.ToString(@"mm\:ss\.ffff");

    public IList<string> Laps => laps.AsReadOnly();

    public void Start() => stopwatch.Start();

    public void Stop() => stopwatch.Stop();

    public string Lap()
    {
        string result = GetTime;
        laps.Add(result);
        return result;
    }

    public void Reset()
    {
        stopwatch.Reset();
        laps.Clear();
    }
}