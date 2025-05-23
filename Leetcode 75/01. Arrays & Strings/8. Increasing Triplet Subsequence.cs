/*
Leetcode 334. Increasing Triplet Subsequence  
Topic: Array, Greedy

Approach:
- Maintain two variables: `left` (smallest so far), and `mid` (second smallest).
- Iterate through the array:
  - If current number ≤ `left`, update `left`.
  - Else if current number ≤ `mid`, update `mid`.
  - Else, a number greater than both `left` and `mid` is found → return true.
- If loop finishes without finding such a triplet, return false.

Example:
Input: nums = [2, 1, 5, 0, 4, 6]  
Output: true  

Explanation:
- Start: left = ∞, mid = ∞
- nums[0] = 2 → left = 2
- nums[1] = 1 → left = 1
- nums[2] = 5 → mid = 5
- nums[3] = 0 → left = 0
- nums[4] = 4 → mid = 4
- nums[5] = 6 → 6 > mid → increasing triplet (0 < 4 < 6) found → return true

Time Complexity: O(n)  
- Where n = nums.Length  
- Single pass through the array.

Space Complexity: O(1)  
- Only two variables are used regardless of input size.
*/

public class Solution {
    public bool IncreasingTriplet(int[] nums) {
        int left = Int32.MaxValue;
        int mid = Int32.MaxValue;

        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] <= left) {
                left = nums[i]; // new smallest value
            }
            else if (nums[i] <= mid) {
                mid = nums[i]; // new second smallest
            }
            else {
                return true; // found a value > left and mid
            }
        }

        return false;  // no increasing triplet found
    }
}
