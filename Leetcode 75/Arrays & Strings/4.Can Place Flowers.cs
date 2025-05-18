/*
Leetcode 605. Can Place Flowers  
Topic: Array, Greedy

Approach:
- Iterate through each plot in the flowerbed.
- For each empty plot (0), check if the adjacent plots are also empty or out of bounds:
  - Left plot is empty if the current plot is the first or the plot before it is 0.
  - Right plot is empty if the current plot is the last or the plot after it is 0.
- If both adjacent plots are empty, plant a flower here (set current plot to 1) and decrease n by 1.
- If at any point n is 0 or less, return true immediately.
- If the loop ends and n is still greater than 0, return false.

Example:
Input: flowerbed = [1, 0, 0, 0, 1], n = 1  
Output: true

Iteration details:
- Index 0: flowerbed[0] = 1, cannot plant.
- Index 1: flowerbed[1] = 0, left is 1 (not empty), cannot plant.
- Index 2: flowerbed[2] = 0, left is 0, right is 0 → plant flower here. n = 0, return true.

Example 2:
Input: flowerbed = [1, 0, 0, 0, 1], n = 2  
Output: false

- Can only plant at index 2, but need 2 flowers, so return false.

Time Complexity: O(n)  
- Where n = flowerbed.Length  
- We scan the flowerbed once.

Space Complexity: O(1)  
- We modify the flowerbed array in-place and use constant extra space.
*/

public class Solution {
    public bool CanPlaceFlowers(int[] flowerbed, int n) {
        int len = flowerbed.Length;

        for (int i = 0; i < len; i++) {
            if (flowerbed[i] == 0) {
                bool isLeftPlotEmpty = (i == 0) || (flowerbed[i - 1] == 0);
                bool isRightPlotEmpty = (i == len - 1) || (flowerbed[i + 1] == 0);

                if (isLeftPlotEmpty && isRightPlotEmpty) {
                    flowerbed[i] = 1;
                    n--;
                    if (n <= 0) return true;
                    i++; // Skip the next plot since adjacent planting not allowed
                }
            }
        }

        return n <= 0;
    }
}
