int start = int.Parse(Console.ReadLine()!);

var operationsQueue = new Queue<int>(4);
var result = new int[50];

operationsQueue.Enqueue(start);

for (int i = 0; i < 50; i++)
{
    int current = operationsQueue.Dequeue();

    operationsQueue.Enqueue(current + 1);
    operationsQueue.Enqueue(2 * current + 1);
    operationsQueue.Enqueue(current + 2);

    result[i] = current;
}

Console.WriteLine(string.Join(", ", result));