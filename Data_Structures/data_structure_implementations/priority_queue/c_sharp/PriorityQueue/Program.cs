
// Default Max PQ
PriorityQueue<int> pq = new(5);

pq.Insert(4);
pq.Insert(1);
pq.Insert(3);
pq.Insert(6);
pq.Insert(2);

Console.WriteLine("Peek: " + pq.Peek());


Console.WriteLine("List: ");
while (!pq.IsEmpty())
{
    Console.WriteLine(pq.Extract());
}

// new Min PQ
PriorityQueue<int> maxPQ = new(5, true);

maxPQ.Insert(3);
maxPQ.Insert(2);
maxPQ.Insert(7);
maxPQ.Insert(5);

Console.WriteLine("Peek: " + maxPQ.Peek());

Console.WriteLine("Remove" + maxPQ.Remove(2));

Console.WriteLine("List: ");
while (!maxPQ.IsEmpty())
{
    Console.WriteLine("After remove: " + maxPQ.Extract());
}

Console.WriteLine("Custome comparer");

// Custom comparer for integers
IComparer<int> customComparer = Comparer<int>.Create((x, y) => x.CompareTo(y));

// Create a PriorityQueue with capacity 5, isMaxHeap true, and custom comparer
PriorityQueue<int> customPQ = new PriorityQueue<int>(5, true, customComparer);

// Insert elements into the PriorityQueue
customPQ.Insert(4);
customPQ.Insert(1);
customPQ.Insert(3);
customPQ.Insert(6);
customPQ.Insert(2);

// Peek the top element
Console.WriteLine("Peek: " + customPQ.Peek());

// Extract elements from the PriorityQueue
Console.WriteLine("List: ");
while (!customPQ.IsEmpty())
{
    Console.WriteLine(customPQ.Extract());
}

// Create a new Min PriorityQueue with custom comparer
PriorityQueue<int> minPQ = new PriorityQueue<int>(5, false, customComparer);

// Insert elements into the Min PriorityQueue
minPQ.Insert(3);
minPQ.Insert(2);
minPQ.Insert(7);
minPQ.Insert(5);

// Peek the top element
Console.WriteLine("Peek: " + minPQ.Peek());

// Remove an element from the Min PriorityQueue
Console.WriteLine("Remove: " + minPQ.Remove(2));

// Extract elements from the Min PriorityQueue
Console.WriteLine("List: ");
while (!minPQ.IsEmpty())
{
    Console.WriteLine("After remove: " + minPQ.Extract());
}