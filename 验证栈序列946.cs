public class Solution {
    private void StackContainsValue(ref Stack<int> stack,ref List<int> poplist)//递归判断栈顶是否和出站序列中的数字对上，如果对上需要出栈
    {
        if(stack.Count!=0 && poplist[0]==stack.Peek())
        {
            stack.Pop();
            poplist.Remove(poplist[0]);//匹配上需要从出栈序列中移除
        }
        if(stack.Count!=0 && poplist[0]==stack.Peek())
        {
            StackContainsValue(ref stack,ref poplist);
        }
    }
    public bool ValidateStackSequences(int[] pushed, int[] popped) {
        Stack<int> stack = new Stack<int>();
        var poplist = popped.ToList();
        foreach(var pushValue in pushed)//按照进栈序列进栈，如果遇到和出栈序列相同的，则代表直接出栈就行
        {
            StackContainsValue(ref stack,ref poplist);//递归判断栈顶是否和出站序列中的数字对上，如果对上需要出栈
            if(pushValue!=poplist[0])//正常进栈
            {
                stack.Push(pushValue);
            }
            else//遇到和出栈序列相同的，则代表直接出栈就行。因为此处没入栈，所以不需要对栈进行操作
            {
                poplist.Remove(pushValue);//匹配上需要从出栈序列中移除
            }
        }
        while(stack.Count!=0)//遍历一遍后，如果栈没空，则代表此时全出栈的顺序就应该是出栈序列的顺序
        {
            if(stack.Pop()!=poplist[0])//如果匹配不上直接返回false
            {
                return false;
            }
            else
            {
                poplist.Remove(poplist[0]);//匹配上需要从出栈序列中移除
            }
        }
        return true;//遍历完全部匹配，代表序列通过验证
    }
}