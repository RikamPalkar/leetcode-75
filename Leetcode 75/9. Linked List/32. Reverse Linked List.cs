/*
Leetcode 206. Reverse Linked List  
Topic: Linked List, Two Pointers

Approach:
- Use three pointers to reverse the linked list in-place:
  - `first`: tracks the previous node (initially null).
  - `second`: current node being processed.
  - `third`: temporarily stores the next node.
- In each iteration:
  - Save the next node (`third = second.next`).
  - Reverse the current node’s pointer (`second.next = first`).
  - Move `first` and `second` one step forward.
- After the loop, `first` will point to the new head of the reversed list.

Time Complexity: O(n), where n is the number of nodes in the list.
Space Complexity: O(1), constant space used.
*/

public class Solution {
    public ListNode ReverseList(ListNode head) 
    {
        if (head == null) return null;

        ListNode first = null;
        ListNode second = head;
        ListNode third = null;

        while (second != null) {
            third = second.next;   // Save next node
            second.next = first;   // Reverse pointer
            first = second;        // Move first forward
            second = third;        // Move second forward
        }

        return first; // New head of reversed list
    }
}
