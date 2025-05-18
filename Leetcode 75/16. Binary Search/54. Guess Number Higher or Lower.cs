/*
Leetcode 374. Guess Number Higher or Lower  
Topic: Binary Search

Approach:
- Use binary search on the range [1, n].
- Call the guess API with the midpoint.
- If guess(mid) == 0, return mid.
- If guess(mid) == -1, search the left half (r = mid - 1).
- If guess(mid) == 1, search the right half (l = mid + 1).

Time Complexity: O(log n) due to binary search.
Space Complexity: O(1).
*/

public class Solution : GuessGame {
    public int GuessNumber(int n) {
        int l = 1;
        int r = n;

        while (l <= r) {
            int mid = l + (r - l) / 2;
            int res = guess(mid);
            if (res == 0) return mid;
            else if (res == -1) r = mid - 1;
            else l = mid + 1;
        }
        return -1; // theoretically unreachable
    }
}
