class QueueWithMax():
    def __init__(self):
        self.__queue = []
        self.__max = []

    def Enqueue(self, a):
        self.__queue.append(a)
        self.__max.append(a)
        self.max_process()

    def Dequeue(self):
        assert(len(self.__queue))
        self.__queue.pop(0)
        self.max_process()
        
    def max_process(self):
        while len(self.__max) > 1 and (self.__max[0] <= self.__max[-1] or (self.__queue[0] == self.__max[0])):
            print("Process")
            self.__max.pop(0)

    def Max(self):
        assert(len(self.__queue))
        return self.__max[0]
    
    
queue = QueueWithMax()
queue.Enqueue(2)
queue.Enqueue(7)
print(queue.Max())
queue.Enqueue(3)
queue.Enqueue(1)
print(queue.Max())
queue.Enqueue(5)
queue.Dequeue()
print(queue.Max())

queue.Enqueue(2)
queue.Dequeue()
print(queue.Max())