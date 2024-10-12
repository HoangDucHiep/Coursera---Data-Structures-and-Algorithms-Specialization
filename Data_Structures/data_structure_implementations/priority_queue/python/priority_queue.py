class priority_queue:
    def __init__(self, max_size):
        self.max_size = max_size
        self.__size = 0
        self.container = [0] * max_size  # The container uses base-0 indexing

    def size(self):
        return self.__size
    
    def is_empty(self):
        return self.__size == 0

    def insert(self, key):
        if self.__size == self.max_size:
            print("Reached max capacity!!")
            return
            
        self.container[self.__size] = key
        self.sift_up(self.__size)
        self.__size += 1
        
    def extract_max(self):
        if self.__size == 0:
            return None
        
        max_val = self.container[0]
        self.__size -= 1
        self.container[0] = self.container[self.__size]
        self.sift_down(0)
        return max_val
    
    def remove(self, index):
        if index >= self.__size:
            return None
        
        remove_key = self.container[index]
        self.__size -= 1
        
        if index == self.__size:  # If we're removing the last element
            return remove_key
        
        self.container[index] = self.container[self.__size]
        
        # We now compare the new element with its parent and children
        parent_index = (index - 1) // 2
        if index > 0 and self.container[index] > self.container[parent_index]:
            self.sift_up(index)
        else:
            self.sift_down(index)
        
        return remove_key

        
    def get_max(self):
        if self.__size == 0:
            return None
        return self.container[0]
    
    def sift_up(self, i):
        while i > 0 and self.container[(i - 1) // 2] < self.container[i]:
            self.container[(i - 1) // 2], self.container[i] = self.container[i], self.container[(i - 1) // 2]
            i = (i - 1) // 2
            
    def sift_down(self, i):
        while 2 * i + 1 < self.__size:
            left = 2 * i + 1
            right = 2 * i + 2
            max_child = left
            
            if right < self.__size and self.container[right] > self.container[left]:
                max_child = right

            if self.container[i] >= self.container[max_child]:
                break

            self.container[i], self.container[max_child] = self.container[max_child], self.container[i]
            i = max_child
            
    


def heap_sort(arr):
    pq = priority_queue(len(arr))
    for elem in arr:
        pq.insert(elem)
    
    sorted_arr = []
    while not pq.is_empty():
        sorted_arr.append(pq.extract_max())
        
    return sorted_arr


def test():
    pq = priority_queue(5)

    # Test 1: Insert elements
    print("Inserting elements: 3, 5, 9, 1, 6")
    pq.insert(3)
    pq.insert(5)
    pq.insert(9)
    pq.insert(1)
    pq.insert(6)

    print("Expected Max after insertions: 9")
    print("Actual Max:", pq.get_max())  # Expected: 9

    # Test 2: Extract max element
    print("\nExtracting max element")
    extracted_max = pq.extract_max()
    print("Expected Extracted Max: 9")
    print("Actual Extracted Max:", extracted_max)  # Expected: 9

    print("Expected Max after extraction: 6")
    print("Actual Max:", pq.get_max())  # Expected: 6
    
    print(pq.container)

    # Test 3: Remove an element by index
    print("\nRemoving element at index 1 (which should be 3)")
    removed_element = pq.remove(1)
    print("Expected Removed Element: 3")
    print("Actual Removed Element:", removed_element)  # Expected: 3

    print("Expected Max after removal: 6")
    print("Actual Max:", pq.get_max())  # Expected: 6

    # Test 4: Attempt to insert more than max capacity
    print("\nInserting more elements (7, 4) to test max capacity")
    pq.insert(7)
    pq.insert(4)
    print("Expected Max after inserting 7: 7")
    print("Actual Max:", pq.get_max())  # Expected: 7
    
    print("Current size: " + str(pq.size()))
    print("Max size: " + pq.max_size.__str__())

    print("Attempting to insert beyond capacity")
    pq.insert(10)  # Should print "Reached max capacity!!"

    # Test 5: Extract elements until the queue is empty
    print("\nExtracting elements until the queue is empty")
    print("Extracted Max:", pq.extract_max())  # Expected: 7
    print("Extracted Max:", pq.extract_max())  # Expected: 6
    print("Extracted Max:", pq.extract_max())  # Expected: 4
    print("Extracted Max:", pq.extract_max())  # Expected: 3
    print("Extracted Max:", pq.extract_max())  # Expected: 1

    # Test 6: Extract from an empty queue
    print("\nAttempting to extract from an empty queue")
    empty_extract = pq.extract_max()
    print("Expected Result: None")
    print("Actual Result:", empty_extract)  # Expected: None

    # Test 7: Remove from an empty queue
    print("\nAttempting to remove from an empty queue")
    empty_remove = pq.remove(0)
    print("Expected Result: None")
    print("Actual Result:", empty_remove)  # Expected: None



# Testing the PriorityQueue
if __name__ == "__main__":
    arr = [4, 1, 6, 12, 7, 3]
    print(heap_sort(arr))