/*
Leetcode 1071. Greatest Common Divisor of Strings
Topic: String, Math

Approach:

1. The problem is based on the idea that if two strings have a common base pattern, 
   repeating that pattern should rebuild both strings exactly.
2. First, check if `str1 + str2` equals `str2 + str1`. 
   - If not, then there's no common pattern that divides both strings → return an empty string.
3. If they match, the GCD of their lengths tells us the length of the repeating pattern.
   - Use the Euclidean algorithm to find the GCD of `str1.Length` and `str2.Length`.
4. Return the substring from the start of `str1` with length equal to the GCD.
   - This substring is the greatest common divisor of both strings.

Time Complexity: O(n + m)
- Where n = str1.Length and m = str2.Length
- Concatenation check (`str1 + str2` and `str2 + str1`) takes O(n + m)
- GCD calculation takes O(log(min(n, m)))
- Substring creation takes O(gcd(n, m)), which is ≤ n or m

Space Complexity: O(n + m)
- Due to temporary concatenated strings created during the equality check
*/


public string GcdOfStrings(string str1, string str2)
{
    // Step 2: If concatenating in both orders is not the same, return ""
    if (str1 + str2 != str2 + str1) return "";

    // Step 3: Get the GCD of the two string lengths
    int gcdLength = GCD(str1.Length, str2.Length);

    // Step 4: Return the prefix of str1 up to the GCD length
    return str1[..gcdLength];
}

// Helper method to compute GCD using the Euclidean algorithm
private int GCD(int a, int b)
{
    return b == 0 ? a : GCD(b, a % b);
}

/*
Example

Input:
str1 = "ABABAB"
str2 = "ABAB"

Concatenation Check
Check if str1 + str2 == str2 + str1
"ABABAB" + "ABAB" → "ABABABABAB"
"ABAB" + "ABABAB" → "ABABABABAB"
They match → so a common base pattern exists

Length GCD
Length of str1 = 6
Length of str2 = 4
Compute GCD(6, 4):
GCD(6, 4) → GCD(4, 2) → GCD(2, 0) → 2

Extract Common Substring
Take substring from start of str1 with length 2
str1.Substring(0, 2) → "AB"

What is GCD?
It’s the largest number that evenly divides both numbers without leaving a remainder.
Example:
Let’s say we have:
a = 6
b = 4
The divisors of:
6 are: 1, 2, 3, 6
4 are: 1, 2, 4
The greatest number that appears in both lists is 2, so:
GCD(6, 4) = 2
the Euclidean Algorithm?

The Euclidean algorithm is an efficient method to find the Greatest Common Divisor (GCD) of two numbers.
It’s based on a simple principle:
The GCD of two numbers a and b is the same as the GCD of b and a % b.
Formula
GCD(a, b) = GCD(b, a % b)
*/