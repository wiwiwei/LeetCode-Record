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
    比较激动，经过几天的联系，本地几乎是一把过（第一把没加空处理），且之遍历一遍，空间复杂度也是o(1).
 */
public class Solution {
    public ListNode ReverseBetween(ListNode head, int left, int right) {
        if(left==right)
            return head; 
        var cur = head;
        ListNode shaobingA = null;//记录需要反转的链表的left位置（左边头部）
        ListNode shaobingApre = null;//记录左边不需要反转的链表的尾部
        //ListNode shaobingB = null;//记录需要反转的链表的right位置（右边尾部）
        ListNode pre = null;//指针的前一个
        ListNode newHead = new ListNode();//头部哨兵,用于结果返回
        if(left>1)
        {
            newHead.next = cur;//当不需要一开始就反转的时候，头部哨兵的next设置为链表的头即可。
        }
        int n = 1;//指针位置下标
        while(cur!=null)//遍历链表
        {
            if(n<left)//此时位于反转起始位置的左侧，只需要记录不需要反转的部分的尾部即可
            {
                shaobingApre = cur;//记录不需要反转的部分的尾部
                cur = cur.next;
            }
            else if(n==left)//此时位于反转起始位置，需要记录第一个哨兵
            {
                shaobingA = cur;
                pre = cur;
                cur = shaobingA;
                cur = cur.next;
            }
            else if(n>left&&n<right)//反转中，正常的反转算法
            {
                var node = cur.next;
                cur.next = pre;
                pre = cur;
                cur = node;
            }
            else if(n==right)//此时位于反转尾部，需要将哨兵A的next指向剩余节点（空也没关系），同时将不需要反转的部分尾部接上已经反转的链表的头部
            {
                var node = cur.next;
                cur.next = pre;
                pre = cur;
                cur = node;
                if(shaobingApre!=null)
                {
                    shaobingApre.next = pre;//接上已经反转的链表的头部
                }
                shaobingA.next = node;//将哨兵A的next指向剩余节点
            }
            else
            {
                cur = cur.next;
            }
            n++;
        }
        if(left ==1)
        {
            newHead.next = pre;//如果一开始就反转，就直接返回pre就行
        }
        return newHead.next;
    }
}