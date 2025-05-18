/*
Leetcode 2336. Smallest Number in Infinite Set  
Topic: Priority Queue, HashSet

Approach:
- Maintain a min-heap (priority queue) to store the numbers currently in the set.
- Use a HashSet to keep track of numbers present in the heap to avoid duplicates.
- Initially enqueue numbers 1 to 1000 (or some upper bound) since the set is infinite.
- popSmallest(): dequeue the smallest number and remove it from the set.
- addBack(num): if num is not in the set, add it back to the heap and set.

Time Complexity:
- popSmallest(): O(log n) due to heap operation.
- addBack(): O(log n) for heap insertion if applicable.
Space Complexity: O(n) for the heap and hash set.
*/

public class SmallestInfiniteSet {
    private PriorityQueue<int, int> minHeap;
    private HashSet<int> set;

    public SmallestInfiniteSet() {
        minHeap = new PriorityQueue<int, int>();
        set = new HashSet<int>();
        for (int i = 1; i <= 1000; i++) {
            minHeap.Enqueue(i, i);
            set.Add(i);
        }
    }
    
    public int PopSmallest() {
        int smallest = minHeap.Dequeue();
        set.Remove(smallest);
        return smallest;
    }
    
    public void AddBack(int num) {
        if (!set.Contains(num)) {
            minHeap.Enqueue(num, num);
            set.Add(num);
        }
    }
}

/**
 * Your SmallestInfiniteSet object will be instantiated and called as such:
 * SmallestInfiniteSet obj = new SmallestInfiniteSet();
 * int param_1 = obj.PopSmallest();
 * obj.AddBack(num);
 */
