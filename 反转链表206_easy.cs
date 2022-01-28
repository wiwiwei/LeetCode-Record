/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
/*本题作为链表中的基础题，AC难度较低（个人拙见）,此解为第一想到的最暴力的解法，
遍历两遍，一遍记录链表，一遍反向创建链表，时间和空间上都不占优势，
且第一次提交没注意判空，第二次提交才通过。后续需要进行优化，好在是没有查看题解自行思考解出，颇为鼓舞。
*/
public class Solution {
    public ListNode ReverseList(ListNode head) {
        if(head==null||head.next==null)
        {
            return head;
        }
        var newHead = new ListNode();
        List<int> vals = new List<int>();
        while(head.next!=null)
        {
            vals.Add(head.val);
            head = head.next;
        }
        if(head!=null)
        {
            newHead = head;
        }
        for(int i = vals.Count-1;i>=0;i--)
        {
            head.next = new ListNode(vals[i],null);
            head = head.next;   
        }
        return newHead;
    }
}
