/*
Leetcode 452. Minimum Number of Arrows to Burst Balloons  
Topic: Greedy, Intervals

Approach:
- Sort the balloons by their end coordinate.
- Initialize arrowPosition at the end of the first balloon.
- Iterate through balloons:
  - If a balloon starts after the arrowPosition, shoot a new arrow at this balloon's end.
  - Otherwise, current arrow bursts this balloon too.
- Return the total number of arrows shot.

Time Complexity:
- Sorting: O(n log n), where n is number of balloons.
- Single pass through balloons: O(n).
Space Complexity:
- O(1) extra space (sorting done in place).
*/

public class Solution {
    public int FindMinArrowShots(int[][] points) {
        if(points.Length == 0) return 0;
        
        // Sort balloons by their ending coordinate
        Array.Sort(points, (x, y) => x[1].CompareTo(y[1]));
        
        int arrowPosition = points[0][1];  // Position of first arrow (end of first balloon)
        int count = 1;                     // At least one arrow needed
        
        for(int i = 1; i < points.Length; i++){
            // If balloon starts after the current arrow position, need another arrow
            if(points[i][0] > arrowPosition){
                count++;
                arrowPosition = points[i][1]; // Shoot new arrow at the end of this balloon
            }
            // Else, balloon is burst by current arrow; no action needed
        }
        
        return count;
    }
}
