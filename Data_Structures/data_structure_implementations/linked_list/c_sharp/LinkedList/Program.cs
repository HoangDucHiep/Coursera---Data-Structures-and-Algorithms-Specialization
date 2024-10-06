using DataStructures.LinkedList.DoubleLinkedList;
using DataStructures.LinkedList.SingleLinkedList;

DoubleLinkedList<int> list = new DoubleLinkedList<int>();
list.PushFront(5);
Console.WriteLine("Top now is :" + list.TopFront()); // 5
list.PushFront(10);
Console.WriteLine("Top now is :" + list.TopFront()); // 10
Console.WriteLine("Now Pop Front :" + list.PopFront()); // 5
Console.WriteLine("Top now is :" + list.TopFront()); // 10

Console.WriteLine("Now Pop Back :" + list.PopBack()); // 10
Console.WriteLine("Is Empty: " + list.IsEmpty()); // True
//list.PopBack(); // Throws an exception

list.PushBack(15);
list.PushBack(20);
list.PushBack(25);

Console.WriteLine("Contains 20: " + list.Contains(20)); // 25
Console.WriteLine("Remove 20: " + list.Remove(20)); // 20

Console.WriteLine("Contains 20: " + list.Contains(20)); // 25

DoubleLinkedList<IntWrapper> list2 = new DoubleLinkedList<IntWrapper>();
list2.PushFront(new IntWrapper { Value = 5 });
list2.PushFront(new IntWrapper { Value = 10 });
list2.PushFront(new IntWrapper { Value = 15 });

Console.WriteLine("Test traverse method");

list2.Traverse(Console.WriteLine);
list2.Traverse(x => x++);
Console.WriteLine("After incrementing all values by 1");
list2.Traverse(Console.WriteLine);



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



