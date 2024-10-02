# python3

from collections import namedtuple

Request = namedtuple("Request", ["arrived_at", "time_to_process"])
Response = namedtuple("Response", ["was_dropped", "started_at"])


class Buffer:
    def __init__(self, size):
        self.size = size
        self.finish_time = []
        
    def is_empty(self):
        return not bool(self.finish_time)
    
    def is_full(self):
        return len(self.finish_time) == self.size
    
    def flush_buffer(self, request):
        if self.is_empty():
            return None
        while self.finish_time:
            if self.finish_time[0] <= request.arrived_at:
                self.finish_time.pop(0)
            else:
                break

    def process(self, request):
        self.flush_buffer(request)
        
        if self.is_full():
            return Response(True, -1)
        
        if self.is_empty():
            self.finish_time.append(request.arrived_at + request.time_to_process)
            return Response(False, request.arrived_at)
        
        response = Response(False, self.finish_time[-1])
        self.finish_time.append(response.started_at + request.time_to_process)
        return response

def process_requests(requests, buffer):
    responses = []
    for request in requests:
        responses.append(buffer.process(request))
    return responses

def parse_response(response):
    str = ""
    for r in response:
        str += f"{r.started_at}\n"
    return str.strip()

import os

def read_file(file_path):
    with open(file_path, 'r') as file:
        return file.read().strip()
    
#test function  
def run_tests():
    #read files in tests folder
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
        
        #testing
        buffer_size, n_requests = map(int, text.split("\n")[0].split())
        
        resquest = []
        for r in text.split("\n")[1:]:
            arrived_at, time_to_process = map(int, r.split())
            resquest.append(Request(arrived_at, time_to_process))
            
        buffer = Buffer(buffer_size)
        responses = process_requests(resquest, buffer)
        
        result = parse_response(responses)
        
        #print result
        if result == expected_result:
            print(f"Test {test_file}: Passed")
        else:
            print(f"Test {test_file}: Failed (Expected: /{expected_result}/, Got: /{result}/)")


def main():
    buffer_size, n_requests = map(int, input().split())
    requests = []
    for _ in range(n_requests):
        arrived_at, time_to_process = map(int, input().split())
        requests.append(Request(arrived_at, time_to_process))

    buffer = Buffer(buffer_size)
    responses = process_requests(requests, buffer)

    for response in responses:
        print(response.started_at if not response.was_dropped else -1)


if __name__ == "__main__":
    #run_tests()
    main()
