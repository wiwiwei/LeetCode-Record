public class MinStack {
    private Stack<int> stack = new Stack<int>();
    private List<int> list = new List<int>();
    public MinStack() {
    }
    
    public void Push(int val) {
        stack.Push(val);
        list.Add(val);
    }
    
    public void Pop() {
        var a = stack.Pop();
        list.Remove(a);
    }
    
    public int Top() {
        return stack.Peek();
    }
    
    public int GetMin() {
        int min = (int)stack.Peek();
        foreach(var num in list)
        {
            if(num<min)
            {
                min = num;
            }
        }
        return min;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */