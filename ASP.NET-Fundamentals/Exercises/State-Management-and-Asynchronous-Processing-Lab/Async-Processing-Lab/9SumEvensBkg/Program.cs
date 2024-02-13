long sum = 0;

Task.Run(() =>
{
    for (int i = 0; i < 2000000000; ++i)
    {
        sum += i;
    }
});

string command;
while ((command = Console.ReadLine()!) != "exit")
{
    if (command == "show")
    {
        Console.WriteLine(sum);
    }
}