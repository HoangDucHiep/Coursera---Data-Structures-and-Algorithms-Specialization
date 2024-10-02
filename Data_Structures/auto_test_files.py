import os

def read_file(file_path):
    with open(file_path, 'r') as file:
        return file.read().strip()
    
    
def run_tests():
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