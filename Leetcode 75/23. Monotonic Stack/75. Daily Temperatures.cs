/*
Leetcode 739. Daily Temperatures  
Topic: Stack, Monotonic Stack

Approach:
- Use a stack to keep indices of temperatures in decreasing order.
- Iterate through temperatures:
  - While current temperature is greater than the temperature at the index on top of the stack:
    - Pop from stack and calculate the difference in indices (days waited).
  - Push current index onto stack.
- Indices remaining in stack have no warmer future day, so their answer remains 0.

Time Complexity:
- O(n), each index pushed and popped at most once.
Space Complexity:
- O(n) for the stack and result array.
*/

public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        int len = temperatures.Length;
        Stack<int> mono = new();  // Monotonic stack storing indices
        int[] res = new int[len]; // Result array initialized with 0 by default

        for(int i = 0; i < len; i++){
            // While current temp is warmer than the temp at top of stack,
            // pop and calculate days waited
            while(mono.Count > 0 && temperatures[i] > temperatures[mono.Peek()]){
                int top = mono.Pop();
                res[top] = i - top;
            }
            mono.Push(i);
        }
        return res;
    }
}
