/*
    Implementing Tree in C#
    By: Hoang Hiep
*/

namespace DataStructures.Tree
{

    public class Tree<T>
    {
        public Node<T> Root { get; set; }
        public Tree(Node<T> root)
        {
            Root = root;
        }

        public void AddNode(Node<T> parent, Node<T> node)
        {
            parent.AddChild(node);
        }

        public void RemoveNode(Node<T> parent, Node<T> node)
        {
            parent.RemoveChild(node);
        }

        public int Height(Node<T> node)
        {

            int maxHeight = 0;
            foreach (var child in node.Children)
            {
                int childHeight = Height(child);
                if (childHeight > maxHeight)
                {
                    maxHeight = childHeight;
                }
            }
            return 1 + maxHeight;
        }

        public int Size(Node<T> node)
        {
            int size = 1;
            foreach (var child in node.Children)
            {
                size += Size(child);
            }
            return size;
        }


        public void DepthFirstTraverse(Node<T> node, Action<Node<T>>? action = null)
        {
            action = action ?? (n => Console.WriteLine(n.Data));
            action(node);
            foreach (var child in node.Children)
            {
                DepthFirstTraverse(child, action);
            }
        }

        public void BreadthFirstTraverse(Node<T> node, Action<Node<T>>? action = null)
        {
            action = action ?? (n => Console.WriteLine(n.Data));
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                Node<T> current = queue.Dequeue();
                action(current);
                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }
    }

    public class Node<T>
    {
        public T Data { get; set; }
        public List<Node<T>> Children { get; set; } = new List<Node<T>>();  // used List instead of array to make it easier to add and remove children
        public Node(T data)
        {
            Data = data;
        }

        public void AddChild(Node<T> node)
        {
            Children.Add(node);
        }

        public void RemoveChild(Node<T> node)
        {
            Children.Remove(node);
        }

        public override string ToString()
        {
            return Data?.ToString() ?? string.Empty;
        }
    }
}