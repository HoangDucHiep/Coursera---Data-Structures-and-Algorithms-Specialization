
class queue:
    def __init__(self):
        self.__container = []
    
    def is_empty(self):
        return len(self.__container) == 0
    
    def size(self):
        return len(self.__container)
    
    def enqueue(self, key):
        self.__container.append(key)

    def dequeue(self):
        return self.__container.pop(0)
        
    def top(self):
        self.__container[0]
        
    def __str__(self):
        return str(self.__container)
    

if __name__ == '__main__':
    que = queue()
    
    que.enqueue(1)
    que.enqueue(2)
    que.enqueue(3)
    
    print(que)
    print(que.size())
    
    print(que.dequeue())
    print(que)
    
    print(que.top())
    print(que)
    