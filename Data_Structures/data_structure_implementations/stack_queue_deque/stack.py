class stack:
    def __init__(self):
        self.container = []
        
    def is_empty(self):
        return len(self.container) == 0
    
    def size(self):
        return len(self.container);
    
    def push(self, data):
        self.container.insert(0, data)
    
    def pop(self):
        data = self.top()
        self.container.pop(0)
        return data
        
    def top(self):
        return self.container[-1]
        
    def __str__(self) -> str:
        return str(self.container)
    
    

if __name__ == '__main__':
    st = stack()
    print(st.is_empty())
    st.push(1)
    st.push(2)
    st.push(3)
    
    print(st)
    
    print(st.top())
    print(st)
    
    print(st.pop())
    print(st)
    