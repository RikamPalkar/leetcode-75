/*
Leetcode 345. Reverse Vowels of a String  
Topic: String, Two Pointers

Approach:
- Identify vowels in the string and collect them in reverse order.
- Traverse the string from left to right:
  - If the character is a vowel, replace it with the next vowel from the reversed collection.
  - Otherwise, keep the character as is.
- Use a StringBuilder to efficiently build the final string.

Example:
Input: s = "IceCreAm"  
Output: "AceCreIm"

Explanation:
- Vowels in s: ['I', 'e', 'e', 'A']  
- Reversed vowels: ['A', 'e', 'e', 'I']  
- Replace vowels in s from left to right with reversed vowels:  
  'I' → 'A'  
  'e' → 'e'  
  'e' → 'e'  
  'A' → 'I'  
- Resulting string: "AceCreIm"

Example 2:
Input: s = "leetcode"  
Output: "leotcede"

Time Complexity: O(n)  
- Where n = s.Length  
- We iterate over the string twice: once to collect vowels, once to build result.

Space Complexity: O(n)  
- Extra space for storing vowels and StringBuilder output.
*/

public class Solution {
    public string ReverseVowels(string s) {
        StringBuilder sb = new();
         HashSet<char> vowels = [ 'A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u' ];
        List<char> vowelsInS = new();

        for (int i = s.Length - 1; i >= 0; i--) {
            if (vowels.Contains(s[i]))
                vowelsInS.Add(s[i]);
        }

        int j = 0;
        for (int i = 0; i < s.Length; i++) {
            if (vowels.Contains(s[i]))
                sb.Append(vowelsInS[j++]);
            else
                sb.Append(s[i]);
        }

        return sb.ToString();
    }
}
