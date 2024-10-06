
DataStructures.Stack.ListBased.Stack<IntWrapper> stack = new DataStructures.Stack.ListBased.Stack<IntWrapper>();

stack.Push(new IntWrapper { Value = 1 });
stack.Push(new IntWrapper { Value = 2 });
stack.Push(new IntWrapper { Value = 3 });

/* Console.WriteLine(stack.Top());
Console.WriteLine(stack.Pop());
Console.WriteLine(stack.Pop()); */

foreach (var num in stack)
{
    Console.WriteLine(num);
}



public class IntWrapper
{
    public int Value { get; set; }
    
    public static IntWrapper operator ++ (IntWrapper a)
    {
        a.Value++;
        return a;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}



