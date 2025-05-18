/*
Leetcode 435. Non-overlapping Intervals  
Topic: Greedy, Intervals

Approach:
- Sort intervals by their start time.
- Iterate through intervals, comparing current with the previously kept interval.
- If they overlap (current start < previous end), increment removal count.
- To minimize removals, keep the interval that ends sooner (greedy choice).
- This maximizes space for upcoming intervals.

Time Complexity:
- Sorting: O(n log n), where n is number of intervals.
- Single pass through intervals: O(n).
Space Complexity:
- O(1) extra space (sorting done in place).
*/

public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        
        // Sort intervals by start time
        Array.Sort(intervals, (x, y) => x[0] - y[0]);
        
        int count = 0;               // Number of intervals removed
        int[] previous = intervals[0]; // Track the interval we are keeping
        
        for (int i = 1; i < intervals.Length; i++) {
            int[] current = intervals[i];
            
            // If current interval starts before previous ends, overlap exists
            if (current[0] < previous[1]) {
                count++; // Need to remove one interval
                
                // Keep the interval that ends sooner to maximize space for future intervals
                if (current[1] < previous[1]) {
                    previous = current;
                }
            } else {
                // No overlap, move forward
                previous = current;
            }
        }
        
        return count;
    }
}

/*
Why Keeping the One That Ends Sooner Is Better

Consider overlapping intervals:
    A: [1, 10]
    B: [2, 3]

If you keep A, you block future intervals until 10.
If you keep B, which ends earlier, you allow more future intervals to fit.

This greedy choice minimizes removals.
*/
