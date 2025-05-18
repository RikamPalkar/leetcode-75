/*
Leetcode 841. Keys and Rooms  
Topic: Graph traversal, DFS

Approach:
- Treat rooms as nodes in a graph where edges are keys pointing to other rooms.
- Use DFS starting from room 0 (which is initially unlocked).
- Mark visited rooms in a boolean array to avoid revisits.
- Recursively visit all rooms accessible through keys.
- After DFS completes, check if all rooms are visited.

Time Complexity: O(V + E) — V is number of rooms, E is total keys across rooms.  
Space Complexity: O(V) — recursion stack and visited array.
*/

public class Solution {
    public bool CanVisitAllRooms(IList<IList<int>> rooms) {
        bool[] visited = new bool[rooms.Count];
        DFS(rooms, 0, visited);
        return visited.All(v => v);
    }

    private void DFS(IList<IList<int>> rooms, int room, bool[] visited) {
        visited[room] = true;
        foreach (int key in rooms[room]) {
            if (!visited[key]) {
                DFS(rooms, key, visited);
            }
        }
    }
}
