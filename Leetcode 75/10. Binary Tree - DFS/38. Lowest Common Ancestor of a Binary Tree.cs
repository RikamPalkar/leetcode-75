/*
Leetcode 236. Lowest Common Ancestor of a Binary Tree  
Topic: Binary Tree, Recursion

Approach:
- Base case: if the current node is null, or matches p or q, return it.
- Recursively find LCA in left and right subtrees.
- If both left and right return non-null, current node is LCA.
- Otherwise, return the non-null result from either side.
- This works because:
  * If both p and q are in different subtrees, current node is LCA.
  * If both are in same subtree, LCA lies deeper in that subtree.
  * If current node is p or q, it could be the ancestor itself.

Time Complexity: O(n) — Visit each node once.  
Space Complexity: O(h) — Recursion stack.
*/

public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null || root == p || root == q) {
            return root;
        }

        TreeNode left = LowestCommonAncestor(root.left, p, q);
        TreeNode right = LowestCommonAncestor(root.right, p, q);

        if (left != null && right != null) {
            return root;
        }

        return left ?? right;
    }
}
