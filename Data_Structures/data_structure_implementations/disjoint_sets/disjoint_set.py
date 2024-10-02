class disjoint_sets:
    def __init__(self, n):
        self.parent = [i for i in range(0, n + 1)]
        self.rank = [0 for i in range(0, n + 1)]

    """     def find(self, x):
        while x != self.parent[x]:
            x = self.parent[x]
        return x """

    # path compression find
    def find(self, x):
        if x != self.parent[x]:
            self.parent[x] = self.find(self.parent[x])
        return self.parent[x]

    def union(self, x, y):
        x_id = self.find(x)
        y_id = self.find(y)

        if x_id == y_id:
            return

        if self.rank[x_id] > self.rank[y_id]:
            self.parent[y_id] = x_id
        else:
            self.parent[x_id] = y_id
            if self.rank[y_id] == self.rank[x_id]:
                self.rank[y_id] += 1


if __name__ == "__main__":
    ds = disjoint_sets(6)
    ds.union(2, 4)
    ds.union(5, 2)
    print(ds.find(4) == ds.find(3))
    ds.union(3, 1)
    ds.union(2, 3)
    ds.union(2, 6)
