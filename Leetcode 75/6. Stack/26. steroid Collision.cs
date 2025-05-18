/*
Leetcode 735. Asteroid Collision
Topic: Stack, Simulation

Approach:
- Use a stack to keep track of asteroids moving to the right.
- Iterate through each asteroid:
  - If the current asteroid moves right (positive), push it onto the stack.
  - If it moves left (negative), it may collide with asteroids in the stack moving right.
    - While the top of the stack asteroid is smaller than the absolute value of current asteroid, pop it (it explodes).
    - If the top of the stack asteroid is equal in size (absolute) to current, pop it and don't push current (both explode).
    - If the top is larger, current explodes (don't push current).
- After processing all asteroids, the stack contains the surviving asteroids.
- Return the stack as an array in correct order.

Time Complexity: O(n) - each asteroid is pushed and popped at most once.
Space Complexity: O(n) - in worst case, all asteroids are stored in the stack.
*/

public class Solution {
    public int[] AsteroidCollision(int[] asteroids) {
        Stack<int> stack = new Stack<int>();

        foreach (int ast in asteroids) {
            bool destroyed = false;

            while (!destroyed && ast < 0 && stack.Count > 0 && stack.Peek() > 0) {
                int top = stack.Peek();

                if (top < -ast) {
                    // Top asteroid explodes, pop it and continue to check for more collisions
                    stack.Pop();
                } 
                else if (top == -ast) {
                    // Both asteroids explode
                    stack.Pop();
                    destroyed = true;
                } 
                else {
                    // Current asteroid explodes
                    destroyed = true;
                }
            }

            if (!destroyed) {
                stack.Push(ast);
            }
        }

        return stack.Reverse().ToArray();
    }
}
