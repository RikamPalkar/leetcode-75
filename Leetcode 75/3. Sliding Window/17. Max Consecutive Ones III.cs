/*
Leetcode 1004. Max Consecutive Ones III  
Topic: Array, Sliding Window, Two Pointers

Approach:
- Use a sliding window to keep track of a subarray containing at most `k` zeros.
- Expand the right pointer, counting zeros encountered.
- If the zero count exceeds `k`, move the left pointer forward until zeros are within limit.
- Keep track of the maximum window size that satisfies the constraint.

Example:
Input: nums = [1,1,1,0,0,0,1,1,1,1,0], k = 2  
Output: 6  
Explanation:
- Flip at most two zeros, longest subarray with max 2 zeros is length 6.

Time Complexity: O(n)  
- One pass through the array with left and right pointers

Space Complexity: O(1)  
- Only counters and pointers used
*/

public class Solution {
    public int LongestOnes(int[] nums, int k) {
        int l = 0, zeroCount = 0, maxLen = 0;

        for (int r = 0; r < nums.Length; r++) {
            if (nums[r] == 0) zeroCount++;

            while (zeroCount > k) {
                if (nums[l] == 0) zeroCount--;
                l++;
            }

            maxLen = Math.Max(maxLen, r - l + 1);
        }

        return maxLen;
    }
}
