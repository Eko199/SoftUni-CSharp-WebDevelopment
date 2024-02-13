int start = int.Parse(Console.ReadLine()!);
int end = int.Parse(Console.ReadLine()!);

var thread = new Thread(() =>
{
    for (int i = start; i <= end; i++)
    {
        if (i % 2 == 0)
        {
            Console.WriteLine(i);
        }
    }
});

thread.Start();
thread.Join();

Console.WriteLine("Thread finished work");