namespace DataStructures.LinkedList.SingleLinkedList
{
    #region Single Linked List Class
    /// <summary>
    /// Class to represent a Single Linked List
    /// </summary>
    /// <typeparam name="T"> Data Type that stored in the list </typeparam>
    /// <example>
    /// <code>
    /// SingleLinkedList<int> list = new SingleLinkedList<int>();
    /// list.Add(5);
    /// list.Add(10);
    /// list.Add(15);
    /// list.Add(20);
    /// list.Remove(10);
    /// list.Print();
    /// </code>
    /// results in a list with 5 -> 15 -> 20
    /// </example>
    /// <remarks>
    /// The list is implemented with a head Node and a tail Node
    /// The head Node is a dummy Node with Value = default(T) and Next = null
    /// The tail Node is a dummy Node with Value = default(T) and Next = null
    /// </remarks>
    /// <seealso cref="Node{T}"/>
    /// <seealso cref="SingleLinkedList{T}.Node"/>
    public class SingleLinkedList<T>
    {
        private Node<T>? Head { get; set; }  // Head Node of the list
        private Node<T>? Tail { get; set; }  // Tail Node of the list
        public int Size { get; private set; }      // Number of Nodes in the list

        public bool IsEmpty() => Size == 0;  // Check if the list is empty

        /// <summary>
        /// Constructor to create a new Single Linked List
        /// Head and Tail are dummy Nodes with Value = default(T) and Next = null
        /// Count is set to 0
        /// </summary>
        /// <example>
        /// <code>
        /// SingleLinkedList<int> list = new SingleLinkedList<int>();
        /// </code>
        /// results in a new Single Linked List with Head = Tail = Node with Value = default(int) and Next = null
        /// </example>
        public SingleLinkedList()
        {
            Head = null;
            Tail = null;
            Size = 0;
        }

        /// <summary>
        /// Add a new element to the beginning of the list
        /// </summary>
        /// <param name="value"> Value to be added to the list </param>
        /// <example>
        /// <code>
        /// SingleLinkedList<int> list = new SingleLinkedList<int>();
        /// list.Add(5);
        /// </code>
        /// results in a list with 5
        /// </example>
        /// <remarks>
        /// The new Node is added to the beginning of the list
        /// </remarks>
        public void PushFront(T value)
        {
            
            Node<T> newNode = new Node<T>(value, Head);     // Create a new Node with the value and next Node point to Head
            Head = newNode;                                 // Head now points to the new Node
            if (Tail == null)                               // If the list is empty at first, we need to set Tail to the new Node
            {
                Tail = Head;
            }                                               // Otherwise, no need to care about Tail
            Size++;                                         // Increase the size of the list
        }

        /// <summary>
        /// Return the first element of the list
        /// </summary>
        /// <returns> The first element of the list </returns>
        /// <example>
        /// <code>
        /// SingleLinkedList<int> list = new SingleLinkedList<int>();
        /// list.Add(5);
        /// int first = list.TopFront();
        /// </code>
        /// results in first = 5
        /// </example>
        /// <exception cref="Exception"> Throws an exception if the list is empty </exception>
        /// <remarks>
        /// The first element is the element at the beginning of the list
        /// </remarks>
        public T TopFront()
        {
            if (Head == null)   //it means that the list is empty, can also check if size == 0
            {
                throw new Exception("The list is empty");
            }
            return Head.Value;
        }

        /// <summary>
        /// Remove the first element of the list
        /// </summary>
        /// <returns> The first element of the list </returns>
        /// <example>
        /// <code>
        /// SingleLinkedList<int> list = new SingleLinkedList<int>();
        /// list.Add(5);
        /// int first = list.PopFront();
        /// </code>
        /// results in first = 5
        /// </example>
        /// <exception cref="Exception"> Throws an exception if the list is empty </exception>
        /// <remarks>
        /// The first element is the element at the beginning of the list
        /// </remarks>
        public T PopFront()
        {
            if (Head == null)  //it means that the list is empty, can also check if size == 0
            {
                throw new Exception("The list is empty");
            }

            T value = Head.Value;   // Get the value of the first element
            
            if (Head == Tail)       // If the list has only one element
            {
                Tail = null;        // Set Tail to null
            }

            Head = Head.Next;       // Head now points to the next element
            Size--;                 // Decrease the size of the list
            return value;           // Return the value of the first element
        }

