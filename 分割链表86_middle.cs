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
 /*
    本题作为链表中的中等难度的题目，实际思路并不难，只需要创建两个哨兵节点分别记录两个Big，small链表的头即可，需要注意的是，遍历一遍后big节点的尾部需要清空，因为其有可能后面还有我们不需要的小于判断值的节点
    有一点比较疑惑的是，如果不清空，LeetCode中会提示out of memory。
 */
public class Solution {
    public ListNode Partition(ListNode head, int x) {
        var preHeadSmall = new ListNode();
        var preHeadBig = new ListNode();
        var curSmall = preHeadSmall;
        var curBig = preHeadBig;
        while(head!=null)
        {
            if(head.val<x)
            {
                curSmall.next = head;
                curSmall = curSmall.next;
            }
            else
            {
                curBig.next = head;
                curBig = curBig.next;
            }
            head = head.next;
        }
        curBig.next = null;
        curSmall.next = preHeadBig.next;
        return preHeadSmall.next;
    }
}