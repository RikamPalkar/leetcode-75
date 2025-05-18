/*
Leetcode 1679. Max Number of K-Sum Pairs  
Topic: Array, Hash Table, Two Pointers, Greedy

Approach:
- Use a hash map to store the frequency of each required complement (i.e., `k - num`)
- Iterate through the array:
    - For each number, check if it's already a complement for a previously seen number.
        - If yes, a valid pair is formed. Decrease count in map and increment result.
        - If not, store the complement `k - num` in the map to be used later.
- This approach ensures no elements are reused and maximizes the number of valid pairs.

Example:
Input: nums = [1, 2, 3, 4], k = 5  
Output: 2  
Explanation:
- First pass:
  num = 1 → need 4 → not found → store 4 in map
  num = 2 → need 3 → not found → store 3 in map
  num = 3 → map contains 3 → form pair (3,2) → remove 3 from map
  num = 4 → map contains 4 → form pair (4,1) → remove 4 from map
- Total pairs = 2

Time Complexity: O(n)  
- Where n = nums.Length  
- One pass through the array, and constant time hash map operations

Space Complexity: O(n)  
- In the worst case, the hash map stores up to n elements
*/

public class Solution {
    public int MaxOperations(int[] nums, int k) {
        Dictionary<int, int> map = new();
        int count = 0;

        foreach (int num in nums) {
            int complement = k - num;
            if (map.ContainsKey(num)) {
                // Found a matching pair
                map[num]--;
                if (map[num] == 0) map.Remove(num);
                count++;
            } else {
                // Store the complement for future matches
                map[complement] = map.GetValueOrDefault(complement) + 1;
            }
        }

        return count;
    }
}
