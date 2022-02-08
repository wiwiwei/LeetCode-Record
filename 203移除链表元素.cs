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
public class Solution {
    public ListNode RemoveElements(ListNode head, int val) {
        if(head==null)return null;
        var ans = new ListNode();
        var pre = ans;
        ans.next = pre;
        var cur = head;
        while(head!=null)
        {
            if(head.val!=val)//不被删除的加在新链表中
            {
                pre.next = head;
                pre = pre.next;
            }
            head = head.next;
            if(head==null&&pre.next!=null)
            {
                pre.next=null;
            }
        }
        return ans.next;
    }
}