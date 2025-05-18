/*
Leetcode 1466. Reorder Routes to Make All Paths Lead to the City Zero  
Topic: Graph, DFS, Tree

Approach:
- Represent the graph as an undirected adjacency list for easy traversal.
- Keep a HashSet of directed edges (original directions).
- Start DFS from city 0 (capital).
- For each neighboring city:
  - If the edge direction is from current city to neighbor, we must reverse it, so increment count.
  - Recursively DFS into unvisited neighbors.
- Sum all needed reversals to ensure all paths lead to city 0.

Time Complexity: O(n) — traverse all nodes and edges once.  
Space Complexity: O(n) — adjacency list and recursion stack.
*/

/*
    graph = {
            0: [1, 4],
            1: [0, 3],
            2: [3],
            3: [1, 2],
            4: [0, 5],
            5: [4]
        }
*/

public class Solution
{
    public int MinReorder(int n, int[][] connections)
    {
        Dictionary<int, List<int>> graph = new();
        HashSet<(int, int)> directedEdges = new();
        foreach (var edge in connections)
        {
            int from = edge[0];
            int to = edge[1];
            if (!graph.ContainsKey(from)) graph[from] = new List<int>();
            if (!graph.ContainsKey(to)) graph[to] = new List<int>();

            graph[from].Add(to);
            graph[to].Add(from);
            directedEdges.Add((from, to));
        }

        HashSet<int> visited = new();
        return DFS(0, visited, graph, directedEdges);
    }

    private int DFS(int currNode, HashSet<int> visited, Dictionary<int, List<int>> graph, HashSet<(int, int)> directedEdges)
    {
        visited.Add(currNode);
        int count = 0;
        foreach (var neighbour in graph[currNode])
        {
            if (!visited.Contains(neighbour))
            {
                // If edge is originally directed away from currNode, we need to reverse it
                if (directedEdges.Contains((currNode, neighbour)))
                {
                    count++;
                }
                count += DFS(neighbour, visited, graph, directedEdges);
            }
        }
        return count;
    }
}
