# python3

from collections import namedtuple
import heapq

#heapq will compare the first element of the tuple, so I invert it here to have started_at as the first element
AssignedJob = namedtuple("AssignedJob", ["started_at", "worker"])


def assign_jobs(n_workers, jobs):
    # TODO: replace this code with a faster algorithm.
    result = []
    next_free_time = [0] * n_workers
    
    for i in range(n_workers):
        next_free_time[i] = AssignedJob(0, i)
        
    for job in jobs:
        next_worker = heapq.heappop(next_free_time)
        next_res = AssignedJob(next_worker.started_at, next_worker.worker)
        result.append(next_res)
        next_worker = AssignedJob(next_worker.started_at + job, next_worker.worker)
        heapq.heappush(next_free_time, next_worker)
    
    
    return result


def main():
    n_workers, n_jobs = map(int, input().split())
    jobs = list(map(int, input().split()))
    assert len(jobs) == n_jobs

    assigned_jobs = assign_jobs(n_workers, jobs)

    for job in assigned_jobs:
        print(job.worker, job.started_at)


if __name__ == "__main__":
    main()
