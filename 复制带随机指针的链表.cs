/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/
/*
    此题主要思路为循环两遍，一遍创建新链表，一遍对于新链表的next和random进行赋值。
*/
public class Solution {
    public Node CopyRandomList(Node head) {
        if(head==null)
            return null;
        var cur = head;
        Dictionary<Node,Node> dic = new Dictionary<Node,Node>();
        while(cur!=null)
        {
            dic.Add(cur,new Node(cur.val));
            cur = cur.next;
        }
        cur = head;
        while(cur!=null)
        {
            if(cur.next!=null)
            {
                dic[cur].next=dic[cur.next];
            }
            if(cur.random!=null)
            {
                dic[cur].random=dic[cur.random];
            }
            cur = cur.next;
        }
        return dic[head];
    }
}