using System.Collections;

namespace DataStructures.Stack.ArrayBased
{

    /// <summary>
    /// Represents a stack implemented using an array.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the elements in the stack.
    /// </typeparam>
    /// <remarks>
    /// This class represents a stack implemented using an array. It contains methods to push, pop, and get the top element of the stack.
    /// </remarks>
    public class Stack<T> : IEnumerable<T>
    {
        private T[] _container;
        private int _top;
        private int _capacity;

        /// <summary>
        /// Initializes a new instance of the <see cref="Stack{T}"/> class with the specified capacity.
        /// </summary>
        /// <param name="capacity">
        /// The initial capacity of the stack. The default value is 1.
        /// </param>
        /// <remarks>
        /// This constructor is used to create a stack with the specified capacity.
        /// </remarks>
        /// <example>
        /// <code>
        /// Stack<int> stack = new Stack<int>(5);
        /// </code>
        /// </example>
        public Stack(int capacity = 1)
        {
            _container = new T[capacity];
            _top = 0;
            _capacity = capacity;
        }
        
        /// <summary>
        /// Resizes the stack to the specified capacity.
        /// </summary>
        /// <param name="newCapacity">
        /// The new capacity of the stack.
        /// </param>
        private void Resize(int newCapacity)
        {
            T[] newContainer = new T[newCapacity];
            Array.Copy(_container, newContainer, _top);
            _container = newContainer;
            _capacity = newCapacity;
        }

        /// <summary>
        /// Pushes an item onto the top of the stack.
        /// </summary>
        /// <param name="item">
        /// The item to push onto the stack.
        /// </param>
        /// <remarks>
        /// This method is used to push an item onto the top of the stack.
        /// </remarks>
        /// <example>
        /// <code>
        /// Stack<int> stack = new Stack<int>();
        /// stack.Push(5);
        /// </code>
        /// </example>
        public void Push(T item)
        {
            if (_top == _capacity)
            {
                Resize(_capacity * 2);
            }

            _container[_top++] = item;
        }

        /// <summary>
        /// Pops the top item from the stack.
        /// </summary>
        /// <returns>
        /// The top item from the stack.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the stack is empty.
        /// </exception>
        /// <remarks>
        /// This method is used to pop the top item from the stack.
        /// </remarks>
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }

            T item = _container[--_top];
            _container[_top] = default(T)!;
            if (_top > 0 && _top == _capacity / 4)
            {
                Resize(_capacity / 2);
            }

            return item;
        }

        /// <summary>
        /// Gets the top item from the stack.
        /// </summary>
        /// <returns>
        /// The top item from the stack.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the stack is empty.
        /// </exception>
        public T Top()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return _container[_top - 1];
        }

        /// <summary>
        /// Checks if the stack is empty.
        /// </summary>
        /// <returns>
        /// Returns true if the stack is empty; otherwise, false.
        /// </returns>
        /// <remarks>
        /// This method is used to check if the stack is empty.
        /// </remarks>
        /// <example>
        /// <code>
        /// Stack<int> stack = new Stack<int>();
        /// Console.WriteLine(stack.IsEmpty()); // True
        /// </code>
        public bool IsEmpty()
        {
            return _top == 0;
        }

        /// <summary>
        /// Gets the number of items in the stack.
        /// </summary>
        /// <returns>
        /// The number of items in the stack.
        /// </returns>
        /// <remarks>
        /// This method is used to get the number of items in the stack.
        /// </remarks>
        public int Size()
        {
            return _top;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < _top; i++)
            {
                if (_container[i]!.Equals(item))    // idont know :)), just use ! to remove the warning, may be bad practice :))
                {
                    return true;
                }
            }
            return false;
        }

        public T[] ToArray()
        {
            T[] array = new T[_top];
            Array.Copy(_container, array, _top);
            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _top - 1; i >= 0; i--)
            {
                yield return _container[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join(" ", ToArray());
        }
    }
}