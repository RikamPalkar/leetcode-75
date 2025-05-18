/*
Leetcode 643. Maximum Average Subarray I  
Topic: Array, Sliding Window

Approach:
- Use a sliding window of size `k` to find the maximum sum of any subarray of length `k`.
- Initialize the window with the sum of the first `k` elements.
- Slide the window across the array:
    - Subtract the element that exits the window (left side)
    - Add the element that enters the window (right side)
    - Keep track of the maximum sum encountered
- Return the maximum average as maxSum / k.

Example:
Input: nums = [1,12,-5,-6,50,3], k = 4  
Output: 12.75  
Explanation:
- Initial window: [1, 12, -5, -6] → sum = 2
- Slide right: [12, -5, -6, 50] → sum = 51 → max = 51
- Slide right: [-5, -6, 50, 3] → sum = 42 → max stays 51
- Max average = 51 / 4 = 12.75

Time Complexity: O(n)  
- Where n = nums.Length  
- Each element is visited once during the sliding window traversal

Space Complexity: O(1)  
- Only a few integer variables are used
*/

public class Solution {
    public double FindMaxAverage(int[] nums, int k) {
        int sum = 0;

        // Compute the initial sum of the first window
        for (int i = 0; i < k; i++) {
            sum += nums[i];
        }

        int maxSum = sum;

        // Slide the window through the rest of the array
        for (int i = k; i < nums.Length; i++) {
            sum = sum - nums[i - k] + nums[i];
            maxSum = Math.Max(maxSum, sum);
        }

        return (double)maxSum / k;
    }
}