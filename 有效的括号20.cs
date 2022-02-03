public class Solution {
    public bool IsValid(string s) 
    {
        if(s.Length%2==1)return false;
        Dictionary<char,char> dic = new Dictionary<char,char>()
        {
            {'(',')'},{'[',']'},{'{','}'},
        };
        Stack stack = new Stack();
        foreach(char c in s)
        {
            if(stack.Count !=0&&stack.Peek()!=null&&dic.ContainsKey((char)stack.Peek())&&dic[(char)stack.Peek()].Equals(c))
            {
                stack.Pop();
            }
            else
            {
                stack.Push(c);
            }
        }
        if(stack.Count ==0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}