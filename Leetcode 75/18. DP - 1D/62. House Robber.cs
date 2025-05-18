/*
Leetcode 198. House Robber  
Topic: Dynamic Programming

Approach:
- Use two variables to track the maximum loot at previous two houses.
- For each house, decide whether to rob it (and add its money to `first`) or skip it (and keep `second`).
- Update `first` and `second` as we move through the array.

Base Cases:
- If only one house, rob it.
- If two houses, rob the one with more money.

Time Complexity: O(n)
Space Complexity: O(1)
*/

public class Solution {
    public int Rob(int[] nums) {
        if (nums.Length == 1) return nums[0];

        int first = nums[0];
        int second = Math.Max(nums[0], nums[1]);

        for (int i = 2; i < nums.Length; i++) {
            int maxLoot = Math.Max(nums[i] + first, second);
            first = second;
            second = maxLoot;
        }

        return second;
    }
}
