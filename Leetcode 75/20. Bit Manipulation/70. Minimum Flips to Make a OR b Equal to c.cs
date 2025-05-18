/*
Leetcode 1318. Minimum Flips to Make a OR b Equal to c  
Topic: Bit Manipulation

Approach:
- Use bitwise operations to evaluate each bit of a, b, and c.
- For each bit:
    - If cBit is 1: 
        - At least one of aBit or bBit must be 1. 
        - If both are 0, we need 1 flip.
    - If cBit is 0:
        - Both aBit and bBit must be 0.
        - Count 1 flip for each bit that is 1.

Time Complexity: O(32) → O(1), since integers are 32 bits  
Space Complexity: O(1)


            0 0 1 1
            0 1 0 1
        ----------------
            0 1 1 1
        
*/

public class Solution {
    public int MinFlips(int a, int b, int c) {
        int count = 0;

        while (a > 0 || b > 0 || c > 0) {
            int aBit = a & 1;
            int bBit = b & 1;
            int cBit = c & 1;

            if (cBit == 1) {
                if (aBit == 0 && bBit == 0) count++;
            } else {
                if (aBit == 1) count++;
                if (bBit == 1) count++;
            }

            a >>= 1;
            b >>= 1;
            c >>= 1;
        }

        return count;
    }
}
