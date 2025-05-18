/*
Leetcode 872. Leaf-Similar Trees  
Topic: Binary Tree, DFS

Approach:
- The problem asks whether the leaf nodes (from left to right) of two binary trees are identical.
- We:
  1. Traverse each tree using DFS and collect leaf values into lists.
  2. Use `SequenceEqual` to compare the two lists of leaf values.

Time Complexity: O(n + m) — Where n and m are the number of nodes in each tree.  
Space Complexity: O(h1 + h2 + l) — h1/h2 are recursion depths, and l is the number of leaves collected.
*/

public class Solution {
    public bool LeafSimilar(TreeNode root1, TreeNode root2) {
        List<int> first = new();
        List<int> second = new();

        CollectLeaves(root1, first);
        CollectLeaves(root2, second);

        return first.SequenceEqual(second);
    }

    private void CollectLeaves(TreeNode node, List<int> leafs) {
        if (node == null) return;
        if (node.left == null && node.right == null) {
            leafs.Add(node.val);
            return;
        }
        CollectLeaves(node.left, leafs);
        CollectLeaves(node.right, leafs);
    }
}
