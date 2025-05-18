/*
Leetcode 1448. Count Good Nodes in Binary Tree  
Topic: Binary Tree, DFS

Approach:
- A node is "good" if no node along the path from root to that node has a greater value.
- Use DFS traversal passing down the max value seen so far.
- If current node's value >= max so far, increment count.
- Recursively count good nodes in left and right subtrees with updated max value.

Time Complexity: O(n) — Visit each node once.  
Space Complexity: O(h) — Recursion stack depth, where h is tree height.
*/

public class Solution {
    public int GoodNodes(TreeNode root) {
        return CountGoodNodes(root, root.val);
    }

    private int CountGoodNodes(TreeNode node, int maxSoFar) {
        if (node == null) return 0;

        int count = 0;
        if (node.val >= maxSoFar) count = 1;

        maxSoFar = Math.Max(maxSoFar, node.val);
        count += CountGoodNodes(node.left, maxSoFar);
        count += CountGoodNodes(node.right, maxSoFar);

        return count;
    }
}
