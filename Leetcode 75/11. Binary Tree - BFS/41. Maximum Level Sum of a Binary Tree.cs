/*
Leetcode 1161. Maximum Level Sum of a Binary Tree  
Topic: Binary Tree, BFS, Level Order Traversal

Approach:
- Use BFS to traverse the tree level-by-level.
- Calculate the sum of node values at each level.
- Track the maximum sum and the corresponding level.
- Return the level with the maximum sum (smallest level in case of ties).

Time Complexity: O(n) — Each node visited once.  
Space Complexity: O(w) — Maximum width of the tree (queue size).
*/

public class Solution {
    public int MaxLevelSum(TreeNode root) {
        if (root == null) return 0;

        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        int maxLevel = 1;
        int currentLevel = 1;
        int maxSum = int.MinValue;

        while (q.Count > 0) {
            int levelSize = q.Count;
            int levelSum = 0;

            for (int i = 0; i < levelSize; i++) {
                TreeNode node = q.Dequeue();
                levelSum += node.val;

                if (node.left != null) q.Enqueue(node.left);
                if (node.right != null) q.Enqueue(node.right);
            }

            if (levelSum > maxSum) {
                maxSum = levelSum;
                maxLevel = currentLevel;
            }

            currentLevel++;
        }

        return maxLevel;
    }
}
