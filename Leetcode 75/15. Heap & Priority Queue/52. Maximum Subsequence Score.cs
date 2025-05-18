/*
Leetcode 2542. Maximum Subsequence Score  
Topic: Sorting, Priority Queue, Greedy

Approach:
- Pair elements from nums1 and nums2.
- Sort pairs by nums2 in descending order so the minimum in the subsequence is controlled.
- Use a min-heap to maintain the largest k elements from nums1.
- Iterate pairs: add nums1 to heap and sum, remove smallest if heap size > k.
- When heap size == k, compute score = sum * current nums2 (minimum of selected subsequence).
- Track max score across all valid subsequences.

Time Complexity:
- Sorting pairs: O(n log n)
- Each insert/remove from heap: O(log k)
- Total: O(n log n)

Space Complexity: O(n) for pairs and O(k) for heap.
*/

public class Solution 
{
    public long MaxScore(int[] nums1, int[] nums2, int k) 
    {
        int len = nums1.Length;
        long sum = 0;
        long ans = 0;

        List<(int num1, int num2)> pairs = new();
        for (int i = 0; i < len; i++) 
        {
            pairs.Add((nums1[i], nums2[i]));
        }

        pairs.Sort((a, b) => b.num2.CompareTo(a.num2));

        PriorityQueue<int, int> minHeap = new();

        for (int i = 0; i < len; i++) 
        {
            sum += pairs[i].num1;
            minHeap.Enqueue(pairs[i].num1, pairs[i].num1);

            if (minHeap.Count > k) 
            {
                sum -= minHeap.Dequeue();
            }

            if (minHeap.Count == k) 
            {
                ans = Math.Max(ans, sum * (long)pairs[i].num2);
            }
        }

        return ans;
    }
}
