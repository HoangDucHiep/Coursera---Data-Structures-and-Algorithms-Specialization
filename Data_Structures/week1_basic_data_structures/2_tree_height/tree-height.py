# python3

import sys, threading
import os

sys.setrecursionlimit(10**7)  # max depth of recursion
threading.stack_size(2**27)  # new thread will get stack of such size


class TreeHeight:
    def read(self):
        self.n = int(sys.stdin.readline())
        self.parent = list(map(int, sys.stdin.readline().split()))

    def compute_height(self):
        # Replace this code with a faster implementation
        root = self.build_tree()
        # compute height using dfs
        max_height = 0
        stack = [(root, 1)]
        
        while stack:
            current, height = stack.pop()
            max_height = max(max_height, height)
            
            for child in current.children:
                stack.append((child, height + 1))
                
        return max_height


    class Node:
        def __init__(self):
            self.children = []

    def build_tree(self):
        nodes = [TreeHeight.Node() for i in range(self.n)]
        root = None
        for i in range(self.n):
            if self.parent[i] == -1:
                root = nodes[i]
            else:
                nodes[self.parent[i]].children.append(nodes[i])
        return root


def main():
    tree = TreeHeight()
    tree.read()
    print(tree.compute_height())
    tree.draw()


#local test
def read_file(file_path):
    with open(file_path, "r") as file:
        return file.read().strip()

def run_tests():
    folder_path = "tests"
    test_files = [f for f in os.listdir(folder_path) if f.isdigit()]
    for test_file in test_files:
        test_file_path = os.path.join(folder_path, test_file)
        expected_file_path = os.path.join(folder_path, f"{test_file}.a")

        if not os.path.exists(expected_file_path):
            print(f"Expected result file {expected_file_path} not found.")
            continue

        text = read_file(test_file_path)
        expected_result = read_file(expected_file_path)

        # Convert expected result to int if it's a number
        if expected_result.isdigit():
            expected_result = int(expected_result)

        #Running problems
        tree = TreeHeight()
        tree.n = int(text.split("\n")[0])
        tree.parent = list(map(int, text.split("\n")[1].split()))
        
        result = tree.compute_height()

        if result == expected_result:
            print(f"Test {test_file}: Passed")
        else:
            print(
                f"Test {test_file}: Failed (Expected: {expected_result}, Got: {result})"
            )

#change target function to run_tests to test locally
threading.Thread(target=main).start()
