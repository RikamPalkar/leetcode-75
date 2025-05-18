/*
Leetcode 338. Counting Bits  
Topic: Dynamic Programming, Bit Manipulation

Approach (Naive):
- For each number from 0 to n, count the number of 1's in its binary representation
  using bitwise operations.

Time Complexity: O(n log n) – because counting bits for each number takes up to log(n) time
Space Complexity: O(n)

Optimized Approach (Dynamic Programming):
- Let `ans[i] = ans[i >> 1] + (i & 1)`
  - `i >> 1` is i divided by 2 (i.e., right shift)
  - `(i & 1)` is 1 if the least significant bit is set, 0 otherwise
- This builds up the result using previously computed results

Time Complexity: O(n)  
Space Complexity: O(n)

5 << 1 is 10. 

101
1010

Left-shifting a binary number by one position effectively adds a zero at the end of the binary representation. Each bit is shifted to the left, and a zero is appended to the right side.

Before shifting:   1010
After shifting:  10100

This is equivalent to multiplying the original number by 2.


       // 0 1 2 3
       // 1 2 4 8
       // 4 * 2 = 8
       // 4 << 1 = 8


 1 << 2 (shift by 2): 0001 becomes 0100 → Result: 4
 1 << 3 (shift by 3): 0001 becomes 1000 → Result: 8
 1 << 4 (shift by 4): 0001 becomes 1 0000 → Result: 16
*/

// Optimized version using dynamic programming
public class Solution {
    public int[] CountBits(int n) {
        int[] ans = new int[n + 1];
        for (int i = 1; i <= n; i++) {
            ans[i] = ans[i >> 1] + (i & 1);
        }
        return ans;
    }
}
