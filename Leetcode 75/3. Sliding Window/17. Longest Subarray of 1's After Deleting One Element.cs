/*
Leetcode 1493. Longest Subarray of 1's After Deleting One Element  
Topic: Array, Sliding Window, Two Pointers

Approach:
- Use a sliding window to maintain a window with at most one zero (since we delete exactly one element).
- Expand right pointer and count zeros.
- If zero count exceeds 1, move left pointer until window has at most one zero.
- Keep track of the maximum length of the window minus one (because we have to delete one element).
- The subtraction accounts for deleting exactly one element (the zero or one element).

Example:
Input: nums = [1,1,0,1]  
Output: 3  
Explanation:
- Delete the zero at index 2, resulting in [1,1,1], longest subarray of 1's is length 3.

Time Complexity: O(n)  
- One pass through the array with left and right pointers

Space Complexity: O(1)  
- Only counters and pointers used
*/

public class Solution {
    public int LongestSubarray(int[] nums) {
        int l = 0, zeros = 0, maxLen = 0;

        for (int r = 0; r < nums.Length; r++) {
            if (nums[r] == 0) zeros++;

            while (zeros > 1) {
                if (nums[l] == 0) zeros--;
                l++;
            }

            // (r - l) because one element must be deleted, so window length minus one
            maxLen = Math.Max(maxLen, r - l);
        }

        return maxLen;
    }
}