        /// <summary>
        /// Add a new element to the end of the list
        /// </summary>
        /// <param name="value"> Value to be added to the list </param>
        /// <example>
        /// <code>
        /// SingleLinkedList<int> list = new SingleLinkedList<int>();
        /// list.Add(5);
        /// </code>
        /// results in a list with 5
        /// </example>
        /// <remarks>
        /// The new Node is added to the end of the list
        /// </remarks>
        /// 
        public void PushBack(T value)
        {
            Node<T> newNode = new Node<T>(value, null);  // Create a new Node with the value and next Node point to null
            if (Tail == null)                           // If the list is empty at first, we need to set Head and Tail to the new Node
            {
                Head = newNode;
                Tail = Head;
            }
            else
            {
                Tail.Next = newNode;                    // Otherwise, the next Node of the Tail points to the new Node
                Tail = newNode;                         // Tail now points to the new Node
            }
            Size++;                                     // Increase the size of the list
        }

        /// <summary>
        /// Return the last element of the list
        /// </summary>
        /// <returns> The last element of the list </returns>
        /// <example>
        /// <code>
        /// SingleLinkedList<int> list = new SingleLinkedList<int>();
        /// list.Add(5);
        /// int last = list.TopBack();
        /// </code>
        /// results in last = 5
        /// </example>
        /// <exception cref="Exception"> Throws an exception if the list is empty </exception>
        /// <remarks>
        /// The last element is the element at the end of the list
        /// </remarks>
        public T TopBack()
        {
            if (Tail == null)   //it means that the list is empty, can also check if size == 0
            {
                throw new Exception("The list is empty");
            }
            return Tail.Value;
        }

        /// <summary>
        /// Remove the last element of the list
        /// </summary>
        /// <returns> The last element of the list </returns>
        /// <example>
        /// <code>
        /// SingleLinkedList<int> list = new SingleLinkedList<int>();
        /// list.Add(5);
        /// int last = list.PopBack();
        /// </code>
        /// results in last = 5
        /// </example>
        /// <exception cref="Exception"> Throws an exception if the list is empty </exception>
        /// <remarks>
        /// The last element is the element at the end of the list
        /// </remarks>
        public T PopBack()
        {
            if (Tail == null)   //it means that the list is empty, can also check if size == 0
            {
                throw new Exception("The list is empty");
            }

            T value = Tail.Value;   // Get the value of the last element

            if (Head == Tail)       // If the list has only one element
            {
                Head = null;        // Set Head to null
                Tail = null;        // Set Tail to null
            }
            else
            {
                // Tail now points to the Node before Tail
                Node<T>? current = Head;
                while(current != null && current.Next != Tail)
                {
                    current = current.Next;
                }
                Tail = current;     // Tail now points to the Node before Tail
                Tail!.Next = null;   // The next Node of Tail is set to null
                //by the way, it can't be null so i used ! to tell the compiler that it's not null
            }
            Size--;                         // Decrease the size of the list
            return value;                   // Return the value of the last element
        }

        /// <summary>
        /// Check if the list contains a value
        /// </summary>
        public bool Contains(T value)
        {
            Node<T>? current = Head;    // Start from the beginning of the list
            while (current != null)     // Traverse the list
            {
                if (current.Value!.Equals(value)) // If the value is found
                {
                    return true;                 // Return true
                }
                current = current.Next;          // Move to the next Node
            }
            return false;                        // Return false if the value is not found
        }

        /// <summary>
        /// Remove a value from the list
        /// </summary>
        /// <param name="value"> Value to be removed from the list </param>
        /// <returns> True if the value is removed, False if the value is not found </returns>
        /// <example>
        /// <code>
        /// SingleLinkedList<int> list = new SingleLinkedList<int>();
        /// list.Add(5);
        /// list.Add(10);
        /// list.Add(15);
        /// list.Remove(10);
        /// list.Print();
        /// </code>
        /// results in a list with 5 -> 15
        /// </example>
        /// <remarks>
        /// The first occurrence of the value is removed from the list
        /// </remarks>
        public bool Remove(T value)
        {
            if (Head == null)   //it means that the list is empty, can also check if size == 0
            {
                return false;
            }

            if (Head.Value!.Equals(value))  // If the value is found at the beginning of the list
            {
                PopFront();                 // Remove the first element
                return true;                // Return true
            }

            if (Tail!.Value!.Equals(value))  // If the value is found at the end of the list
            {
                PopBack();                  // Remove the last element
                return true;                // Return true
            }

            Node<T>? current = Head;        // Start from the beginning of the list
            while (current != null && current.Next != null) // Traverse the list
            {
                if (current.Next.Value!.Equals(value)) // If the value is found
                {
                    if (current.Next == Tail)   // If the value is found at the end of the list
                    {
                        Tail = current;         // Tail now points to the Node before the last Node
                    }
                    current.Next = current.Next.Next; // Remove the Node
                    Size--;                           // Decrease the size of the list
                    return true;                      // Return true
                }
                current = current.Next;              // Move to the next Node
            }
            return false;                            // Return false if the value is not found
        }

