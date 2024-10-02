# python3

from collections import deque

class QueueWithMax():
    def __init__(self):
        self.__queue = []
        self.__max = deque()

    def Enqueue(self, a):
        self.__queue.append(a)
        while self.__max and self.__max[-1] < a:
            self.__max.pop()
        self.__max.append(a)

    def Dequeue(self):
        assert(len(self.__queue))
        if self.__queue[0] == self.__max[0]:
            self.__max.popleft()
        self.__queue.pop(0)
        
    def Max(self):
        assert(len(self.__queue))
        return self.__max[0]

def max_sliding_window_naive(sequence, m):
    maximums = []
    for i in range(len(sequence) - m + 1):
        maximums.append(max(sequence[i:i + m]))

    return maximums

def max_sliding_window(sequence, m):
    maximus = []
    queue = QueueWithMax()
    
    for i in range(m):
        queue.Enqueue(sequence[i])
        
    maximus.append(queue.Max())
    
    for num in sequence[m:]:
        queue.Dequeue()
        queue.Enqueue(num)
        maximus.append(queue.Max())
        
    return maximus


if __name__ == '__main__':
    n = int(input())
    input_sequence = [int(i) for i in input().split()]
    assert len(input_sequence) == n
    window_size = int(input())

    print(*max_sliding_window(input_sequence, window_size))

