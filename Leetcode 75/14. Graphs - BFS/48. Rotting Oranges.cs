/*
Leetcode 994. Rotting Oranges  
Topic: BFS, Matrix traversal

Approach:
- Use multi-source BFS starting from all initially rotten oranges.
- Track the count of fresh oranges.
- Each minute, rot adjacent fresh oranges and enqueue them.
- Increase minutes counter only if any fresh orange got rotten in this iteration.
- If fresh oranges remain after BFS, return -1; else return minutes.

Time Complexity: O(m*n) — each cell visited at most once.  
Space Complexity: O(m*n) — queue can hold all cells in worst case.
*/

public class Solution {
    public int OrangesRotting(int[][] grid) {
        
        int rows = grid.Length;
        int cols = grid[0].Length;
        int freshCount = 0;
        var q = new Queue<(int row, int col)>();

        // Initialize queue with all rotten oranges and count fresh oranges
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (grid[r][c] == 2) q.Enqueue((r, c));
                else if (grid[r][c] == 1) freshCount++;
            }
        }

        int[][] directions = new int[][] { new int[]{1,0}, new int[]{-1,0}, new int[]{0,1}, new int[]{0,-1} };
        int minutes = 0;

        // BFS to rot adjacent fresh oranges
        while (q.Count > 0) {
            int levelSize = q.Count;
            bool rottenThisRound = false;

            for (int i = 0; i < levelSize; i++) {
                var (row, col) = q.Dequeue();

                foreach (var dir in directions) {
                    int newRow = row + dir[0];
                    int newCol = col + dir[1];

                    if (newRow < 0 || newCol < 0 || newRow >= rows || newCol >= cols) continue;
                    if (grid[newRow][newCol] != 1) continue; // skip if not fresh

                    grid[newRow][newCol] = 2; // rot the fresh orange
                    freshCount--;
                    rottenThisRound = true;
                    q.Enqueue((newRow, newCol));
                }
            }
            if (rottenThisRound) minutes++;
        }

        return freshCount == 0 ? minutes : -1;
    }
}
