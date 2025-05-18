/*
Leetcode 1137. N-th Tribonacci Number
Topic: Dynamic Programming, Recursion with Memoization

Approach (Iterative):
- Use three variables to track T0, T1, T2.
- Iteratively compute subsequent terms up to Tn.

Time Complexity: O(n)
Space Complexity: O(1)

Approach (Recursion with Memoization):
- Use a dictionary to memoize results for overlapping subproblems.
- Recursively compute Tn using Tn-1, Tn-2, Tn-3.
- Return memoized value if already computed.

Time Complexity: O(n)
Space Complexity: O(n)
*/

public class Solution {
    // Iterative approach
    public int Tribonacci(int n) {  
        if (n == 0) return 0;
        if (n == 1 || n == 2) return 1;

        int first = 0, second = 1, third = 1, result = 0;
        for (int i = 3; i <= n; i++) {
            result = first + second + third;
            first = second; 
            second = third;
            third = result;
        }
        return result;
    }
}

// Recursive approach with memoization
public class SolutionRecursive {
    public int Tribonacci(int n) {  
        var memo = new Dictionary<int, int>();
        return Helper(n, memo);
    }

    private int Helper(int n, Dictionary<int, int> memo) {
        if (memo.ContainsKey(n)) return memo[n];
        if (n == 0) return 0;
        if (n == 1 || n == 2) return 1;

        memo[n] = Helper(n - 1, memo) + Helper(n - 2, memo) + Helper(n - 3, memo);
        return memo[n];
    }
}