        public bool AddBefore(T value, T before)
        {
            if (Head == null)   //it means that the list is empty, can also check if size == 0
            {
                return false;
            }

            if (Head.Value!.Equals(before))  // If the value is found at the beginning of the list
            {
                PushFront(value);                 // Add the value to the beginning of the list
                return true;                // Return true
            }

            Node<T>? current = Head;        // Start from the beginning of the list
            while (current != null && current.Next != null) // Traverse the list
            {
                if (current.Next.Value!.Equals(before)) // If the value is found
                {
                    Node<T> newNode = new Node<T>(value, current.Next); // Create a new Node with the value and next Node point to the next Node of the current Node
                    current.Next = newNode; // Add the new Node
                    Size++;                           // Increase the size of the list
                    return true;                      // Return true
                }
                current = current.Next;              // Move to the next Node
            }
            return false;                            // Return false if the value is not found
        }

        /// <summary>
        /// Add a new element after a value in the list
        /// </summary>
        /// <param name="value"> Value to be added to the list </param>
        /// <param name="after"> Value after which the new value is added </param>
        /// <returns> True if the value is added, False if the value is not found </returns>
        /// <example>
        /// <code>
        /// SingleLinkedList<int> list = new SingleLinkedList<int>();
        /// list.Add(5);
        /// list.Add(10);
        /// list.Add(15);
        /// list.AddAfter(12, 10);
        /// list.Print();
        /// </code>
        /// results in a list with 5 -> 10 -> 12 -> 15
        /// </example>
        /// <remarks>
        /// The new Node is added after the first occurrence of the value
        /// </remarks>
        public bool AddAfter(T value, T after)
        {
            if (Head == null)   //it means that the list is empty, can also check if size == 0
            {
                return false;
            }

            if (Tail!.Value!.Equals(after))  // If the value is found at the end of the list
            {
                PushBack(value);                 // Add the value to the end of the list
                return true;                // Return true
            }

            Node<T>? current = Head;        // Start from the beginning of the list
            while (current != null) // Traverse the list
            {
                if (current.Value!.Equals(after)) // If the value is found
                {
                    Node<T> newNode = new Node<T>(value, current.Next); // Create a new Node with the value and next Node point to the next Node of the current Node
                    current.Next = newNode; // Add the new Node
                    Size++;                           // Increase the size of the list
                    return true;                      // Return true
                }
                current = current.Next;              // Move to the next Node
            }
            return false;                            // Return false if the value is not found
        }

        /// <summary>
        /// Traverse the list and perform an action on each value
        /// </summary>
        /// <param name="action"> Action to be performed on each value </param>
        /// <example>
        /// <code>
        /// SingleLinkedList<int> list = new SingleLinkedList<int>();
        /// list.Add(5);
        /// list.Add(10);
        /// list.Add(15);
        /// list.Traverse(Console.WriteLine);
        /// </code>
        /// results in printing 5, 10, 15
        /// </example>
        /// <remarks>
        /// The action is performed on each value in the list
        /// </remarks>
        public void Traverse(Action<T> action)
        {
            Node<T>? current = Head;    // Start from the beginning of the list
            while (current != null)     // Traverse the list
            {
                action(current.Value!); // Perform an action on the value
                current = current.Next; // Move to the next Node
            }
        }


        public void Clear()
        {
            Head = null;    // Set Head to null
            Tail = null;    // Set Tail to null
            Size = 0;       // Set the size to 0
        }

        // implement iterator soon


    }
    #endregion

    #region Create Node Class
    /// <summary>
    /// Class to represent a Single Linked List
    /// </summary>
    /// <typeparam name="T"> Data Type that stored in the list </typeparam>
    public class Node<T>
    {
        public T Value { get; set; }        // Value of the Node 
        public Node<T>? Next { get; set; }   // Reference to the next Node

        /// <summary>
        /// Constructor to create a new Node with a value
        /// Next is set to null
        /// </summary>
        /// <example>
        /// <code>
        /// Node<int> node = new Node<int>(5);
        /// </code>
        /// results in a new Node with Value = 5 and Next = null
        /// </example>
        public Node(T value)
        {
            Value = value;
            Next = null;
        }

        /// <summary>
        /// Constructor to create a new Node with a value and a reference to the next Node
        /// <example>
        /// <code>
        /// Node<int> node = new Node<int>(5, nextNode);
        /// </code>
        /// results in a new Node with Value = 5 and Next = nextNode
        /// </example>
        /// </summary>
        public Node(T value, Node<T>? next)
        {
            Value = value;
            Next = next;
        }
    }
    #endregion
}