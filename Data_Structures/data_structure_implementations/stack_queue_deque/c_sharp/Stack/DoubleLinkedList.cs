using System.Collections;

namespace DataStructures.LinkedList.DoubleLinkedList
{
    /// <summary>
    /// Represents a node in a double linked list.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the node.</typeparam>
    /// <remarks>
    /// This class is used to represent a node in a double linked list. It contains a value and references to the next and previous nodes in the list.
    /// </remarks>
    /// <example>
    /// <code>
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T>? Next { get; set; }
        public Node<T>? Previous { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class with the specified value.
        /// </summary>
        /// <param name="value"></param>
        public Node(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class with the specified value, next node, and previous node.
        /// </summary>
        /// <param name="value">The value of the node.</param>
        /// <param name="next">The next node in the list.</param>
        /// <param name="previous">The previous node in the list.</param>
        /// <remarks>
        /// This constructor is used to create a node with the specified value, next node, and previous node.
        /// </remarks>
        public Node(T value, Node<T>? next = null, Node<T>? previous = null)
        {
            Value = value;
            Next = next;
            Previous = previous;
        }
    }

    public class DoubleLinkedList<T> : IEnumerable<T>
    {
        private Node<T>? head;
        private Node<T>? tail;
        public int Size { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleLinkedList"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor is used to create an empty double linked list.
        /// </remarks>
        /// <example>
        /// <code>
        /// DoubleLinkedList list = new DoubleLinkedList();
        /// </code>
        /// </example>
        public DoubleLinkedList()
        {
            head = null;
            tail = null;
            Size = 0;
        }

        /// <summary>
        /// Check if the list is empty.
        /// </summary>
        /// <returns>
        /// Returns true if the list is empty; otherwise, false.
        /// </returns>
        public bool IsEmpty() => Size == 0;

        /// <summary>
        /// Add a new node to the beginning of the list.
        /// </summary>
        /// <param name="value">
        /// The value of the node to add.
        /// </param>
        /// <remarks>
        public void PushFront(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (IsEmpty())
            {
                head = tail = newNode;
                Size++;
                return;
            }

            newNode.Next = head;
            head!.Previous = newNode;
            head = newNode;
            Size++;
        }

        /// <summary>
        /// Get the value of the first node in the list.
        /// </summary>
        /// <returns>
        /// Returns the value of the first node in the list.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the list is empty.
        /// </exception>
        public T TopFront()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The list is empty.");
            }

            return head!.Value;
        }

        /// <summary>
        /// Remove the first node from the list.
        /// </summary>
        /// <returns>
        /// Returns the value of the first node in the list.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the list is empty.
        /// </exception>
        public T PopFront()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The list is empty.");
            }

            T value = head!.Value;
            head = head!.Next;
            if (head != null)
            {
                head.Previous = null;
            }
            else
            {
                tail = null;
            }
            Size--;
            return value;
        }

        /// <summary>
        /// Add a new node to the end of the list.
        /// </summary>
        /// <param name="value">
        /// The value of the node to add.
        /// </param>
        /// <remarks>
        /// This method is used to add a new node with the specified value to the end of the list.
        /// </remarks>
        public void PushBack(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (IsEmpty())
            {
                head = tail = newNode;
                Size++;
                return;
            }

            tail!.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
            Size++;
        }

        /// <summary>
        /// Get the value of the last node in the list.
        /// </summary>
        /// <returns>
        /// Returns the value of the last node in the list.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the list is empty.
        /// </exception>
        /// <remarks>
        /// This method is used to get the value of the last node in the list.
        /// </remarks>
        public T TopBack()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The list is empty.");
            }

            return tail!.Value;
        }

        public T PopBack()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The list is empty.");
            }

            T value = tail!.Value;

            tail = tail!.Previous;
            if (tail == null)
            {
                head = null;
            }
            else
            {
                tail.Next = null;
            }
            Size--;
            return value;
        }

        public bool Contains(T value)
        {
            Node<T>? current = head;
            while (current != null)
            {
                if (current.Value!.Equals(value))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }


        public bool Remove(T value)
        {
            if (IsEmpty())
            {
                return false;
            }

            if (head!.Value!.Equals(value))
            {
                PopFront();
                return true;
            }

            if (tail!.Value!.Equals(value))
            {
                PopBack();
                return true;
            }

            Node<T>? current = head;
            while (current != null)
            {
                if (current.Value!.Equals(value))
                {
                    current.Previous!.Next = current.Next;
                    current.Next!.Previous = current.Previous;
                    current.Next = null;
                    current.Previous = null;
                    Size--;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public bool AddBefore(T value, T after)
        {
            if (IsEmpty())
            {
                return false;
            }

            if (head!.Value!.Equals(after))
            {
                PushFront(value);
                return true;
            }

            Node<T>? current = head;
            while (current != null)
            {
                if (current.Value!.Equals(after))
                {
                    Node<T> newNode = new Node<T>(value, current, current.Previous);
                    current.Previous!.Next = newNode;
                    current.Previous = newNode;
                    Size++;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public bool AddAfter(T value, T before)
        {
            if (IsEmpty())
            {
                return false;
            }

            if (tail!.Value!.Equals(before))
            {
                PushBack(value);
                return true;
            }

            Node<T>? current = head;
            while (current != null)
            {
                if (current.Value!.Equals(before))
                {
                    Node<T> newNode = new Node<T>(value, current.Next, current);
                    current.Next!.Previous = newNode;
                    current.Next = newNode;
                    Size++;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            Size = 0;
        }

        public void Traverse(Action<T> action)
        {
            Node<T>? current = head;
            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // implement iterator soon


    }
}