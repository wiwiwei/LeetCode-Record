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
    public bool IsPalindrome(ListNode head) {
        if(head.next==null&&head!=null)return true;
        if(head==null)return false;
        var copyHead = CopyList(head);
        var newhead = ReverseList(copyHead);
        var cur = head;
        while(cur!=null)
        {
            if(cur.val!=newhead.val)return false;
            cur = cur.next;
            newhead=newhead.next;
        }
        return true;
    }
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
    public ListNode CopyList(ListNode head) {
        ListNode cur = head;
        ListNode newhead = new ListNode();
        ListNode pre = new ListNode();
        newhead.next = pre;
        while(cur!=null)
        {
            pre.next = new ListNode(cur.val);
            pre = pre.next;
            cur = cur.next;
        }
        return newhead.next.next;
    }
}