/*
Leetcode 151. Reverse Words in a String  
Topic: String, Two Pointers

Approach:
- Split the input string into words using space as delimiter, removing empty entries to handle multiple spaces.
- Reverse the order of words in the array.
- Join the reversed words with a single space.
- Return the resulting string, which has no leading or trailing spaces, and only single spaces between words.

Example:
Input: s = "  hello world  "  
Output: "world hello"

Explanation:
- After splitting: ["hello", "world"]  
- Reversed: ["world", "hello"]  
- Joined with single space: "world hello"  
- Leading and trailing spaces removed, multiple spaces reduced to single space.

Example 2:
Input: s = "a good   example"  
Output: "example good a"

Time Complexity: O(n)  
- Where n = s.Length  
- Splitting, reversing, and joining all traverse the string or words linearly.

Space Complexity: O(n)  
- Space for storing words array and final string.
*/

public class Solution
{

    //Approach 1
    public string ReverseWords(string s)
    {
        string[] words = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        Array.Reverse(words);
        return string.Join(" ", words);
    }

    // Approach 2
     public string ReverseWords(string s) {
        string[] words = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        StringBuilder sb = new();

        for(int i=words.Length-1; i>=0; i--)
        {
            sb.Append(words[i]);
            sb.Append(" ");
        }
        return sb.ToString().Trim();
    }
}
