/*
Leetcode 62. Unique Paths  
Topic: Dynamic Programming

Approach:
- We use a 2D DP array where `dp[i][j]` represents the number of unique paths to reach cell (i, j).
- The robot can only move right or down.
- Base case:
    - There is only one way to reach any cell in the first row or first column (by moving only right or only down respectively).
- Transition:
    dp[i][j] = dp[i-1][j] + dp[i][j-1]
    (from the top or from the left)

Time Complexity: O(m * n)  
Space Complexity: O(m * n)
*/

public class Solution {
    public int UniquePaths(int m, int n) {
        int[][] dp = new int[m][];
        
        for (int i = 0; i < m; i++) {
            dp[i] = new int[n];
            for (int j = 0; j < n; j++) {
                if (i == 0 || j == 0) dp[i][j] = 1;
                else dp[i][j] = dp[i - 1][j] + dp[i][j - 1];
            }
        }

        return dp[m - 1][n - 1];
    }
}
