/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
 /*
 本解法为常规暴力解法，直接遍历两根链表，通过节点对比找到交点，需要注意的是判空情况，此解时间复杂度为M*N
 */
public class Solution
{
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        if (headA == headB && headA.next == headB.next)
            return headA;
        var curA = headA;
        while (curA != null)
        {
            var curB = headB;
            while (curB != null)
            {
                if (curA == curB)
                {
                    break;
                }
                else
                {
                    curB = curB.next;
                }
            }
            if (curA == curB)
            {
                break;
            }
            else
            {
                curA = curA.next;
            }
        }
        return curA;
    }
}