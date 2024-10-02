# python3
#import os

from collections import namedtuple

Bracket = namedtuple("Bracket", ["char", "position"])


def are_matching(left, right):
    return (left + right) in ["()", "[]", "{}"]


def find_mismatch(text):
    opening_brackets_stack = []
    for i, next in enumerate(text):
        if next in "([{":
            # Process opening bracket, write your code here
            opening_brackets_stack.append(Bracket(next, i + 1))

        if next in ")]}":
            # Process closing bracket, write your code here
            if(len(opening_brackets_stack) == 0):
                return i + 1
            
            lastest_opening_bracket = opening_brackets_stack.pop()
            if not are_matching(lastest_opening_bracket.char, next):
                return i + 1
            
    if len(opening_brackets_stack) == 0:
        return "Success"
    else:
        return opening_brackets_stack.pop().position


""" def read_file(file_path):
    with open(file_path, 'r') as file:
        return file.read().strip()
     """
    
""" def run_tests():
    folder_path = 'tests'
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
        
        result = find_mismatch(text)
        
        if result == expected_result:
            print(f"Test {test_file}: Passed")
        else:
            print(f"Test {test_file}: Failed (Expected: {expected_result}, Got: {result})")
             """


def main():
    text = input()
    mismatch = find_mismatch(text)
    # Printing answer, write your code here
    print(mismatch)


if __name__ == "__main__":
    #run_tests()
    main()