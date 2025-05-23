/*
Leetcode 283. Move Zeroes  
Topic: Array, Two Pointers

Approach:
- Use a pointer `zerosPlace` to track the position where the next non-zero element should go.
- Traverse the array:
  - If the current number is non-zero, place it at `zerosPlace` index.
  - Set the current position to 0 (if needed) to shift the zero forward.
  - Increment `zerosPlace` to move to the next valid position.
- This ensures all non-zero elements are moved to the beginning while keeping their relative order.
- All zeros are shifted towards the end.

Example:
Input: nums = [0, 1, 0, 3, 12]  
Step-by-step:
- i = 0 → nums[0] = 0 → skip
- i = 1 → nums[1] = 1 → nums[0] = 1, nums[1] = 0 → zerosPlace = 1
- i = 2 → nums[2] = 0 → skip
- i = 3 → nums[3] = 3 → nums[1] = 3, nums[3] = 0 → zerosPlace = 2
- i = 4 → nums[4] = 12 → nums[2] = 12, nums[4] = 0 → zerosPlace = 3

Result: [1, 3, 12, 0, 0]

Time Complexity: O(n)  
- Where n = nums.Length  
- Each element is visited once.

Space Complexity: O(1)  
- In-place solution with no additional memory.
*/

public class Solution {
    public void MoveZeroes(int[] nums) {
        int zerosPlace = 0;
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] != 0) {
                int temp = nums[i];
                nums[i] = 0;
                nums[zerosPlace++] = temp;
            }
        }
    }
}
