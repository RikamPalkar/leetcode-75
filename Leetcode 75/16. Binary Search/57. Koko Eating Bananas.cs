/*
Leetcode 875. Koko Eating Bananas  
Topic: Binary Search

Approach:
- Use binary search on the possible eating speed k from 1 to max(piles).
- For each mid (candidate speed), check if Koko can finish all piles within h hours:
  - Calculate hours needed: sum of ceil(pile / k) for each pile.
- If Koko can finish, try to lower speed (r = mid).
- Else increase speed (l = mid + 1).
- Return the minimum k that satisfies the condition.

Time Complexity: O(n log m), where n = number of piles, m = max pile size
Space Complexity: O(1)
*/

public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {  
        int l = 1;
        int r = piles.Max();

        while (l < r) {
            int mid = (l + r) / 2;
            if (CanFinish(piles, mid, h)) {
                r = mid;
            } else {
                l = mid + 1;
            }
        }
        return l;
    }

    private bool CanFinish(int[] piles, int k, int h) {
        int hoursNeeded = 0;
        for (int i = 0; i < piles.Length; i++) {
            hoursNeeded += (piles[i] + k - 1) / k;  // ceiling division without float
        }
        return hoursNeeded <= h;
    }
}
