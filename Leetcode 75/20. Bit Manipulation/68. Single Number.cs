/*
Leetcode 136. Single Number  
Topic: Bit Manipulation

Approach:
- Use the XOR operator to find the unique element.
- XOR of a number with itself is 0.
- XOR of a number with 0 is the number itself.
- XORing all numbers together will cancel out all numbers appearing twice,
  leaving only the single number.

Time Complexity: O(n) – single pass through the array  
Space Complexity: O(1) – constant extra space

Example:
Input: [4,1,2,1,2]
Step-by-step XOR:
4 ^ 1 = 5
5 ^ 2 = 7
7 ^ 1 = 6
6 ^ 2 = 4  → Result is 4
*/

public class Solution {
    public int SingleNumber(int[] nums) {
        int res = 0;
        for (int i = 0; i < nums.Length; i++) {
            res ^= nums[i];
        }
        return res;
    }
}
