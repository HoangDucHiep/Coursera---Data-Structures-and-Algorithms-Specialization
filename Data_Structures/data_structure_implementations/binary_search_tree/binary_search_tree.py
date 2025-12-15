
class node:
    def __init__(self, data):
        self.data = data
        self.left = None
        self.right = None
        

class binary_search_tree:
    def __init__(self):
        self.root = None
        
    #using loop
    def insert(self, data):
        new_node = node(data)
        
        if (self.root == None):
            self.root = new_node
        else:
            current = self.root
            while True:
                if data < current.data:
                    if current.left == None:
                        current.left = new_node
                        break
                    else:
                        current = current.left
                elif data > current.data:
                    if current.right == None:
                        current.right = new_node
                        break
                    else:
                        current = current.right
                        
    #using recursion
    def insert_recursive(self, data):
        new_node = node(data)
        
        if self.root == None:
            self.root = new_node
        else:
            self.insert_recursive_util(self.root, new_node)
            
    def insert_recursive_util(self, current, new_node):
        if new_node.data < current.data:
            if current.left == None:
                current.left = new_node
            else:
                self.insert_recursive_util(current.left, new_node)
        elif new_node.data > current.data:
            if current.right == None:
                current.right = new_node
            else:
                self.insert_recursive_util(current.right, new_node)
                
    def search(self, data):
        current = self.root
        
        while True:
            if current == None:
                return False
            
            if current.data == data:
                return True
            elif data < current.data:
                current = current.left
            else:
                current = current.right
                
    def delete(self, data):
        self.root = self.delete_util(self.root, data)
        
    def delete_util(self, current, data):
        if current == None:
            return current
        
        if data < current.data:
            current.left = self.delete_util(current.left, data)
        elif data > current.data:
            current.right = self.delete_util(current.right, data)
        else:
            if current.left == None:
                return current.right
            elif current.right == None:
                return current.left
            
            temp = self.min_value_node(current.right)
            current.data = temp.data
            current.right = self.delete_util(current.right, temp.data)
            
        return current
    
    def min_value_node(self, node):
        current = node
        
        while current.left != None:
            current = current.left
            
        return current
    
    def display(self):
        self.display_until(self.root)
        
    def display_until(self, current, depth=0, prefix = ""):
        # Display tree in inorder traversal with hierarchy
        if current is None:
            return
        
        self.display_until(current.left, depth + 1)
        print(' ' * 4 * depth + '|', current.data)
        self.display_until(current.right, depth + 1)
        
    def inorder(self):
        self.inorder_util(self.root)
        print() 
        
    def inorder_util(self, current):
        if current == None:
            return
        
        self.inorder_util(current.left)
        print(current.data, end = " ")
        self.inorder_util(current.right)
            


        
if __name__ == '__main__':
    bst = binary_search_tree()
    bst.insert(10)
    bst.insert(5)
    bst.insert(15)
    bst.insert(3)
    bst.insert(7)
    bst.insert(12)
    bst.insert(18)

    print(bst.search(1))
    print(bst.search(10))
    print(bst.search(18))
    print(bst.search(19))
    
    print("===================")
    bst.inorder()
    bst.delete(15)
    print("===================")
    bst.inorder()
    
    bst.display()