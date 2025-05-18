
/*
Leetcode 1768. Merge Strings Alternately

Approach (Step-by-Step):

1. Initialize two pointers `l` and `r` to track the current index of `word1` and `word2`, respectively.
2. Create a `StringBuilder` to build the final merged string efficiently.
3. Loop while both `l` and `r` are within the bounds of their respective strings:
   - Append `word1[l]` to the result and increment `l`.
   - Append `word2[r]` to the result and increment `r`.
4. After the loop, one of the strings may still have remaining characters:
   - If `word1` has remaining characters, append the rest to the result.
   - If `word2` has remaining characters, append the rest to the result.
5. Return the final string from the `StringBuilder`.

Time Complexity: O(n + m)
- Each character from both strings is visited once.

Space Complexity: O(n + m)
- StringBuilder stores the final merged string of total length n + m.
*/

public class Solution {
    public string MergeAlternately(string word1, string word2) {
        int l = 0;
        int r = 0;
        StringBuilder sb = new();

        // Step 3: Merge characters alternately from both strings
        while (l < word1.Length && r < word2.Length) {
            sb.Append(word1[l++]);
            sb.Append(word2[r++]);
        }

        // Step 4a: Append any remaining characters from word1
        if (l < word1.Length) {
            sb.Append(word1[l..]);
        }

        // Step 4b: Append any remaining characters from word2
        if (r < word2.Length) {
            sb.Append(word2[r..]);
        }

        // Step 5: Return the final merged string
        return sb.ToString();
    }
}
