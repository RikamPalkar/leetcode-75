/*
Leetcode 394. Decode String
Topic: Stack, String

Approach:
- Use two stacks: one for counts (repeat times) and one for strings.
- Iterate through the string:
  - If digit, build the current number.
  - If '[', push current number and current string to stacks, reset them.
  - If ']', pop count and previous string, append current string repeated count times to previous string.
  - If letter, append to current string.
- At the end, current string holds the decoded result.

Time Complexity: O(n * k) where k is max repetition (worst case)
Space Complexity: O(n) for stacks and output
*/

public class Solution {
    public string DecodeString(string s) {
        Stack<int> countStack = new Stack<int>();
        Stack<StringBuilder> strStack = new Stack<StringBuilder>();
        int currNum = 0;
        StringBuilder currStr = new StringBuilder();

        for (int i = 0; i < s.Length; i++) {
            char ch = s[i];

            if (Char.IsDigit(ch)) {
                currNum = currNum * 10 + (ch - '0');
            }
            else if (ch == '[') {
                countStack.Push(currNum);
                strStack.Push(currStr);
                currNum = 0;
                currStr = new StringBuilder();
            }
            else if (ch == ']') {
                int count = countStack.Pop();
                StringBuilder prevStr = strStack.Pop();

                for (int j = 0; j < count; j++) {
                    prevStr.Append(currStr);
                }
                currStr = prevStr;
            }
            else {
                currStr.Append(ch);
            }
        }

        return currStr.ToString();
    }
}
