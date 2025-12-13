namespace AlgoMonster.LinkedList
{
    /// <summary>
    /// Core ListNode class to be used by other challenges
    /// </summary>
    public class ListNode
    {
        public int value;
        public ListNode next;
        public ListNode(int v = 0, ListNode n = null)
        {
            value = v; 
            next = n;
        }
    }
}
