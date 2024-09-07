# node for linked-list
class node:
    def __init__(self, data, prev = None ,next=None):
        self.data = data
        self.next = next
        self.prev = prev
        


class dllist:
    def __init__(self):
        self.head = None
        self.tail = None
        self.nodes = 0
    
    def is_empty(self):
        return self.head is None
    
    def push_front(self, data):
        new_node = node(data, None, self.head)
        
        if self.head is not None:
            self.head.prev = new_node
            
        self.head = new_node
        
        if self.tail is None:
            self.tail = new_node
            
        self.nodes += 1
            
    def top_front(self):
        if self.is_empty():
            return None
        return self.head.data
    
    def pop_front(self):
        if self.is_empty():
            return None
        data = self.head.data
        self.head = self.head.next
        if self.head is None:
            self.tail = None
        else:
            self.head.prev = None
        self.nodes -= 1    
        return data
        
    def push_back(self, data):
        new_node = node(data, self.tail)
        
        if self.tail is None:
            self.head = new_node
            self.tail = new_node
        else:
            self.tail.next = new_node
            self.tail = new_node
        self.nodes+=1
        
    def top_back(self):
        if self.tail is None:
            return None
        return self.tail.data
    
    def pop_back(self):
        if self.is_empty():
            return None
        
        data = self.tail.data
        
        if self.head == self.tail:
            self.head = self.tail = None
                
        self.tail = self.tail.prev
        self.tail.next = None
        self.nodes -= 1
        return data
    
    def find(self, data):
        current = self.head
        while current is not None:
            if current.data == data:
                return current
            current = current.next
        return None
    
    def erase(self, node):
        if node is None:
            return False
        
        if node.prev is not None:
            node.prev.next = node.next
        else:
            self.head = node.next
            
        if node.next is not None:
            node.next.prev = node.prev
        else:
            self.tail = node.prev
        self.nodes -= 1
        return True
            
    def add_before(self, node, data):
        if node is None:
            return False
        
        new_node = node(data, node.prev, node)
        node.prev = new_node
        
        if new_node.prev is not None:
            new_node.prev.next = new_node
        else:
            self.head = new_node
        self.nodes += 1
        return True
            
    def add_after(self, node, data):
        if node is None:
            return False
        
        new_node = node(data, node, node.next)
        node.next = new_node
        
        if new_node.next is not None:
            new_node.next.prev = new_node
        else:
            self.tail = new_node
        self.nodes += 1
        return True
            
    def __str__(self):
        result = []
        current = self.head
        while current is not None:
            result.append(str(current.data))
            current = current.next
        return ' '.join(result)
    
    def size(self):
        return self.nodes   
    
    def __len__(self):
        return self.size()
    
    
if __name__ == "__main__":
    dll = dllist()
    dll.push_front(1)
    dll.push_front(2)
    dll.push_front(3)
    dll.push_front(4)
    dll.push_front(5)
    print(dll)
    print(dll.size())
    print(dll.top_front())
    print(dll.top_back())
    print(dll.pop_front())
    print(dll.pop_back())
    print(dll)
    print(dll.size())
    print(dll.top_front())
    print(dll.top_back())
    print(dll.pop_front())
    print(dll.pop_back())
    print(dll)
    print(dll.size())
    print(dll.top_front())
    print(dll.top_back())
    print(dll.pop_front())
    print(dll.pop_back())
    print(dll)
    print(dll.size())
    print(dll.top_front())
    print(dll.top_back())
    print(dll.pop_front())
    print(dll.pop_back())
    print(dll)
    print(dll.size())
    print(dll.top_front())
    print(dll.top_back())
    print(dll.pop_front())
    print(dll.pop_back())
    print(dll)
    print(dll.size())
    print(dll.top_front())
    print(dll.top_back())
    print(dll.pop_front())
    print(dll.pop_back())
    print(dll)
    print(dll.size())
    print(dll.top_front())
    print(dll.top_back())
    print(dll.pop_front())
    print(dll.pop_back())
    print(dll)
    print(dll.size())
    print(dll.top_front())
    print(dll.top_back())
    print(dll.pop_front())
    print(dll.pop_back())
    print(dll)
    print(dll.size())
    print(dll.top_front())
    print(dll.top_back())
    print(dll.pop_front())
    print(dll.pop_back())
    print(dll)
    print(dll.size())
    print(dll.top_front())
    print(dll.top_back())
    print(dll.pop_front())
    print(dll.pop_back())
    print(dll)
    print(dll.size())
    print(dll.top_front())
    print(dll.top_back())
    print(dll.pop_front())
    print(dll.pop_back())
    print(dll)
    print(dll.size())
    print(dll.top_front())
    print(dll.top_back())