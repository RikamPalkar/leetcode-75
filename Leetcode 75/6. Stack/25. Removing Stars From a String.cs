/*
Leetcode 2390. Removing Stars From a String
Topic: String, Stack

Approach:
- Use a stack to simulate the removals.
- For each character in the string:
  - If it's a star '*', pop the top character from the stack (removes closest non-star to the left).
  - Else, push the character onto the stack.
- At the end, the stack contains the final string characters in order.
- Convert the stack to a string and return.

Time Complexity: O(n)
Space Complexity: O(n)
*/

public class Solution {
    public string RemoveStars(string s) {
        Stack<char> stack = new Stack<char>();

        foreach (char c in s) {
            if (c == '*') {
                if (stack.Count > 0) stack.Pop();
            } else {
                stack.Push(c);
            }
        }

        // Stack stores characters in reverse order, so reverse them before returning.
        return new string(stack.Reverse().ToArray());
    }
}
