/*
Leetcode 714. Best Time to Buy and Sell Stock with Transaction Fee  
Topic: Dynamic Programming, Greedy

Approach:
- Use two variables:
  - `cash`: max profit when **not holding** any stock.
  - `hold`: max profit when **holding** a stock.
- At each day:
  - Update `hold` as the max of:
    - previous `hold` (do nothing),
    - buy today (cash - prices[i])
  - Update `cash` as the max of:
    - previous `cash` (do nothing),
    - sell today (hold + prices[i] - fee)

Key Insight:
- Fee is paid only once per completed transaction (i.e., when selling).

Time Complexity: O(n)  
Space Complexity: O(1)
*/

public class Solution {
    public int MaxProfit(int[] prices, int fee) {
        if (prices.Length == 0) return 0;

        int cash = 0;               // Max profit when not holding stock
        int hold = -prices[0];      // Max profit when holding stock (bought on day 0)

        for (int i = 1; i < prices.Length; i++) {
            hold = Math.Max(hold, cash - prices[i]);               // Buy or hold
            cash = Math.Max(cash, hold + prices[i] - fee);         // Sell or hold
        }

        return cash; // Final profit should be when not holding any stock
    }
}
