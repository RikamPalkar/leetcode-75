/*
Leetcode 208. Implement Trie (Prefix Tree)  
Topic: Trie, Data Structure

Approach:
- Use a TrieNode class with an array of 26 children (for each lowercase letter).
- Each TrieNode has a boolean to mark the end of a word.
- Insert: Traverse or create nodes for each character.
- Search: Traverse nodes, return true if node exists and IsEnd is true.
- StartsWith: Traverse nodes, return true if traversal succeeds.

Time Complexity:
- Insert, Search, StartsWith: O(m), where m is length of the word/prefix.
Space Complexity:
- O(m * n) for n inserted words of max length m (worst case).
*/

public class Trie {
    TrieNode root;

    public Trie() {
        root = new TrieNode();
    }
    
    public void Insert(string word) {
       TrieNode currentNode = root;
       foreach(char ch in word){
            int index = ch - 'a';
            if(currentNode.children[index] == null)
                currentNode.children[index] = new TrieNode();
            currentNode = currentNode.children[index];
       }
       currentNode.IsEnd = true;
    }
    
    public bool Search(string word) {
       TrieNode node = Find(word);
       return node != null && node.IsEnd;
    }
    
    public bool StartsWith(string prefix) {
        TrieNode node = Find(prefix);
        return node != null;
    }

    private TrieNode Find(string word){
        TrieNode currentNode = root;
        foreach(char ch in word){
            int index = ch - 'a';
            if(currentNode.children[index] == null) return null;
            currentNode = currentNode.children[index];
        }
        return currentNode;
    }
}

public class TrieNode{
    public TrieNode[] children = new TrieNode[26];
    public bool IsEnd = false;
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
