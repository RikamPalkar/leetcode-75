/*
Leetcode 17. Letter Combinations of a Phone Number
Topic: Backtracking

Approach:
- Use a dictionary to map digits to corresponding letters.
- Use backtracking to build all possible combinations:
  - At each step, append each letter for the current digit and recurse for next digit.
- Stop recursion when the current index equals the length of input digits.
- Collect all combinations in a result list.

Time Complexity: O(3^n * 4^m), where n and m are counts of digits mapped to 3 and 4 letters.
Space Complexity: O(n) for recursion stack + O(number_of_combinations) for output.
*/

public class Solution
{
    private readonly Dictionary<char, string> map = new() {
        {'2', "abc"},
        {'3', "def"},
        {'4', "ghi"},
        {'5', "jkl"},
        {'6', "mno"},
        {'7', "pqrs"},
        {'8', "tuv"},
        {'9', "wxyz"}
    };

    private List<string> res = new List<string>();

    public IList<string> LetterCombinations(string digits)
    {
        if (string.IsNullOrEmpty(digits)) return res;

        Backtrack(0, digits, string.Empty);
        return res;
    }

    private void Backtrack(int index, string digits, string current)
    {
        if (index == digits.Length)
        {
            res.Add(current);
            return;
        }

        string letters = map[digits[index]];
        foreach (char ch in letters)
        {
            Backtrack(index + 1, digits, current + ch);
        }
    }
}
