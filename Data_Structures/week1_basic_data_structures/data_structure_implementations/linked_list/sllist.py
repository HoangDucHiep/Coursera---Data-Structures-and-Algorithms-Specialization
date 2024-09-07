# node for linked-list
class node:
    def __init__(self, data, next=None):
        self.data = data
        self.next = next


# single linked list with tails
# list api:
# list() - create a new list
# list.push_front() - add to front
# list.top_front() - return front element
# list.pop_front() - remove front element
# list.push_back() - add to back
# list.top_back() - return back element
# list.pop_back() - remove back element
# list.find() - is key in list
# list.erase() - remove key from list
# list.is_empty() - is list empty
# list.add_before() - add key before node
# list.add_after() - add key after node
class llist:
    #O(1)
    def __init__(self):
        """Create an empty linked list"""
        self.head = None
        self.tail = None
        self.nodes = 0

    def size(self):
        return self.nodes

    #O(1)
    def push_front(self, data):
        """ Add an element to the front of the list """
        new_node = node(data, self.head)
        self.head = new_node
        if self.tail is None:
            self.tail = new_node
        self.nodes += 1

    #O(1)
    def top_front(self):
        """ Return the front element of the list """
        if self.is_empty():
            return None
        return self.head.data

    #O(1)
    def pop_front(self):
        """ Remove the front element of the list """
        if self.is_empty():
            return None
        data = self.head.data
        self.head = self.head.next
        if self.head is None:
            self.tail = None
        self.nodes -= 1
        return data

    #O(1)
    def push_back(self, data):
        """ Add an element to the back of the list """
        new_node = node(data)
        if self.tail is None:
            self.head = new_node
            self.tail = new_node
        else:
            self.tail.next = new_node
            self.tail = new_node
        self.nodes += 1

    #O(1)
    def top_back(self):
        """ Return the back element of the list """
        if self.tail is None:
            return None
        return self.tail.data

    #O(n)
    def pop_back(self):
        """ Remove the back element of the list """
        if self.is_empty():
            return None
        
        self.nodes -= 1
        if self.head == self.tail:
            data = self.head.data
            self.head = None
            self.tail = None
            return data

        current = self.head
        while current.next != self.tail:
            current = current.next

        data = self.tail.data
        self.tail = current
        self.tail.next = None
        return data
    
    #O(n)
    def find(self, key):
        """ Find a key in the list """
        current = self.head
        while current != None:
            if current.data == key:
                return current
            current = current.next
        return None
    
    #O(n)
    def erase(self, key):
        """ Remove a key from the list """
        if self.is_empty():
            return False

        if self.head.data == key:
            self.pop_front()
            return True

        if self.tail.data == key:
            self.pop_back()
            return True

        current = self.head
        while current.next != None:
            if current.next.data == key:
                current.next = current.next.next
                self.nodes -= 1
                return True
            current = current.next
        return False
    
    #O(1)
    def is_empty(self):
        """is list empty"""
        return self.head == None
    
    #O(n)
    def add_before(self, _node, key):
        """add key before node"""
        if self.is_empty():
            return False
        if self.head == _node:
            self.push_front(key)
            return True
        current = self.head
        while current.next != None and current.next != _node:
            current = current.next
        if current.next == _node and current.next != None:
            new_node = node(key, _node)
            current.next = new_node
            self.nodes += 1
            return True
        else:
            return False
    
    #O(1)
    def add_after(self, node, key):
        """add key after node"""
        if self.is_empty():
            return False

        if self.tail == node:
            self.push_back(key)
            return True

        new_node = node(key, node.next)
        node.next = new_node
        self.nodes += 1
        return True
    
    def __str__(self):
        current = self.head
        result = []
        while current != None:
            result.append(current.data)
            current = current.next
        return " ".join(map(str, result))
    
    def __len__(self):
        return self.nodes
    

#Testing
if __name__ == "__main__":
    list = llist()
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
    print(list.find(2))
    
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