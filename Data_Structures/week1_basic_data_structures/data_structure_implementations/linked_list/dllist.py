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
    
    def erase(self, key):
        if node is None:
            return False
        
        del_node = self.find(key)
        if del_node is None:
            return False
        
        if del_node.prev is not None:
            del_node.prev.next = del_node.next
        else:
            self.head = del_node.next
            
        if del_node.next is not None:
            del_node.next.prev = del_node.prev
        else:
            self.tail = del_node.prev
        self.nodes -= 1
        return True
    
            
    def add_before(self, _node, data):
        if _node is None:
            return False
        
        new_node = node(data, node.prev, node)
        _node.prev = new_node
        
        if new_node.prev is not None:
            new_node.prev.next = new_node
        else:
            self.head = new_node
        self.nodes += 1
        return True
            
    def add_after(self, _node, data):
        if _node is None:
            return False
        
        new_node = node(data, _node, _node.next)
        _node.next = new_node
        
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
    list = dllist()
    print(f"size: {list.size()}")
    list.push_front(1)
    list.push_front(2)
    list.push_front(3)
    list.push_back(4)
    list.push_back(5)
    list.push_back(6)
    print(list)
    print(f"size: {list.size()}")
    print(list.top_front())
    print(list.top_back())
    print(list.pop_front())
    print(list.pop_back())
    print(list)
    print(list.find(3))
    print(list.find(2).data)
    print(list.is_empty())
    print(f"size: {list.size()}")
    
    print(list.erase(3))
    print(list)
    print(list.erase(2))
    print(f"size: {list.size()}")
    list.pop_back()
    list.pop_back()
    print(list.add_before(list.head.next, 7))
    print(list.add_after(list.head, 8))
    print(list.add_after(list.head.next, 8))
    print(list)
    print(f"size: {list.size()}")