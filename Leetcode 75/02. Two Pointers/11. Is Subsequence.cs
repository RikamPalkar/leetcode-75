/*
Leetcode 392. Is Subsequence  
Topic: Two Pointers, String

Approach:
- Use two pointers:  
  - `l` for traversing string `s`  
  - `r` for traversing string `t`
- Iterate through `t` using `r`
  - If `s[l] == t[r]`, it means we found a match, so move `l` forward.
  - Regardless of match or not, always move `r` forward.
- If we reach the end of `s` (`l == s.Length`), it means all characters of `s` appeared in `t` in the correct order.

Example:
Input: s = "abc", t = "ahbgdc"  
Steps:
- s[0] = 'a' matches t[0] = 'a' → l = 1  
- s[1] = 'b' matches t[2] = 'b' → l = 2  
- s[2] = 'c' matches t[5] = 'c' → l = 3  
All characters in `s` matched in order → return true

Input: s = "axc", t = "ahbgdc"  
Steps:
- s[0] = 'a' matches t[0] = 'a' → l = 1  
- s[1] = 'x' does not match t[1 to 5] → never matches  
Only 1 character matched → return false

Time Complexity: O(n)  
- n = length of `t`  
- We traverse `t` once while checking characters from `s`

Space Complexity: O(1)  
- Only a few pointers are used, no extra memory
*/

public class Solution {
    public bool IsSubsequence(string s, string t) {
        int l = 0;
        for (int r = 0; r < t.Length; r++) {
            if (l == s.Length) break;
            if (s[l] == t[r]) l++;
        }
        return l == s.Length;
    }
}
