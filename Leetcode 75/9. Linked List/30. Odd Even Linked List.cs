/*
Leetcode 328. Odd Even Linked List  
Topic: Linked List, Two Pointers

Approach:
- Use two pointers to separate nodes at odd and even indices.
- Traverse the list once, updating odd and even pointers alternately.
- Keep a reference to the start of the even list (`evenHead`) to reconnect at the end.
- After separating, append the even list after the odd list.

Time Complexity: O(n), where n is the number of nodes in the list.
Space Complexity: O(1), constant extra space used.
*/

public class Solution {
    public ListNode OddEvenList(ListNode head) {
        if (head == null || head.next == null)
            return head; // No rearrangement needed for 0 or 1 node

        ListNode odd = head;
        ListNode even = head.next;
        ListNode evenHead = even; // Save head of even list

        while (even != null && even.next != null) {
            odd.next = even.next; // Link current odd to next odd
            odd = odd.next;

            even.next = odd.next; // Link current even to next even
            even = even.next;
        }

        odd.next = evenHead; // Connect end of odd list to start of even list
        return head;
    }
}
