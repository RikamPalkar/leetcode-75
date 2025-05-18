/*
Leetcode 933. Number of Recent Calls
Topic: Queue, Sliding Window

Approach:
- Use a queue to keep track of the request times.
- On each ping(t):
  - Enqueue the current request time.
  - Dequeue requests that are older than t - 3000 (outside the time window).
- The queue size after removals is the count of recent calls within the last 3000 ms.

Time Complexity: O(n), each element is enqueued and dequeued at most once.
Space Complexity: O(n) for storing calls within the 3000ms window.
*/

public class RecentCounter {

    private Queue<int> queue;
    
    public RecentCounter() {
        queue = new Queue<int>();
    }
    
    public int Ping(int t) {
        queue.Enqueue(t); // Add the new request time
        
        // Remove requests older than (t - 3000)
        while (queue.Peek() < t - 3000) {
            queue.Dequeue();
        }

        return queue.Count; // Number of requests in [t-3000, t]
    }
}

/**
 * Your RecentCounter object will be instantiated and called as such:
 * RecentCounter obj = new RecentCounter();
 * int param_1 = obj.Ping(t);
 */