/*
/*
    Implementing Priority Queue in C# using Heap based 0-indexed array
    - Properties
        - Parent = (i - 1) / 2
        - Left Child = 2 * i + 1
        - Right Child = 2 * i + 2
    By: Hoang Hiep
*/

/// <summary>
/// Priority Queue implementation using List<T> and IComparer<T>
/// </summary>
/// <typeparam name="T"></typeparam>
public class PriorityQueue<T> where T : IComparable<T>
{
    private T[] container;
    private int capacity;
    private IComparer<T> comparer;
    private bool isMHeap;
    public int Size { get; private set; }

    public bool IsEmpty() => Size == 0;

    /// <summary>
    /// Constructor for PriorityQueue, default is MaxHeap, and use default comparer
    /// </summary>
    /// <param name="capacity"></param>
    public PriorityQueue(int capacity) : this(capacity, false, Comparer<T>.Default)
    {
        // 
    }

    public PriorityQueue(int capacity, bool isMHeap) : this(capacity, isMHeap, Comparer<T>.Default)
    {
        //
    }

    public PriorityQueue(int capacity, bool isMHeap, IComparer<T> comparer)
    {
        Size = 0;
        this.capacity = capacity;
        container = new T[capacity];
        this.comparer = comparer;
        this.isMHeap = isMHeap;
    }

    public T Peek()
    {
        return container[0];
    }


    public void Insert(T element)
    {
        if (Size == capacity)
        {
            throw new InvalidOperationException("Priority Queue is full");
        }

        // Insert the element at the end of the array
        container[Size] = element;

        // Then sift it up to the correct position
        SiftUp(Size);

        // Increase the size
        Size++;
    }


    public T Extract()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Priority Queue is empty");
        }

        // Get the root element
        T result = container[0];

        // Swap the root element with the last element
        (container[0], container[Size - 1]) = (container[Size - 1], container[0]);
        // Decrease the size
        Size--;
        // Sift down the root element to the correct position
        SiftDown(0);

        // Help Garbage Collector
        if (Size + 1 < capacity)
        {
            container[Size + 1] = default!;
        }

        return result;
    }


    public T Remove(int i)
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Priority Queue is empty");
        }

        if (i >= Size || i < 0)
        {
            throw new IndexOutOfRangeException("Index is out of range");
        }

        // Get the element at index i
        T result = container[i];

        // Swap the element with the last element
        (container[i], container[Size - 1]) = (container[Size - 1], container[i]);
        // Decrease the size
        Size--;

        // Sift the element to the correct position
        SiftDown(i);    // No need to try to SiftUp, because it is already Under the Removed One

        // Help Garbage Collector
        if (Size + 1 < capacity)
        {
            container[Size + 1] = default!;
        }

        return result;
    }

    public T ChangePriority(int i, T newElement)
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Priority Queue is empty");
        }

        if (i >= Size || i < 0)
        {
            throw new IndexOutOfRangeException("Index is out of range");
        }

        // Get the element at index i
        T result = container[i];

        // Change the element at index i    
        container[i] = newElement;

        // Sift the element to the correct position
        SiftDown(i);
        SiftUp(i);

        return result;
    }









    /****  Utilities  ****/
    /// <summary>
    /// Sift up the element at index i to its correct position
    /// </summary>
    /// <param name="i"> index i </param>
    private void SiftUp(int i)
    {
        // for simplification, it just compare the value of parent and child, if if is not in correct order, swap them
        // i use isMHeap to Reverse the comparison if it is MinHeap or MaxHeap :))
        while (i > 0 && (isMHeap ? comparer.Compare(container[Parent(i)], container[i]) > 0 : comparer.Compare(container[Parent(i)], container[i]) < 0))
        {
            // Swap elements
            (container[i], container[Parent(i)]) = (container[Parent(i)], container[i]);

            // Now we move to the parent index
            i = Parent(i);  
        }
        // Then we loop until it is in the correct position
    }

    /// <summary>
    /// Sift down the element at index i to its correct position
    /// </summary>
    /// <param name="i"> index i </param>
    private void SiftDown(int i)
    {
        int mostIndex = i;

        // Compare the left child with the parent
        // First check if it still have left child, then compare the value of left child with the parent
        if ( LeftChild(i) < Size && (isMHeap ? comparer.Compare(container[mostIndex], container[LeftChild(i)]) > 0 : comparer.Compare(container[mostIndex], container[LeftChild(i)]) < 0))
        {
            mostIndex = LeftChild(i);
        }

        // Compare the right child with the parent
        // First check if it still have right child, then compare the value of right child with the most index
        if ( RighChild(i) < Size && (isMHeap ? comparer.Compare(container[mostIndex], container[RighChild(i)]) > 0 : comparer.Compare(container[mostIndex], container[RighChild(i)]) < 0))
        {
            mostIndex = RighChild(i);
        }

        // now if the mostIndex is not i, let's swap them
        if (mostIndex != i)
        {
            (container[i], container[mostIndex]) = (container[mostIndex], container[i]);
            // then we recursively call SiftDown to the mostIndex
            SiftDown(mostIndex);
        }
    }


    private int Parent(int i) => (i - 1) / 2;
    private int LeftChild(int i) => 2*i + 1;
    private int RighChild(int i) => 2*i + 2;

}