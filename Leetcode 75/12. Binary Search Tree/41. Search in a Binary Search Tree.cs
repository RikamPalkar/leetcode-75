/*
Leetcode 700. Search in a Binary Search Tree  
Topic: Binary Search Tree, Recursion

Approach:
- Utilize BST property: left subtree has smaller values, right subtree has larger values.
- Recursively compare val with current node's value:
  - If equal, return current node.
  - If val is less, search left subtree.
  - If val is greater, search right subtree.
- Return null if node not found.

Time Complexity: O(h) — h is the height of the tree, worst O(n) in skewed tree.  
Space Complexity: O(h) — recursion stack space.
*/

public class Solution {
    public TreeNode SearchBST(TreeNode root, int val) {
        if (root == null) return null;
        if (root.val == val) return root;
        else if (val < root.val)
            return SearchBST(root.left, val);
        else
            return SearchBST(root.right, val);
    }
}
