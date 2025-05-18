/*
Leetcode 1207. Unique Number of Occurrences  
Topic: Array, Hash Table

Approach:
- Use a dictionary to count the frequency of each number in the array.
- Use a hash set to track the frequencies.
- If any frequency repeats (i.e., cannot be added to the set), return false.
- Otherwise, return true.

Example:
Input: arr = [1,2,2,1,1,3]  
Output: true  
Explanation:  
Occurrences are {1:3, 2:2, 3:1} — all unique counts.

Time Complexity: O(n)  
- One pass to count frequencies, one pass to check uniqueness

Space Complexity: O(n)  
- For storing frequency and unique sets
*/

public class Solution {
    public bool UniqueOccurrences(int[] arr) {
        Dictionary<int, int> freq = [];
        foreach (int num in arr) {
            freq[num] = freq.GetValueOrDefault(num) + 1;
        }

        HashSet<int> unique = [];
        foreach (int count in freq.Values) {
            if (!unique.Add(count)) return false;
        }
        return true;
    }
}
