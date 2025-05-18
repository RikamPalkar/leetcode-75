/*
Leetcode 1372. Longest ZigZag Path in a Binary Tree  
Topic: Binary Tree, DFS, Recursion

Approach:
- We want the longest zigzag path, alternating directions (left, right, left, ...).
- Use DFS to explore two scenarios at each node:
  1. Current direction is left → next step must go right child.
  2. Current direction is right → next step must go left child.
- Track path length and update a global max variable.
- Start DFS from root twice: once assuming next step is left, once assuming right.

Time Complexity: O(n) — visit each node once.  
Space Complexity: O(h) — recursion stack depth.
*/

public class Solution {
    int max = 0;
    
    public int LongestZigZag(TreeNode root) {
        DFS(root, true, 0);  // Start assuming next step is left
        DFS(root, false, 0); // Start assuming next step is right
        return max;
    }

    private void DFS(TreeNode node, bool isLeft, int path) {
        if (node == null) return;

        max = Math.Max(max, path);

        if (isLeft) {
            // Current direction is left, so next move must be to right child (path + 1)
            // Reset path to 1 when moving to left child since direction changes
            DFS(node.left, true, 1);
            DFS(node.right, false, path + 1);
        } else {
            // Current direction is right, so next move must be to left child (path + 1)
            DFS(node.left, true, path + 1);
            DFS(node.right, false, 1);
        }
    }
}
