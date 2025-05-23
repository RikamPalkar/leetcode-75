/*
Leetcode 649. Dota2 Senate  
Topic: Greedy, Queue, Simulation

Approach:
- Use two queues to track the indices of senators from Radiant and Dire.
- In each round, dequeue one senator from each party.
- The senator with the smaller index bans the other and re-enters the queue at index + n (to simulate the next round).
- Continue until one queue is empty.
- The remaining party is the winner.

Time Complexity: O(n), each senator enters and exits the queue at most once per round.
Space Complexity: O(n), for queues storing indices.
*/

public class Solution {
    public string PredictPartyVictory(string senate) {
        Queue<int> radiantQ = new();
        Queue<int> direQ = new();
        int len = senate.Length;

        // Enqueue indices of each senator by party
        for (int i = 0; i < len; i++) {
            if (senate[i] == 'R') 
                radiantQ.Enqueue(i);
            else 
                direQ.Enqueue(i);
        }

        // Simulate rounds
        while (radiantQ.Count > 0 && direQ.Count > 0) {
            int radiantIndex = radiantQ.Dequeue();
            int direIndex = direQ.Dequeue();

            // The senator with the lower index acts first and bans the other
            if (radiantIndex < direIndex)
                radiantQ.Enqueue(radiantIndex + len); // Re-queue for next round
            else
                direQ.Enqueue(direIndex + len);
        }

        return radiantQ.Count > 0 ? "Radiant" : "Dire";
    }
}
