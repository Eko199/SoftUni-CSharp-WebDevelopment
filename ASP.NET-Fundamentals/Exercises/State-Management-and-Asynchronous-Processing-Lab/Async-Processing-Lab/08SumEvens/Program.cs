while (true)
{
    string command = Console.ReadLine()!;

    if (command == "show")
    {
        Console.WriteLine(Task.Run(() =>
        {
            long sum = 0;

            for (int i = 1; i < 10000; ++i)
            {
                if (i % 2 == 0)
                {
                    sum += i;
                }
            }

            return sum;
        }).Result);
    }
}