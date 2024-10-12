using System;
using System.Collections.Generic;
public class HelloWorld
{
    public static void Main(string[] args)
    {
        string text = Console.ReadLine();
        FindMismatch(text);
    }


    public static void FindMismatch(string text)
    {
        Stack<IndexedBracket> stack = new Stack<IndexedBracket>();

        for (int i = 0; i < text.Length; i++)  
        {
            char c = text[i];
            if (IndexedBracket.IsOpening(c))
            {
                stack.Push(new IndexedBracket(c, i + 1));
            }
            else if (IndexedBracket.IsClosing(c))
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine(i + 1);
                    return;
                }
                var top = stack.Pop();
                if (!IndexedBracket.AreMatching(top, new IndexedBracket(c, i + 1)))
                {
                    Console.WriteLine(i + 1);
                    return;
                }
            }
        }

        if (stack.Count == 0)
        {
            Console.WriteLine("Success");
        }
        else
        {
            Console.WriteLine(stack.Peek().Index);
        }
    }
}

public class IndexedBracket
{
    public char Bracket { get; set; }
    public int Index { get; set; }

    public IndexedBracket(char bracket, int index)
    {
        Bracket = bracket;
        Index = index;
    }

    public static bool AreMatching(IndexedBracket opening, IndexedBracket closing)
    {
        if (opening.Bracket == '(' && closing.Bracket == ')')
            return true;
        if (opening.Bracket == '[' && closing.Bracket == ']')
            return true;
        if (opening.Bracket == '{' && closing.Bracket == '}')
            return true;
        return false;
    }

    public static bool IsOpening(char bracket)
    {
        return bracket == '(' || bracket == '[' || bracket == '{';
    }

    public static bool IsClosing(char bracket)
    {
        return bracket == ')' || bracket == ']' || bracket == '}';
    }
}