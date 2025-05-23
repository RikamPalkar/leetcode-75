/*
Leetcode 2130. Maximum Twin Sum of a Linked List  
Topic: Linked List, Two Pointers

Approach:
- The problem asks for the max sum of mirrored pairs in a linked list of even length.
- We:
  1. Use slow & fast pointers to find the middle of the linked list.
  2. Reverse the second half of the list.
  3. Use two pointers (one from start, one from the reversed half) to calculate twin sums.
  4. Track and return the maximum twin sum.

Time Complexity: O(n) — One pass to find the middle, one to reverse, one to find the twin sum.
Space Complexity: O(1) — In-place reversal of the second half.
*/

public class Solution {
    public int PairSum(ListNode head) {
        // Step 1: Find middle using slow and fast pointers
        ListNode slow = head;
        ListNode fast = head;
        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;
        }

        // Step 2: Reverse second half of the list
        ListNode reverseHead = ReverseLinkedList(slow);

        // Step 3: Calculate max twin sum
        int max = 0;
        ListNode curr = head;
        while (reverseHead != null) {
            max = Math.Max(max, curr.val + reverseHead.val);
            curr = curr.next;
            reverseHead = reverseHead.next;
        }

        return max;
    }

    private ListNode ReverseLinkedList(ListNode head) {
        ListNode prev = null;
        while (head != null) {
            ListNode nextTemp = head.next;
            head.next = prev;
            prev = head;
            head = nextTemp;
        }
        return prev;
    }
}
