/*
Leetcode 1268. Search Suggestions System  
Topic: Trie, DFS, String

Approach:
- Sort products lexicographically to get suggestions in order.
- Build a Trie from the sorted products.
- For each prefix of the searchWord, traverse the Trie.
- Use DFS from the Trie node corresponding to the prefix to find up to 3 suggestions.
- If prefix not found, fill remaining with empty lists.

Time Complexity:
- Building Trie: O(n * m), n = number of products, m = average length of product.
- Querying each prefix: O(m * 26^k), where k is max suggestions (3), effectively O(m).
Space Complexity:
- O(n * m) for Trie storage.
*/

public class Solution {
    TrieNode root;
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) {
        Array.Sort(products); // lexicographic order
        root = new();
        foreach(string product in products){
            Insert(product);
        }
        return Find(searchWord);
    }

    // Build Trie
    private void Insert(string product){
        TrieNode current = root;
        foreach(char ch in product){
            int index = ch - 'a';
            if(current.Children[index] == null)
            {
                current.Children[index] = new();
            }
            current = current.Children[index];
        }
        current.IsEnd = true;
    }

    private IList<IList<string>> Find(string product){
        TrieNode current = root;
        StringBuilder prefix = new();
        IList<IList<string>> res = [];

        foreach(char ch in product){
            prefix.Append(ch);

            int index =  ch - 'a';

            if(current.Children[index] != null){
                current = current.Children[index];
            }
            else
            {
                // No further prefix match, fill remaining with empty lists
                while(res.Count < product.Length){
                    res.Add(new List<string>());
                }
                break;
            }

            List<string> suggestions = [];
            DFS(current, prefix, suggestions);
            res.Add(suggestions);
        }
        return res;
    }

    private void DFS(TrieNode root, StringBuilder prefix, List<string> suggestions)
    {
        if(suggestions.Count == 3) return; // Only need top 3 suggestions
        if(root.IsEnd) suggestions.Add(prefix.ToString());

        int i = 0;
        foreach(var curr in root.Children){
            if(curr != null){
                char nextChar = (char)(i + 'a'); // Add next character
                prefix.Append(nextChar);
                DFS(curr,prefix, suggestions);
                prefix.Length--; // Backtrack
            }
            i++;
        }
    }
}

public class TrieNode{
    public TrieNode[] Children = new TrieNode[26];
    public bool IsEnd =  false;
}