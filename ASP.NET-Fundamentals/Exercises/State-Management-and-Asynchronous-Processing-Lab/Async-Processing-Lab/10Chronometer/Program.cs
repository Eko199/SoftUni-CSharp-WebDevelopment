using _10Chronometer;

Chronometer chronometer = new();

string command;

while ((command = Console.ReadLine()!) != "exit")
{
    switch (command)
    {
        case "start":
            Task.Run(chronometer.Start);
            break;
        case "stop":
            chronometer.Stop();
            break;
        case "lap":
            Console.WriteLine(chronometer.Lap());
            break;
        case "laps":
            if (chronometer.Laps.Count == 0)
            {
                Console.WriteLine("Laps: no laps");
                break;
            }

            Console.WriteLine("Laps");
            for (var i = 0; i < chronometer.Laps.Count; i++)
            {
                Console.WriteLine($"{i}. {chronometer.Laps[i]}");
            }
            break;
        case "reset":
            chronometer.Reset();
            break;
        case "time":
            Console.WriteLine(chronometer.GetTime);
            break;
    }

    chronometer.Stop();
}