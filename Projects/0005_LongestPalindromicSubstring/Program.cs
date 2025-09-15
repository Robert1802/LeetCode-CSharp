// https://leetcode.com/problems/longest-palindromic-substring
// 5. Longest Palindromic Substring

/*
Given a string s, return the longest palindromic substring in s.

Example 1:
Input: s = "babad"
Output: "bab"
Explanation: "aba" is also a valid answer.
    
Example 2:
Input: s = "cbbd"
Output: "bb"
 */


static string LongestPalindrome(string s)
{
    if (string.IsNullOrEmpty(s)) return "";

    int start = 0, maxLength = 1;

    for (int i = 0; i < s.Length; i++)
    {
        // Odd length palindrome (center at i)
        ExpandAroundCenter(s, i, i, ref start, ref maxLength);

        // Even length palindrome (center between i and i+1)
        ExpandAroundCenter(s, i, i + 1, ref start, ref maxLength);
    }

    return s.Substring(start, maxLength);
}

static void ExpandAroundCenter(string s, int left, int right, ref int start, ref int maxLength)
{
    while (left >= 0 && right < s.Length && s[left] == s[right])
    {
        int length = right - left + 1;
        if (length > maxLength)
        {
            maxLength = length;
            start = left;
        }
        left--;
        right++;
    }
}
string input = "babad";
Console.WriteLine(LongestPalindrome(input));