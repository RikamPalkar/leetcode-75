/*
Leetcode 2300. Successful Pairs of Spells and Potions  
Topic: Binary Search, Sorting

Approach:
- Sort the potions array.
- For each spell, use binary search to find the smallest index in potions where 
  potions[index] * spell >= success.
- The count of successful pairs for that spell is potions.Length - index.
- If no such index found, the count is 0.

Time Complexity: O(n log m) where n = spells.Length and m = potions.Length
Space Complexity: O(n) for the result array.
*/

public class Solution {
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success) {
        int n = spells.Length;
        int m = potions.Length;
        int[] pairs = new int[n];

        Array.Sort(potions);

        for (int i = 0; i < n; i++) {
            int idx = BinarySearch(spells[i], potions, success);
            pairs[i] = idx == -1 ? 0 : m - idx;
        }
        return pairs;
    }

    private int BinarySearch(int spell, int[] potions, long success) {
        int l = 0, r = potions.Length - 1;
        int res = -1;
        while (l <= r) {
            int mid = l + (r - l) / 2;
            long product = (long)potions[mid] * spell;
            if (product >= success) {
                res = mid;
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }
        return res;
    }
}
