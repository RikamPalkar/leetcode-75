/*
Leetcode 1431. Kids With the Greatest Number of Candies  
Topic: Array, Greedy

Approach:
- Find the maximum number of candies any kid currently has.
- For each kid, add extraCandies to their current amount and compare with the max.
- If the sum is greater than or equal to the max, mark true; otherwise, false.
- Collect results in a list and return it.

Example:
Input: candies = [2, 3, 5, 1, 3], extraCandies = 3  
Output: [true, true, true, false, true]

Maximum candy count: 5

Each kid with extra candies:
2 + 3 = 5 → true  
3 + 3 = 6 → true  
5 + 3 = 8 → true  
1 + 3 = 4 → false  
3 + 3 = 6 → true

Time Complexity: O(n)  
- Where n = candies.Length  
- We traverse the array twice: once to find max and once to build the result list.

Space Complexity: O(n)  
- We create a list of booleans of size n to store the results.
*/

public class Solution {
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies) {
        int max = candies.Max();
        IList<bool> res = [];

        for (int i = 0; i < candies.Length; i++) {
            res.Add(candies[i] + extraCandies >= max);
        }

        return res;
    }
}
