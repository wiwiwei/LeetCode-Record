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
    迭代法如下，主要思想为弄一个PreHead空节点记录头结点，便于返回拼接后的链表
 */
public class Solution {
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        var curA = list1;
        var curB = list2;
        ListNode preHead = new ListNode();
        var c = preHead;
        while(curA!=null||curB!=null)
        {
            if(curA==null)
            {
                c.next = curB;
                c = c.next;
                curB = curB.next;
            }
            else if(curB==null)
            {
                c.next = curA;
                c = c.next;
                curA = curA.next;
            }
            else if(curA.val<=curB.val)
            {
                c.next = curA;
                c = c.next;
                curA = curA.next;
            }
            else
            {
                c.next = curB;
                c = c.next;
                curB = curB.next;
            }
        }
        return preHead.next;
    }
    void AddNode(ListNode list1, ListNode list2)
    {
        list1.next = list2;
        list1 = list1.next;
        list2 = list2.next;
    }
}


/**
 * 精简后如下，神奇的是不加ref在LeetCode中会超时，而且用方法包一下会导致时间增加8s，迭代法时间复杂度为m+n
 */
public class Solution {
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        var curA = list1;
        var curB = list2;
        ListNode preHead = new ListNode();
        var c = preHead;
        while(curA!=null||curB!=null)
        {
            if(curA==null)
            {
                AddNode(ref c, ref curB);
            }
            else if(curB==null)
            {
                AddNode(ref c,ref curA);
            }
            else if(curA.val<=curB.val)
            {
                AddNode(ref c,ref curA);
            }
            else
            {
                AddNode(ref c, ref curB);
            }
        }
        return preHead.next;
    }
    void AddNode(ref ListNode list1,ref ListNode list2)
    {
        list1.next = list2;
        list1 = list1.next;
        list2 = list2.next;
    }
}