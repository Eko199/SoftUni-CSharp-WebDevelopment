
int[] input = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

int n = input[0], m = input[1];

var resultQueue = new Queue<Node>();
resultQueue.Enqueue(new Node(n, null));

Node? answer = null;

while (resultQueue.Any())
{
    Node currentNode = resultQueue.Dequeue();

    if (currentNode.Value == m)
    {
        answer = currentNode;
        break;
    }

    if (currentNode.Value > m)
    {
        continue;
    }

    resultQueue.Enqueue(new Node(currentNode.Value + 1, currentNode));
    resultQueue.Enqueue(new Node(currentNode.Value + 2, currentNode));
    resultQueue.Enqueue(new Node(currentNode.Value * 2, currentNode));
}

if (answer == null)
{
    Console.WriteLine("(no solution)");
}

var stack = new Stack<int>();

while (answer != null)
{
    stack.Push(answer.Value);
    answer = answer.Previous;
}

Console.WriteLine(string.Join(" -> ", stack));

internal class Node
{
    public Node(int value, Node? previous)
    {
        Value = value;
        Previous = previous;
    }

    public int Value { get; set; }
    public Node? Previous { get; set; }
}