from collections import deque

#:)))
class Deque:
    def __init__(self):
        self.deque = deque()

    def add_front(self, item):
        self.deque.appendleft(item)

    def add_rear(self, item):
        self.deque.append(item)

    def remove_front(self):
        if self.is_empty():
            return None
        return self.deque.popleft()

    def remove_rear(self):
        if self.is_empty():
            return None
        return self.deque.pop()

    def is_empty(self):
        return len(self.deque) == 0

    def size(self):
        return len(self.deque)

    def __str__(self):
        return str(list(self.deque))

# Ví dụ sử dụng
if __name__ == "__main__":
    d = Deque()
    d.add_front(1)
    d.add_rear(2)
    d.add_front(3)
    d.add_rear(4)
    print(d)  # Output: [3, 1, 2, 4]
    print(d.size())  # Output: 4
    print(d.remove_front())  # Output: 3
    print(d.remove_rear())  # Output: 4
    print(d)  # Output: [1, 2]
    print(d.size())  # Output: 2