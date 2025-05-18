/*
Leetcode 437. Path Sum III  
Topic: Binary Tree, DFS, Backtracking

Approach:
- The problem asks for number of paths that sum to targetSum.
- Paths can start anywhere and go downward (parent → child).
- For each node:
  1. Count all paths starting from this node with sum == targetSum using a helper.
  2. Recursively do the same for left and right subtrees.
- Combine results for total count.

Time Complexity: O(n^2) in worst case — For each node, explore paths downward.  
Space Complexity: O(h) — Recursion stack depth.
*/

public class Solution {
    public int PathSum(TreeNode root, int targetSum) {
        return DFS(root, targetSum);
    }

    private int DFS(TreeNode node, int targetSum) {
        if (node == null) return 0;
        // Count paths starting at current node + paths in left subtree + paths in right subtree
        return CountPathsFromNode(node, 0, targetSum) + DFS(node.left, targetSum) + DFS(node.right, targetSum);
    }

    private int CountPathsFromNode(TreeNode node, long currentSum, long targetSum) {
        if (node == null) return 0;

        currentSum += node.val;
        int count = currentSum == targetSum ? 1 : 0;

        count += CountPathsFromNode(node.left, currentSum, targetSum);
        count += CountPathsFromNode(node.right, currentSum, targetSum);

        return count;
    }
}
