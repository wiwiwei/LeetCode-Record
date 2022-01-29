/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
 /*
 本解法为进阶解法，时间复杂度为M+N，只需要每个指针遍历两根链表各一遍即可。
 个人认为主要思想为对齐，第一遍主要是为了弥补两根链表长度的不同，第二遍对齐后则可以同时指向相同节点。
 对比网上解法，先移动指针再判空存在如果没有交点则会无限循环的问题，于是自己加了个flag判断。
 */
public class Solution
{
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        if (headA == headB && headA.next == headB.next)
            return headA;
        if(headA == null || headB == null)
            return null;
        var curA = headA;
        var curB = headB;
        bool flag = false;
        while (curA != curB)
        {
            curA = curA.next;
            if(curA==null)
            {
                if(!flag)
                {
                    curA = headB;
                    flag =true;
                }
                else
                {
                    return null;
                }
                
            }
            curB = curB.next;
            if(curB==null)
                curB = headA;
        }
        return curA;
    }
}
//优化后如下，时间和空间并没有下降多少
public class Solution
{
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        if (headA == headB && headA.next == headB.next)
            return headA;
        if(headA == null || headB == null)
            return null;
        var curA = headA;
        var curB = headB;
        while (curA != curB)
        {
            if(curA==null)
            {
                curA = headB;
            }
            else
            {
                curA = curA.next;
            }
            if(curB==null)
            {
                curB = headA;
            }
            else
            {
            curB = curB.next;
            }
        }
        return curA;
    }
}
//最终精简版
public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        if (headA == null || headB == null) {
            return null;
        }
        ListNode curA = headA, curB = headB;
        while (curA != curB) {
            curA = curA == null ? headB : curA.next;
            curB = curB == null ? headA : curB.next;
        }
        return curA;
    }
}