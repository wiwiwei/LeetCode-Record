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
 /*
    暴力解法，直接用外部空间存下遍历过的节点，时间复杂度Nlogn。用词典存可以优化为o（n）。
 */
public class Solution {
    public ListNode DetectCycle(ListNode head) {
        if(head==null||head.next==null)
        {
            return null;
        }
        List<ListNode> list = new List<ListNode>();
        while(head!=null)
        {
            if(list.IndexOf(head)!=-1)
            {
                return head;
            }
            list.Add(head);
            head = head.next;
        }
        return null;
    }
}
//如下，时间优化为80ms，O（n）。
public class Solution {
    public ListNode DetectCycle(ListNode head) {
        if(head==null||head.next==null)
        {
            return null;
        }
        Dictionary<ListNode,int> list = new Dictionary<ListNode,int>();
        while(head!=null)
        {
            if(list.ContainsKey(head))
            {
                return head;
            }
            list[head] = head.val;
            head = head.next;
        }
        return null;
    }
}