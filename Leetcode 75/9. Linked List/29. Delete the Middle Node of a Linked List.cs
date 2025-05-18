/*
Leetcode 2095. Delete the Middle Node of a Linked List  
Topic: Linked List, Two Pointers

Approach:
- Use the two-pointer technique (slow and fast pointers).
- Move 'fast' two steps at a time and 'slow' one step.
- Maintain a 'prev' pointer to track the node before 'slow'.
- When 'fast' reaches the end, 'slow' is at the middle.
- Remove the middle node by linking 'prev.next' to 'slow.next'.
- If the list has only one node, return null.

Time Complexity: O(n), where n is the number of nodes in the list.
Space Complexity: O(1), no extra space used apart from pointers.
*/

public class Solution {
    public ListNode DeleteMiddle(ListNode head) {
        if (head == null || head.next == null)
            return null;

        ListNode prev = null;
        ListNode slow = head;
        ListNode fast = head;

        // Find the middle node using slow and fast pointers
        while (fast != null && fast.next != null) {
            prev = slow;
            slow = slow.next;
            fast = fast.next.next;
        }

        // Remove the middle node
        if (prev != null)
            prev.next = slow.next;

        return head;
    }
}
