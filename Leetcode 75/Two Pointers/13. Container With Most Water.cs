/*
Leetcode 11. Container With Most Water  
Topic: Two Pointers, Greedy

Approach:
- Use two pointers:
  - One at the start (`l = 0`)
  - One at the end (`r = height.Length - 1`)
- Compute the area between the lines at both ends:
  - Area = min(height[l], height[r]) * (r - l)
- Move the pointer pointing to the shorter line inward, since moving the taller one can't help increase the area.
- Track and update the maximum area found during iteration.

Example:
Input: height = [1,8,6,2,5,4,8,3,7]

Step-by-step (without showing all steps for brevity):
- Initial max area: min(1, 7) * (8 - 0) = 1 * 8 = 8
- Move left from 0 to 1
- Now: min(8, 7) * (8 - 1) = 7 * 7 = 49 → update max to 49
- Continue moving pointers inward...
- Final max area: 49

Time Complexity: O(n)  
- Where n = height.Length  
- We move each pointer at most once

Space Complexity: O(1)  
- No extra space used other than a few variables
*/

public class Solution {
    public int MaxArea(int[] height) {
        int l = 0, r = height.Length - 1;
        int max = 0;

        while (l < r) {
            int minHeight = Math.Min(height[l], height[r]);
            int width = r - l;
            int area = minHeight * width;

            max = Math.Max(max, area);

            if (height[l] < height[r]) l++;
            else r--;
        }

        return max;
    }
}
