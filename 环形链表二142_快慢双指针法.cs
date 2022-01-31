/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
 //此法为快慢双指针法，比官方解法稍微好理解一点。
public class Solution {
    public ListNode DetectCycle(ListNode head) {
        if(head==null||head.next==null)
        {
            return null;
        }
        var fast = head;
        var slow = head;
        while(fast!=null)//第一遍循环让快慢指针相交，如果是环形链表，则一定会相交
        {
            slow = slow.next;
            if (fast.next != null) 
            {
                fast = fast.next.next;
            } 
            else 
            {
                return null;
            }
            if(fast==slow)
            {
                break;
            }
        }
        if(fast!=slow||fast==null)//异常情况兼容，fast正好指向空导致退出循环的情况
        {
            return null;
        }
        int n = 0;//记录环的长度
        while(fast!=null)//fast不动，让slow移动，再次相遇时流程则是环的长度
        {
            slow = slow.next;
            n++;
            if(fast==slow)
            {
                break;
            }
        }
        fast = head;
        slow = head;
        for(int i = 0;i<n;i++)//一个指针移动距离n
        {
            fast=fast.next;
        }
        while(fast.next!=null)//两个指针同时向前移动，再次相交的节点则是入环点，因为环长为N，则入口为总长-N，当一个指针移动了n时，此时在移动总长-N正好回到入环点。同时另外一个支持移动总长-N也刚好移动到入环点
        {
            if(fast==slow)
            {
                return fast;
            }
            else
            {
                fast=fast.next;
                slow = slow.next;
            }
        }
        return null;
    }
}