/*
Leetcode 1657. Determine if Two Strings Are Close  
Topic: String, Hash Table, Sorting

Approach:
- If lengths differ, return false immediately.
- Count frequency of each character for both strings.
- Check if both strings have the same set of unique characters.
- Sort the frequency arrays and compare.
- If frequencies match and unique characters sets match, return true; else false.

Why this works:
- Operation 1 (swap any two characters) allows rearranging characters freely.
- Operation 2 (transform all occurrences of one character to another and vice versa) means the frequency distribution can be permuted but the unique characters must be the same.

Example:
word1 = "abc", word2 = "bca"
- Both have same unique characters {'a','b','c'}.
- Frequencies after sorting match: [1,1,1].
- So, return true.

Time Complexity: O(n + k log k) where n is length of strings and k=26 (alphabet size)  
Space Complexity: O(k)

*/

public class Solution {
    public bool CloseStrings(string word1, string word2) {
        if(word1.Length != word2.Length) return false;

        int[] freq1 = new int[26];
        int[] freq2 = new int[26];

        HashSet<char> uniqueChars1 = new();
        HashSet<char> uniqueChars2 = new();

        for(int i=0; i<word1.Length; i++) {
            freq1[word1[i] - 'a']++;
            freq2[word2[i] - 'a']++;
            uniqueChars1.Add(word1[i]);
            uniqueChars2.Add(word2[i]);
        }

        // Check if both strings have the same unique characters
        if (!uniqueChars1.SetEquals(uniqueChars2)) return false;

        Array.Sort(freq1);
        Array.Sort(freq2);

        for(int i=0; i<26; i++) {
            if(freq1[i] != freq2[i]) return false;
        }

        return true;
    }
}
