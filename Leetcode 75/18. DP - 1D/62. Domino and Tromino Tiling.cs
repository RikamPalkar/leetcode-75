/*
Leetcode 790. Domino and Tromino Tiling  
Topic: Dynamic Programming

Approach:
- We use dynamic programming where `dp[i]` represents the number of ways to tile a 2 x i board.
- Recurrence relation:
    dp[i] = 2 * dp[i - 1] + dp[i - 3]
    This is based on:
    - Adding a vertical domino to all (dp[i - 1]) arrangements of length i-1
    - Adding two horizontal dominoes (like dp[i - 2], but this is folded into 2 * dp[i - 1])
    - Adding a tromino, which has two configurations that match dp[i - 3]
- Base cases:
    dp[0] = 1 (empty board)
    dp[1] = 1
    dp[2] = 2

Time Complexity: O(n)  
Space Complexity: O(n)  
*/

public class Solution {
    public int NumTilings(int n) {
        int mod = 1_000_000_007;
        if (n == 0) return 1;
        if (n == 1) return 1;
        if (n == 2) return 2;

        int[] dp = new int[n + 1];
        dp[0] = 1;
        dp[1] = 1;
        dp[2] = 2;

        for (int i = 3; i <= n; i++) {
            dp[i] = ((2L * dp[i - 1]) % mod + dp[i - 3]) % mod;
        }

        return dp[n];     
    }  
}
