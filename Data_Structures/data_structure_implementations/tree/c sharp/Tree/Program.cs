using DataStructures.Tree;

Tree<int> tree = new Tree<int>(new Node<int>(1));
Node<int> root = tree.Root;
Node<int> child1 = new Node<int>(2);
Node<int> child2 = new Node<int>(3);
tree.AddNode(root, child1);
tree.AddNode(root, child2);
Node<int> child3 = new Node<int>(4);
tree.AddNode(child1, child3);

Console.WriteLine("Height: " + tree.Height(root));  // 3
Console.WriteLine("Size: " + tree.Size(root));    // 4


Console.Write("\nBreadth First Traverse:");
tree.BreadthFirstTraverse(root, node => Console.Write(node.Data + " "));  // 1 2 3 4
Console.WriteLine();  // Thêm dòng mới sau khi in Breadth First Traverse
Console.Write("\nDepth First Traverse:");
tree.DepthFirstTraverse(root, node => Console.Write(node.Data + " "));    // 1 2 4 3
Console.WriteLine();  // Thêm dòng mới sau khi in Depth First Traverse