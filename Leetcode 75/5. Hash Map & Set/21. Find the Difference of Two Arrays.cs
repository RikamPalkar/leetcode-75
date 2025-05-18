/*
Leetcode 2215. Find the Difference of Two Arrays  
Topic: Array, Hash Set

Approach:
- Convert both arrays to hash sets to get distinct elements.
- For the first answer list, find elements in nums1Set that are not in nums2Set.
- For the second answer list, find elements in nums2Set that are not in nums1Set.
- Return both lists in a list of lists.

Example:
Input: nums1 = [1,2,3], nums2 = [2,4,6]  
Output: [[1,3],[4,6]]  
Explanation:  
Elements 1 and 3 are unique to nums1, elements 4 and 6 are unique to nums2.

Time Complexity: O(n + m)  
- Where n and m are lengths of nums1 and nums2  
- Hash set operations and set difference are O(1) average

Space Complexity: O(n + m)  
- Hash sets store distinct elements from both arrays
*/

public class Solution {
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2) {
        HashSet<int> nums1Set = new(nums1);
        HashSet<int> nums2Set = new(nums2);

        List<int> first = nums1Set.Except(nums2Set).ToList();
        List<int> second = nums2Set.Except(nums1Set).ToList();

        return new List<IList<int>> { first, second };
    }
}
