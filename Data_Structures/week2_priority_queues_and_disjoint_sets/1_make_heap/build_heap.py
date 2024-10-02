# python3

def sift_down(data, i, size, swap):
    """Sift element down the heap until it's in the correct position."""
    while 2*i + 1 < size:
        largest = i
        l = 2*i + 1
        r = 2*i + 2
        
        if l < size and data[l] < data[largest]:
            largest = l
        
        if r < size and data[r] < data[largest]:
            largest = r
            
        if largest != i:
            data[i], data[largest] = data[largest], data[i]
            swap.append((i, largest))
            i = largest
        else:
            break



def build_heap(data):
    """Build a heap from ``data`` inplace.

    Returns a sequence of swaps performed by the algorithm.
    """
    swaps = []
    for i in range(len(data)//2 - 1, -1, -1):
        sift_down(data, i, len(data), swaps)
    return swaps


def main():
    n = int(input())
    data = list(map(int, input().split()))
    assert len(data) == n

    swaps = build_heap(data)

    print(len(swaps))
    for i, j in swaps:
        print(i, j)


if __name__ == "__main__":
    main()
