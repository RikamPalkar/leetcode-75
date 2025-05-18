/*
Leetcode 216. Combination Sum III
Topic: Backtracking

Approach:
- Use backtracking to generate combinations of numbers 1 to 9.
- Keep track of current combination and remaining target sum.
- Stop exploring path if target < 0 or combination size > k.
- If target == 0 and combination size == k, add the combination to result.
- Increment start index to avoid reusing numbers.

Time Complexity:
- O(9 choose k) combinations possible, with pruning.

Space Complexity:
- O(k) recursion stack and temporary combination list.
*/

public class Solution {
    public IList<IList<int>> CombinationSum3(int k, int n) {
        var combos = new List<IList<int>>();
        Backtrack(1, k, n, new List<int>(), combos);
        return combos;
    }

    private void Backtrack(int start, int k, int target, List<int> combo, List<IList<int>> combos)
    {
        if (target == 0 && combo.Count == k) {
            combos.Add(new List<int>(combo));
            return;
        }

        if (target < 0 || combo.Count > k) return;

        for (int i = start; i <= 9; i++) {
            combo.Add(i);
            Backtrack(i + 1, k, target - i, combo, combos);
            combo.RemoveAt(combo.Count - 1);
        }
    }
}
