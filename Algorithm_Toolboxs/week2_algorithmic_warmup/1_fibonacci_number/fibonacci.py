def recursive_fibonacci_number(n):
    if n <= 1:
        return n
    return recursive_fibonacci_number(n - 1) + recursive_fibonacci_number(n - 2)


def fibonacci_number(n):
    fib_nums = [0, 1, 1];
    for i in range(3, n + 1):
        fib_nums.append(fib_nums[i - 1] + fib_nums[i - 2])
    return fib_nums[n]




if __name__ == '__main__':
    input_n = int(input())
    print(recursive_fibonacci_number(input_n))