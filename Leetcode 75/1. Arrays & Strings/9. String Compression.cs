/*
Leetcode 443. String Compression  
Topic: Array, Two Pointers

Approach:
- Use two pointers: `i` to scan the array and `index` to track the position where the compressed characters are written.
- For each group of consecutive characters:
  - Count how many times the current character repeats.
  - Write the character to the `index` position.
  - If the count is more than 1, convert the count to a string and write each digit.
- Continue until the full array is processed.
- Return the value of `index`, which represents the new length of the compressed array.

Example:
Input: chars = ['a','a','b','b','c','c','c']  
Groups: "aa", "bb", "ccc"  
Output: Return 6  
chars is modified to: ['a','2','b','2','c','3']

Step-by-step:
- Start with index = 0
- "a" appears 2 times → write 'a', '2' → index = 2
- "b" appears 2 times → write 'b', '2' → index = 4
- "c" appears 3 times → write 'c', '3' → index = 6

Final compressed array: ['a','2','b','2','c','3']

Time Complexity: O(n)  
- Where n = chars.Length  
- Each character is processed once; each count (up to log10 of the group size) is also processed once.

Space Complexity: O(1)  
- Only constant extra space is used for variables and digit conversion.
*/

public class Solution {
    public int Compress(char[] chars) {
        int index = 0;
        int len = chars.Length;
        int i = 0;

        while (i < len) {
            int count = 0;
            char currentChar = chars[i];

            while (i < len && chars[i] == currentChar) {
                i++;
                count++;
            }

            chars[index++] = currentChar;

            if (count > 1) {
                foreach (char ch in count.ToString()) {
                    chars[index++] = ch;
                }
            }
        }

        return index;
    }
}
