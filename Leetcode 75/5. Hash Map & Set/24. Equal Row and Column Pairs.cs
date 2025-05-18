/*
Leetcode 2352. Equal Row and Column Pairs
Topic: Array, Hash Table

Approach:
- Extract all rows as arrays or lists and store their counts in a dictionary.
- For each column, extract the column array and check how many times it appears in the row dictionary.
- Sum all counts for the final answer.

Why this works:
- We want to find pairs where a row equals a column.
- Using a dictionary to count occurrences of rows, we can quickly lookup matching columns.

Time Complexity: O(n^2) where n is grid size  
Space Complexity: O(n^2) in the worst case to store all rows

Example:
grid = [
  [3,2,1],
  [1,7,6],
  [2,7,7]
]
- Rows as keys: [3,2,1], [1,7,6], [2,7,7]
- Columns: [3,1,2], [2,7,7], [1,6,7]
- Only row 2 equals column 1, so answer is 1.
*/

public class Solution {
    public int EqualPairs(int[][] grid) {
        int n = grid.Length;
        var rowCount = new Dictionary<string, int>();
        
        // Store rows as string keys in dictionary with counts
        for (int i = 0; i < n; i++) {
            var rowKey = string.Join(",", grid[i]);
            rowCount[rowKey] = rowCount.GetValueOrDefault(rowKey) + 1;
        }
        
        int result = 0;
        
        // Check each column against row dictionary
        for (int col = 0; col < n; col++) {
            var colArr = new int[n];
            for (int row = 0; row < n; row++) {
                colArr[row] = grid[row][col];
            }
            var colKey = string.Join(",", colArr);
            if (rowCount.ContainsKey(colKey)) {
                result += rowCount[colKey];
            }
        }
        
        return result;
    }
}
