/*
Leetcode 746. Min Cost Climbing Stairs
Topic: Dynamic Programming

Approach:
- Use two variables to track the minimum cost to reach the previous two steps.
- Iteratively compute the minimum cost to reach each step.
- The answer is the minimum cost to reach either of the last two steps.

Time Complexity: O(n)
Space Complexity: O(1)
*/

public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        int first = cost[0];
        int second = cost[1];

        for (int i = 2; i < cost.Length; i++) {
            int currentCost = cost[i] + Math.Min(first, second);
            first = second;
            second = currentCost;
        }
        return Math.Min(first, second);
    }
}
