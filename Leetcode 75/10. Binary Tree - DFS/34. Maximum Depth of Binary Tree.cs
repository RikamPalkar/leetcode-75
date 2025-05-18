/*
Leetcode 104. Maximum Depth of Binary Tree  
Topic: Binary Tree, DFS, Recursion

Approach:
- We use a Depth-First Search (DFS) strategy with recursion.
- For each node, compute the max depth of the left and right subtrees.
- The max depth at a node is the greater of the two subtree depths plus one (for the current node).
- Base case: if the node is null, depth is 0.

Time Complexity: O(n) — Each node is visited once.  
Space Complexity: O(h) — Call stack size depends on tree height (h), worst case O(n) if unbalanced.
*/

public class Solution {
    public int MaxDepth(TreeNode root) {
        return Helper(root);
    }

    private int Helper(TreeNode root) {
        if (root == null) return 0; // base case: null node contributes 0 depth
        int leftDepth = Helper(root.left);
        int rightDepth = Helper(root.right);
        return Math.Max(leftDepth, rightDepth) + 1;
    }
}
