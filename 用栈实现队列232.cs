public class MyQueue {

    private Stack<int> stack1 = new Stack<int>();
    private Stack<int> stack2 = new Stack<int>();
    public MyQueue() {

    }
    
    public void Push(int x) {
        while(stack2.Count!=0)
        {
            stack1.Push(stack2.Pop());
        }
        stack1.Push(x);
    }
    
    public int Pop() {
        while(stack1.Count!=0)
        {
            stack2.Push(stack1.Pop());
        }
        var ans = stack2.Pop();
        return ans;
    }
    
    public int Peek() {
        while(stack1.Count!=0)
        {
            stack2.Push(stack1.Pop());
        }
        var ans = stack2.Peek();
        return ans;
    }
    
    public bool Empty() {
        return stack1.Count==0&&stack2.Count==0;
    }
}