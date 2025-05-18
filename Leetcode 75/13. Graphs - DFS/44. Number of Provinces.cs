/*
Leetcode 547. Number of Provinces  
Topic: Union-Find, Graph, Disjoint Set

Approach:
- Use Union-Find data structure to group connected cities.
- Iterate over the isConnected matrix:
  - For every pair (i, j) where isConnected[i][j] == 1, union their sets.
- After all unions, count how many unique parents exist — this equals number of provinces.
- Union-Find operations ensure efficient merging and finding of connected components.

Time Complexity: O(n^2 * α(n)) — α is inverse Ackermann function, nearly constant.  
Space Complexity: O(n) — for Union-Find parent array.
*/

public class Solution 
{
    public int FindCircleNum(int[][] isConnected) 
    {
        UnionFind uf = new(isConnected.Length);
        for(int i = 0; i < isConnected.Length; i++){
            for(int j = 0; j < isConnected[i].Length; j++){
                if(isConnected[i][j] == 1)
                    uf.Union(i, j);
            }   
        }
        int count = 0;
        for (int i = 0; i < isConnected.Length; i++) {
            if (uf.Parents[i] == i) count++;
        }
        return count;
    }
}

public class UnionFind
{
    public int[] Parents;

    public UnionFind(int len)
    {
        Parents = new int[len];
        for(int i = 0; i < len; i++)
            Parents[i] = i;
    }

    public int Find(int x){
        if(Parents[x] == x) return x;
        return Parents[x] = Find(Parents[x]);
    }

    public void Union(int x, int y){
        int xParent = Find(x);
        int yParent = Find(y);

        if(xParent != yParent){
            Parents[xParent] = yParent;
        }
    }
}
