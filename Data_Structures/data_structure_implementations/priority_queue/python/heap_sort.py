def sift_down(arr, i, size):
    while 2*i + 1 < size:
        print("------------------------------")
        print(arr)
        largest = i
        l = 2*i + 1
        r = 2*i + 2
        
        if l < size and arr[l] > arr[i]:
            largest = l
        if r < size and arr[r] > arr[i]:
            largest = r
        
        if largest != i:
            arr[i], arr[largest] = arr[largest], arr[i]
            print(arr)
        else:
            break
        
def build_heap(arr):
    size = len(arr)
    for i in range(len(arr)//2 - 1, -1, -1):
        sift_down(arr, i, size)
        
def heap_sort(arr):
    n = len(arr)
    build_heap(arr)
    print(arr)
    for i in range(n - 1, 0, -1):
        arr[0], arr[i] = arr[i], arr[0]
        sift_down(arr, 0, i)

        
arr = [4, 2, 3, 6, 7, 1, 5]
heap_sort(arr)
print(arr)