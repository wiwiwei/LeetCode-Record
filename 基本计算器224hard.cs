/*
    自己第一次解出来hard的题目，纪念一下，整体思路不是很难，但是需要考虑+-负数的情况，所以代码比较冗余，应该可以优化，时间复杂度是o(n),空间使用了两个栈，应该也是o（n）
*/
public class Solution {
    public int Calculate(string s) {
        Stack<char> stack = new Stack<char>();
        foreach(char c in s)
        {
            if(c!=')')
            {
                if(c!=' ')
                {
                    stack.Push(c);
                }
            }
            else
            {
                var newstack = new Stack<char>();
                while(stack.Peek()!='(')
                {
                    var c1 = stack.Pop();
                    if(c1!=' ')
                    {
                        newstack.Push(c1);
                    }
                }
                string str = "";
                while(newstack.Count!=0)
                {
                    str =   str + newstack.Pop();
                }
                stack.Pop();
                foreach(char c1 in Calculate(str).ToString())
                {
                    stack.Push(c1);
                }
            }
        }
        var num = 0;
        string numstr = "";
        while(stack.Count!=0)
        {
            if(stack.Peek()=='+')
            {
                stack.Pop();
                int a = int.Parse(numstr);
                numstr = "";
                num = num+a;
            }
            else if(stack.Peek()=='-')
            {
                stack.Pop();
                if(stack.Count>0&&(stack.Peek()=='+'||stack.Peek()=='-'))
                {
                    if(stack.Peek()=='+')
                    {
                        num = num-int.Parse(numstr);
                    }
                    else
                    {
                        num = num+int.Parse(numstr);
                    }
                    stack.Pop();
                }
                else
                {
                    num = num-int.Parse(numstr);
                }
                numstr = "";
            }
            else
            {
                numstr = stack.Pop() + numstr;
            }
        }
        if(numstr.Length>0)
        {
            num = num+int.Parse(numstr);
        }
        return num;
    }
}