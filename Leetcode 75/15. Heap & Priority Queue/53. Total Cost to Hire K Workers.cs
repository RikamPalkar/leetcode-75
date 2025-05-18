/*
Leetcode 462. Total Cost to Hire K Workers  
Topic: Priority Queue, Greedy, Two Pointers

Approach:
- Use two min-heaps (priority queues) to track the lowest cost workers from the front candidates and back candidates.
- Initialize two pointers: 
    l pointing to the next candidate after the front heap, 
    r pointing to the next candidate before the back heap.
- For k hiring rounds:
  - Compare the smallest costs from both heaps.
  - Hire the worker with the smaller cost (tie-break by front heap).
  - Replenish the heap from the next candidate if pointers haven't crossed.
- Sum the costs of hired workers.

Time Complexity:
- O(k log candidates) due to heap operations.
Space Complexity: O(candidates) for heaps.
*/

public class Solution
{
    public long TotalCost(int[] costs, int k, int candidates)
    {
        int len = costs.Length;
        int l = candidates;               // next index to add to front heap
        int r = len - 1 - candidates;    // next index to add to back heap

        PriorityQueue<int, int> front = new();
        PriorityQueue<int, int> back = new();

        // Add initial candidates to front heap
        for (int i = 0; i < candidates && i < len; i++)
        {
            front.Enqueue(costs[i], costs[i]);
        }

        // Add initial candidates to back heap, avoid overlap with front
        for (int i = Math.Max(candidates, len - candidates); i < len; i++)
        {
            back.Enqueue(costs[i], costs[i]);
        }

        long res = 0;

        for (int i = 0; i < k; i++)
        {
            if (back.Count == 0 || (front.Count > 0 && front.Peek() <= back.Peek()))
            {
                res += front.Dequeue();

                if (l <= r)
                {
                    front.Enqueue(costs[l], costs[l]);
                    l++;
                }
            }
            else
            {
                res += back.Dequeue();

                if (l <= r)
                {
                    back.Enqueue(costs[r], costs[r]);
                    r--;
                }
            }
        }

        return res;
    }
}
