class TreeNode:
    def __init__(self, value):
        self.value = value
        self.children = []

    def add_child(self, child_node):
        self.children.append(child_node)

class Tree:
    def __init__(self, root_value):
        self.root = TreeNode(root_value)

    def find(self, value):
        return self._find_recursive(self.root, value)

    def _find_recursive(self, node, value):
        if node.value == value:
            return node
        for child in node.children:
            result = self._find_recursive(child, value)
            if result:
                return result
        return None

    def traverse(self):
        result = []
        self._traverse_recursive(self.root, result)
        return result

    def _traverse_recursive(self, node, result):
        result.append(node.value)
        for child in node.children:
            self._traverse_recursive(child, result)
        
    def draw(self):
        lines = []
        self._draw_recursive(self.root, "", True, lines)
        return "\n".join(lines)

    def _draw_recursive(self, node, prefix, is_tail, lines):
        lines.append(prefix + ("└── " if is_tail else "├── ") + node.value)
        for i, child in enumerate(node.children):
            self._draw_recursive(child, prefix + ("    " if is_tail else "│   "), i == len(node.children) - 1, lines)

    def preorder_traversal(self):
        result = []
        self._preorder_recursive(self.root, result)
        return result

    def _preorder_recursive(self, node, result):
        result.append(node.value)
        for child in node.children:
            self._preorder_recursive(child, result)

    def inorder_traversal(self):
        result = []
        self._inorder_recursive(self.root, result)
        return result

    def _inorder_recursive(self, node, result):
        if not node.children:
            result.append(node.value)
        else:
            mid = len(node.children) // 2
            for child in node.children[:mid]:
                self._inorder_recursive(child, result)
            result.append(node.value)
            for child in node.children[mid:]:
                self._inorder_recursive(child, result)

    def postorder_traversal(self):
        result = []
        self._postorder_recursive(self.root, result)
        return result

    def _postorder_recursive(self, node, result):
        for child in node.children:
            self._postorder_recursive(child, result)
        result.append(node.value)

# Ví dụ sử dụng
if __name__ == "__main__":
    tree = Tree("root")
    child1 = TreeNode("child1")
    child2 = TreeNode("child2")
    child3 = TreeNode("child3")
    tree.root.add_child(child1)
    tree.root.add_child(child2)
    child1.add_child(TreeNode("child1.1"))
    child1.add_child(TreeNode("child1.2"))
    child1.add_child(TreeNode("child1.3"))
    child2.add_child(TreeNode("child2.1"))
    child3.add_child(TreeNode("child3.1"))
    tree.root.add_child(child3)

    print("Pre-order Traversal:", tree.preorder_traversal())  # Output: ['root', 'child1', 'child1.1', 'child1.2', 'child2', 'child2.1', 'child3', 'child3.1']
    print("In-order Traversal:", tree.inorder_traversal())  # Output: ['child1.1', 'child1', 'child1.2', 'root', 'child2.1', 'child2', 'child3.1', 'child3']
    print("Post-order Traversal:", tree.postorder_traversal())  # Output: ['child1.1', 'child1.2', 'child1', 'child2.1', 'child2', 'child3.1', 'child3', 'root']
    print(tree.draw())