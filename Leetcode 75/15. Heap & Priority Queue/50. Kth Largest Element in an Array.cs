/*
Leetcode 215. Kth Largest Element in an Array  
Topic: Heap, Priority Queue

Approach:
- Use a max heap (priority queue) to store all elements.
- Extract the max element k times.
- The kth extracted element is the kth largest.
- This avoids sorting the entire array.

Time Complexity: O(n + k log n) — heap construction + k extractions.  
Space Complexity: O(n) — heap stores all elements.
*/

public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        var comparer = Comparer<int>.Create((x, y) => y.CompareTo(x));
        PriorityQueue<int, int> maxHeap = new(comparer);

        foreach (int num in nums) {
            maxHeap.Enqueue(num, num);
        }

        int kthLargest = 0;
        while (k > 0) {
            kthLargest = maxHeap.Dequeue();
            k--;
        }

        return kthLargest;
    }
}
