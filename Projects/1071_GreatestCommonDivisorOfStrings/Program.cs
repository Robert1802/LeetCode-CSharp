// https://leetcode.com/problems/greatest-common-divisor-of-strings/description
/*
 1071. Greatest Common Divisor of Strings (Easy)
For two strings s and t, we say "t divides s" if and only if s = t + t + t + ... + t + t (i.e., t is concatenated with itself one or more times).

Given two strings str1 and str2, return the largest string x such that x divides both str1 and str2.

Example 1:

Input: str1 = "ABCABC", str2 = "ABC"
Output: "ABC"
Example 2:

Input: str1 = "ABABAB", str2 = "ABAB"
Output: "AB"
Example 3:

Input: str1 = "LEET", str2 = "CODE"
Output: ""
 */

using System.Text;

static string GcdOfStrings(string str1, string str2)
{
    // If both strings are equal, the GCD is the string itself
    if (str1 == str2) return str1;

    // Ensure str1 is always the shorter string (swap if necessary)
    if (str1.Length > str2.Length) return GcdOfStrings(str2, str1);

    // Start divisor counter at 1
    var i = 1;

    // Try possible divisors of str1 until its full length
    while (i <= str1.Length)
    {
        // Candidate substring length (dividing str1 into i equal parts)
        var length = str1.Length / i;

        // Check if both strings can be evenly divided by this length
        if ((str1.Length % length == 0) && (str2.Length % length == 0))
        {
            // Build repeated substrings to test divisibility
            var sb1 = new StringBuilder();
            var sb2 = new StringBuilder();

            // Take a candidate substring of size 'length' from str1
            var result = str1.Substring(0, length);

            // Repeat 'result' enough times to match str1’s length
            var x1 = str1.Length / length;
            for (int j = 0; j < x1; j++)
                sb1.Append(result);

            // Repeat 'result' enough times to match str2’s length
            var x2 = str2.Length / length;
            for (int j = 0; j < x2; j++)
                sb2.Append(result);

            // If both reconstructed strings equal the originals, we found the GCD
            if ((str1 == sb1.ToString()) && (str2 == sb2.ToString()))
                return result;
        }
        // Try next divisor
        i++;
    }

    // If no common divisor string is found, return empty string
    return string.Empty;
}

