/*
Leetcode 1456. Maximum Number of Vowels in a Substring of Given Length  
Topic: String, Sliding Window

Approach:
- Use a sliding window of size `k` to check the number of vowels in each substring.
- Count vowels in the initial window of length `k`.
- As the window slides forward, subtract the character that goes out (if it's a vowel)
  and add the new character coming in (if it's a vowel).
- Keep track of the maximum number of vowels seen in any window.

Example:
Input: s = "abciiidef", k = 3  
Output: 3  
Explanation:
- Substrings: "abc", "bci", "cii", "iii", "iid", "ide", "def"
- "iii" has the highest number of vowels (3)

Time Complexity: O(n)  
- Where n = s.Length  
- Each character is processed at most twice (entering and leaving the window)

Space Complexity: O(1)  
- Constant space used for counters and helper function
*/

public class Solution {
    public int MaxVowels(string s, int k) {
        int l = 0;
        int count = 0;
        int maxCount = 0;

        for (int i = 0; i < s.Length; i++) {
            if (IsVowel(s[i])) count++;

            if (i >= k) {
                if (IsVowel(s[l])) count--;
                l++;
            }

            maxCount = Math.Max(maxCount, count);
        }

        return maxCount;
    }

    private bool IsVowel(char ch) {
        return ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u';
    }
}
