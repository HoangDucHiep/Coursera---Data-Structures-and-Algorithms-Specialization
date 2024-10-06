using System.Collections;
using DataStructures.LinkedList.DoubleLinkedList;

namespace DataStructures.Stack.ListBased
{
    /// <summary>
    /// Represents a stack implemented using a doubly linked list.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the elements in the stack.
    /// </typeparam>
    /// <remarks>
    /// This class represents a stack implemented using a doubly linked list. It contains methods to push, pop, and get the top element of the stack.
    /// </remarks>
    public class Stack<T> : IEnumerable<T>
    {
        private DoubleLinkedList<T> _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="Stack{T}"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor is used to create a stack.
        /// </remarks>
        public Stack()
        {
            _container = new DoubleLinkedList<T>();
        }

        /// <summary>
        /// Pushes an item onto the top of the stack.
        /// </summary>
        /// <param name="item">
        /// The item to push onto the stack.
        /// </param>
        public void Push(T item)
        {
            _container.PushFront(item);
        }

        /// <summary>
        /// Removes and returns the item at the top of the stack.
        /// </summary>
        /// <returns>
        /// The item at the top of the stack.
        /// </returns>
        public T Pop()
        {
            if (_container.IsEmpty())
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            T item = _container.PopFront();
            return item;
        }

        /// <summary>
        /// Returns the item at the top of the stack without removing it.
        /// </summary>
        /// <returns>
        /// The item at the top of the stack.
        /// </returns>
        public T Top()
        {
            if (_container.IsEmpty())
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            return _container.TopFront();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _container)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}