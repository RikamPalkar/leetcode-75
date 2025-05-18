/*
Leetcode 450. Delete Node in a BST  
Topic: Binary Search Tree, Recursion

Approach:
- Recursively find the node with the key.
- If key < node.val, go left; if key > node.val, go right.
- Once found:
  - If node has no children, return null.
  - If node has one child, return that child.
  - If node has two children:
    - Find the maximum node in left subtree (inorder predecessor).
    - Replace current node's value with predecessor's value.
    - Delete the predecessor node from left subtree.
- Return updated root.

Time Complexity: O(h) — h is height of the tree.  
Space Complexity: O(h) — recursion stack.
*/

public class Solution {
    public TreeNode DeleteNode(TreeNode root, int key) {
        if (root == null) return null;

        if (key < root.val) {
            root.left = DeleteNode(root.left, key);
        } 
        else if (key > root.val) {
            root.right = DeleteNode(root.right, key);
        } 
        else {
            // Node to delete found
            if (root.left == null && root.right == null) {
                return null;
            }
            if (root.left == null) return root.right;
            if (root.right == null) return root.left;

            // Node with two children
            TreeNode leftMaxNode = FindLeftMax(root.left);
            root.val = leftMaxNode.val;
            root.left = DeleteNode(root.left, leftMaxNode.val);
        }
        return root;
    }

    private TreeNode FindLeftMax(TreeNode node) {
        while (node.right != null) {
            node = node.right;
        }
        return node;
    }
}
