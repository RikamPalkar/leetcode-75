/*
Leetcode 199. Binary Tree Right Side View  
Topic: Binary Tree, BFS, Level Order Traversal

Approach:
- Use BFS to traverse the tree level-by-level.
- For each level, enqueue all nodes.
- Add the value of the last node in the current level to the result (this is the rightmost node).
- Return the collected values after BFS completes.

Time Complexity: O(n) — Each node is visited once.  
Space Complexity: O(w) — Maximum width of the tree (queue size).
*/

public class Solution {
    public IList<int> RightSideView(TreeNode root) {
        List<int> res = new List<int>();
        if (root == null) return res;

        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count > 0) {
            int level = q.Count;

            for (int i = 0; i < level; i++) {
                TreeNode curr = q.Dequeue();

                // If it's the last node in this level, add to result
                if (i == level - 1) {
                    res.Add(curr.val);
                }

                if (curr.left != null) q.Enqueue(curr.left);
                if (curr.right != null) q.Enqueue(curr.right);
            }
        }

        return res;
    }
}
