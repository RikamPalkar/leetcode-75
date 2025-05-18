/*
Leetcode 724. Find Pivot Index  
Topic: Array, Prefix Sum

Approach:
- Calculate the total sum of the array.
- Iterate through the array while maintaining the running sum of elements to the left.
- At each index, check if left sum equals right sum, where right sum = total sum - current element - left sum.
- If they are equal, return the current index as pivot.
- If no pivot found, return -1.

Example:
Input: nums = [1,7,3,6,5,6]  
Output: 3  
Explanation:  
Left sum at index 3 = 1+7+3 = 11  
Right sum at index 3 = 5+6 = 11

Time Complexity: O(n)  
- One pass to calculate total sum + one pass to find pivot

Space Complexity: O(1)  
- Only variables used for sums and iteration
*/

public class Solution {
    public int PivotIndex(int[] nums) {
        int leftSum = 0;
        int rightSum = nums.Sum();

        for (int i = 0; i < nums.Length; i++) {
            rightSum -= nums[i];    // rightSum now excludes current element
            if (leftSum == rightSum) return i;
            leftSum += nums[i];
        }

        return -1;
    }
}
