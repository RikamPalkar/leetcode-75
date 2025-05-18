/*
Leetcode 1143. Longest Common Subsequence  
Topic: Dynamic Programming

Approach:
- Use a 2D DP array `dp[i][j]` where:
  `dp[i][j]` = length of LCS between `text1[0..i-1]` and `text2[0..j-1]`.
- If characters match (text1[i-1] == text2[j-1]):
    dp[i][j] = dp[i-1][j-1] + 1
- If not:
    dp[i][j] = max(dp[i-1][j], dp[i][j-1])

Initialization:
- dp[0][*] = 0 and dp[*][0] = 0 since LCS with empty string is 0.

Time Complexity: O(m * n)  
Space Complexity: O(m * n)
*/

public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        int len1 = text1.Length;
        int len2 = text2.Length;
        int[][] dp = new int[len1 + 1][];

        for (int i = 0; i <= len1; i++) {
            dp[i] = new int[len2 + 1];
        }

        for (int i = 1; i <= len1; i++) {
            for (int j = 1; j <= len2; j++) {
                if (text1[i - 1] == text2[j - 1]) {
                    dp[i][j] = dp[i - 1][j - 1] + 1;
                } else {
                    dp[i][j] = Math.Max(dp[i - 1][j], dp[i][j - 1]);
                }
            }
        }

        return dp[len1][len2];
    }
}
