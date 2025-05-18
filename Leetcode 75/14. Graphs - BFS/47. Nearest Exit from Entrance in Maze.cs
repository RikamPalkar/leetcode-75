/*
Leetcode 1926. Nearest Exit from Entrance in Maze  
Topic: BFS, Graph traversal, Matrix

Approach:
- Use BFS starting from the entrance cell.
- Mark entrance as visited to avoid revisiting.
- For each level in BFS, explore all neighbors (up, down, left, right) that are empty cells '.'.
- If a neighbor is at the border (except the entrance itself), return current step count as shortest path.
- If no exit found after BFS completion, return -1.

Time Complexity: O(m*n) — each cell visited at most once.  
Space Complexity: O(m*n) — for queue and visited markings.
*/

public class Solution {
    public int NearestExit(char[][] maze, int[] entrance) 
    {   
        int entryRow = entrance[0];    
        int entryCol = entrance[1];
        maze[entryRow][entryCol] = '+'; // mark entrance as visited

        var q = new Queue<(int row, int col)>();
        q.Enqueue((entryRow, entryCol));
        int steps = 0;

        int[][] directions = new int[][] { new int[]{1,0}, new int[]{0,1}, new int[]{-1,0}, new int[]{0,-1} };

        while(q.Count > 0){
            int levelSize = q.Count;
            steps++;
            for(int i = 0; i < levelSize; i++){
                var (currRow, currCol) = q.Dequeue();

                foreach(var dir in directions){
                    int nextRow = currRow + dir[0];
                    int nextCol = currCol + dir[1];

                    // Skip invalid or visited cells
                    if(nextRow < 0 || nextCol < 0 || nextRow >= maze.Length || nextCol >= maze[0].Length)
                        continue;
                    if(maze[nextRow][nextCol] == '+')
                        continue;

                    // Check if next cell is exit (on border but not entrance)
                    if(nextRow == 0 || nextCol == 0 || nextRow == maze.Length - 1 || nextCol == maze[0].Length - 1)
                        return steps;

                    maze[nextRow][nextCol] = '+'; // mark visited
                    q.Enqueue((nextRow, nextCol));
                }
            }
        }
        return -1; // no exit found
    }
}
