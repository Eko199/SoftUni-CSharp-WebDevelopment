namespace _10Chronometer;

public interface IChronometer
{
    string GetTime { get; }

    IList<string> Laps { get; }

    void Start();

    void Stop();

    string Lap();

    void Reset();
}