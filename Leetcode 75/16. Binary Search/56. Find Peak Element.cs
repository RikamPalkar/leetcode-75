/*
Leetcode 162. Find Peak Element  
Topic: Binary Search

Approach:
- Use binary search on the array.
- At each step, check the middle element with its next element:
  - If nums[mid] > nums[mid+1], a peak must be on the left side (including mid).
  - Else, a peak must be on the right side.
- Continue narrowing down until l == r, which points to a peak.
- Since nums[-1] and nums[n] are considered -∞, boundaries are implicitly handled.

Time Complexity: O(log n)
Space Complexity: O(1)
*/

public class Solution {
    public int FindPeakElement(int[] nums) {
        int l = 0;
        int r = nums.Length - 1;

        while (l < r) {
            int mid = l + (r - l) / 2;
            if (nums[mid] > nums[mid + 1]) {
                r = mid;
            } else {
                l = mid + 1;
            }
        }
        return l;
    }
}
