/*
Leetcode 238. Product of Array Except Self  
Topic: Array, Prefix Product

Approach:
- Create two arrays: `prefix` and `suffix`.
- `prefix[i]` stores the product of all elements to the **left** of index `i`.
- `suffix[i]` stores the product of all elements to the **right** of index `i`.
- Final result at index `i` is the product of `prefix[i] * suffix[i]`.
- This avoids using division and maintains O(n) time.

Example:
Input: nums = [1, 2, 3, 4]  
Output: [24, 12, 8, 6]  

Step-by-step:
Prefix products:
prefix[0] = 1  
prefix[1] = 1 * nums[0] = 1  
prefix[2] = 1 * nums[1] = 2  
prefix[3] = 2 * nums[2] = 6  
Result:     [1, 1, 2, 6]

Suffix products:
suffix[3] = 1  
suffix[2] = 1 * nums[3] = 4  
suffix[1] = 4 * nums[2] = 12  
suffix[0] = 12 * nums[1] = 24  
Result:     [24, 12, 4, 1]

Final result:
res[i] = prefix[i] * suffix[i]  
res = [1*24, 1*12, 2*4, 6*1] → [24, 12, 8, 6]

Time Complexity: O(n)  
- Where n = nums.Length  
- One pass for prefix, one for suffix, one for final result.

Space Complexity: O(n)  
- Additional arrays `prefix`, `suffix`, and `res` used.
*/

public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int len = nums.Length;
        int[] prefix = new int[len];
        int[] suffix = new int[len];
        int[] res = new int[len];

        prefix[0] = 1;
        for (int i = 1; i < len; i++)
            prefix[i] = nums[i - 1] * prefix[i - 1];

        suffix[len - 1] = 1;
        for (int i = len - 2; i >= 0; i--)
            suffix[i] = nums[i + 1] * suffix[i + 1];

        for (int i = 0; i < len; i++)
            res[i] = prefix[i] * suffix[i];

        return res;
    }
}
