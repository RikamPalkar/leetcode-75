/*
Leetcode 901. Online Stock Span  
Topic: Stack, Monotonic Stack

Approach:
- Use a stack to store pairs of (span, price).
- For each new price:
  - Initialize span = 1 (today counts as 1 day).
  - While the stack is not empty and top price ≤ current price:
    - Pop the top and add its span to the current span (merging spans).
  - Push the (span, price) pair onto the stack.
- Return the current span.

This works because the stack maintains prices in decreasing order, 
and spans accumulate consecutive days where the price was less or equal.

Time Complexity:
- O(n) total for n calls to Next, since each element pushed and popped at most once.
Space Complexity:
- O(n) for the stack in worst case (strictly decreasing prices).
*/

public class StockSpanner {
    Stack<(int span, int price)> mono;
    public StockSpanner() {
        mono = new();
    }
    
    public int Next(int price) {
        int span = 1;
        // Merge spans of prices less or equal to current price
        while(mono.Count > 0 && price >= mono.Peek().price){
            span += mono.Pop().span;
        }
        mono.Push((span, price));
        return span;
    }
}

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */
