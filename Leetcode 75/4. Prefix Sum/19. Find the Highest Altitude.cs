/*
Leetcode 1732. Find the Highest Altitude  
Topic: Array, Prefix Sum

Approach:
- The biker starts at altitude 0.
- Given gain array, each element represents the altitude gain from point i to i+1.
- Calculate the altitude at each point by cumulatively summing gains.
- Track the maximum altitude encountered during the trip.
- Return the highest altitude reached.

Example:
Input: gain = [-5,1,5,0,-7]
Output: 1
Explanation: Altitudes: [0, -5, -4, 1, 1, -6] → highest is 1.

Time Complexity: O(n)  
- Single pass to compute cumulative sums

Space Complexity: O(1)  
- Only variables used for running sum and max tracking
*/

public class Solution {
    public int LargestAltitude(int[] gain) {
        int highAlt = 0;
        int sum = 0;
        for (int i = 0; i < gain.Length; i++) {
            sum += gain[i];
            highAlt = Math.Max(highAlt, sum);
        }
        return highAlt;
    }
}
