// https://leetcode.com/problems/string-to-integer-atoi/description

/*
 8. String to Integer (atoi)
Medium
Topics
premium lock icon
Companies
Implement the myAtoi(string s) function, which converts a string to a 32-bit signed integer.

The algorithm for myAtoi(string s) is as follows:

Whitespace: Ignore any leading whitespace (" ").
Signedness: Determine the sign by checking if the next character is '-' or '+', assuming positivity if neither present.
Conversion: Read the integer by skipping leading zeros until a non-digit character is encountered or the end of the string is reached. If no digits were read, then the result is 0.
Rounding: If the integer is out of the 32-bit signed integer range [-231, 231 - 1], then round the integer to remain in the range. Specifically, integers less than -231 should be rounded to -231, and integers greater than 231 - 1 should be rounded to 231 - 1.
Return the integer as the final result.

Example 1:

Input: s = "42"

Output: 42

Explanation:

The underlined characters are what is read in and the caret is the current reader position.
Step 1: "42" (no characters read because there is no leading whitespace)
         ^
Step 2: "42" (no characters read because there is neither a '-' nor '+')
         ^
Step 3: "42" ("42" is read in)
           ^
Example 2:

Input: s = " -042"

Output: -42

Explanation:

Step 1: "   -042" (leading whitespace is read and ignored)
            ^
Step 2: "   -042" ('-' is read, so the result should be negative)
             ^
Step 3: "   -042" ("042" is read in, leading zeros ignored in the result)
               ^
Example 3:

Input: s = "1337c0d3"

Output: 1337

Explanation:

Step 1: "1337c0d3" (no characters read because there is no leading whitespace)
         ^
Step 2: "1337c0d3" (no characters read because there is neither a '-' nor '+')
         ^
Step 3: "1337c0d3" ("1337" is read in; reading stops because the next character is a non-digit)
             ^
Example 4:

Input: s = "0-1"

Output: 0

Explanation:

Step 1: "0-1" (no characters read because there is no leading whitespace)
         ^
Step 2: "0-1" (no characters read because there is neither a '-' nor '+')
         ^
Step 3: "0-1" ("0" is read in; reading stops because the next character is a non-digit)
          ^
Example 5:

Input: s = "words and 987"

Output: 0

Explanation:

Reading stops at the first non-digit character 'w'.
 */


static int MyAtoi(string s)
{
    // Return 0 if string is null, empty, or only whitespace
    if (string.IsNullOrWhiteSpace(s)) { return 0; }

    // Flag to indicate if the number is negative
    var navigate = false;
    // Position in the string
    var index = 0;

    // Skip leading whitespace
    while (index < s.Length && s[index] == ' ') { index++; }

    // If the current character is '-', mark as negative
    if (s[index] == '-')
    {
        navigate = true;
        // Move past the sign
        index++;
    }
    else if (s[index] == '+') // If the current character is '+', just skip it
    {
        index++;
    }

    // Threshold for detecting overflow before multiplying
    var positiveOverflowHead = int.MaxValue / 10;
    // Last digit threshold for detecting overflow
    var positiveOverflowTail = int.MaxValue % 10;

    // Store the converted number
    var result = 0;
    // Process characters from current index until end
    for (; index < s.Length; index++)
    {
        // Convert char to numeric digit
        var digit = s[index] - '0';
        // Stop if not a valid digit
        if (digit < 0 || digit > 9) { break; }

        // Check for overflow: if result is too large before adding the digit
        if (result > positiveOverflowHead ||
            (result == positiveOverflowHead && digit > positiveOverflowTail))
        {
            // Return proper boundary on overflow
            return navigate ? int.MinValue : int.MaxValue;
        }

        // Build the number
        result = result * 10 + digit;
    }

    // Apply negative sign if needed
    return navigate ? -result : result;
}

Console.WriteLine(MyAtoi("42")); // Output: 42
Console.WriteLine(MyAtoi("   -42")); // Output: -42
Console.WriteLine(MyAtoi("4193 with words")); // Output: 4193
Console.WriteLine(MyAtoi("words and 987")); // Output: 0