string input = Console.ReadLine()!;
var stack = new Stack<int>(input != "" ? input.Split().Select(int.Parse) : Array.Empty<int>());

while (stack.Count > 0)
{
    Console.Write($"{stack.Pop()} ");
}