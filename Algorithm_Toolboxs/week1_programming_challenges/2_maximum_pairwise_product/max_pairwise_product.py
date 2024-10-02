def naive_max_pairwise_product(numbers):
    n = len(numbers)
    max_product = 0
    for first in range(n):
        for second in range(first + 1, n):
            max_product = max(max_product,
                numbers[first] * numbers[second])

    return max_product


def max_pairwise_product(numbers):
    numbers.sort()
    return numbers[-1] * numbers[-2]

def stress_test():
    import random
    while True:
        n = random.randint(2, 10)
        a = [random.randint(0, 1000) for _ in range(n)]
        print(a)
        res1 = naive_max_pairwise_product(a)
        res2 = max_pairwise_product(a)
        if res1 == res2:
            print("OK")
        else:
            print("Wrong answer: ", res1, res2)
            break


if __name__ == '__main__':
    _ = int(input())
    input_numbers = list(map(int, input().split()))
    print(max_pairwise_product(input_numbers))
