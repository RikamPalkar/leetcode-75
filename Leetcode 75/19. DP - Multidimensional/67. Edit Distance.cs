/*
Leetcode 72. Edit Distance  
Topic: Dynamic Programming

Approach:
- Use 2D DP array `dp[i][j]` to store the minimum number of operations required to convert
  the first `i` characters of word1 to the first `j` characters of word2.

Operations considered:
- Insert: dp[i][j-1] + 1
- Delete: dp[i-1][j] + 1
- Replace: dp[i-1][j-1] + 1 (only if characters differ)

Base Cases:
- dp[0][j] = j (converting empty word1 to j characters of word2)
- dp[i][0] = i (converting i characters of word1 to empty word2)

Time Complexity: O(m * n)  
Space Complexity: O(m * n)
Where m = word1.Length, n = word2.Length
*/

public class Solution {
    public int MinDistance(string word1, string word2) {
        int len1 = word1.Length;
        int len2 = word2.Length;
        int[][] dp = new int[len1 + 1][];

        for (int i = 0; i <= len1; i++) {
            dp[i] = new int[len2 + 1];
            for (int j = 0; j <= len2; j++) {
                if (i == 0) dp[i][j] = j;
                else if (j == 0) dp[i][j] = i;
            }
        }

        for (int i = 1; i <= len1; i++) {
            for (int j = 1; j <= len2; j++) {
                if (word1[i - 1] == word2[j - 1]) {
                    dp[i][j] = dp[i - 1][j - 1];
                } else {
                    dp[i][j] = 1 + Math.Min(
                        dp[i - 1][j - 1], // Replace
                        Math.Min(
                            dp[i - 1][j],   // Delete
                            dp[i][j - 1]    // Insert
                        )
                    );
                }
            }
        }

        return dp[len1][len2];
    }
}
