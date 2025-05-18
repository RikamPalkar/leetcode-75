/*
Leetcode 399. Evaluate Division  
Topic: Graph, DFS, Backtracking

Approach:
- Model equations as a weighted directed graph: variable -> neighbors with edge weight representing division value.
- Add both directions: A -> B with weight values[i], and B -> A with weight 1/values[i].
- For each query (Cj/Dj), perform DFS from numerator Cj to denominator Dj:
  - Accumulate product of edge weights along the path.
  - Return product if path exists, else -1.0.
- Handle cases where variables don't exist or numerator equals denominator.

Time Complexity: O(E + Q * V) — E is number of equations, Q is queries, V is variables.  
Space Complexity: O(V + E) — for graph and recursion stack.
*/

public class Solution
{
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        var graph = new Dictionary<string, List<(string neighbour, double weight)>>();
        int i = 0;
        foreach (var equation in equations)
        {
            string from = equation[0];
            string to = equation[1];

            if (!graph.ContainsKey(from)) graph[from] = new List<(string, double)>();
            if (!graph.ContainsKey(to)) graph[to] = new List<(string, double)>();
            
            double currValue = values[i++];
            graph[from].Add((to, currValue));
            graph[to].Add((from, 1.0 / currValue));
        }

        List<double> res = new List<double>();
        foreach (var query in queries)
        {
            string numerator = query[0];
            string denominator = query[1];
            var visited = new HashSet<string>();

            if (!graph.ContainsKey(numerator) || !graph.ContainsKey(denominator))
                res.Add(-1.0);
            else if (numerator == denominator)
                res.Add(1.0);
            else
                res.Add(DFS(graph, visited, numerator, denominator, 1.0));
        }
        return res.ToArray();
    }

    private double DFS(Dictionary<string, List<(string neighbour, double weight)>> graph, HashSet<string> visited,
                       string curr, string end, double accWeight)
    {
        if (curr == end) return accWeight;
        visited.Add(curr);
        foreach (var (neighbour, weight) in graph[curr])
        {
            if (!visited.Contains(neighbour))
            {
                double product = accWeight * weight;
                double res = DFS(graph, visited, neighbour, end, product);
                if (res != -1.0) return res; // early exit if valid path found
            }
        }
        return -1.0; // no valid path
    }
}
