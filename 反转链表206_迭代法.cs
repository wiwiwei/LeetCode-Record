//参考迭代思路后的解法，优点是不需要试用外部空间，缺点是变慢了一点，比较费解，明明都是O（n），可能是因为C#的关系。
public class Solution {
    public ListNode ReverseList(ListNode head) {
        ListNode pre = null;
        ListNode cur = head;
        while(cur!=null)
        {
            var node = cur.next;
            cur.next = pre;
            pre = cur;
            cur = node;
        }
        return pre;
    }
}