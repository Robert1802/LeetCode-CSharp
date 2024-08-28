// https://leetcode.com/problems/longest-substring-without-repeating-characters/description/

/*
 3. Longest Substring Without Repeating Characters
 
Given a string s, find the length of the longest  substring without repeating characters.

Example 1:

Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.
Example 2:

Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.
Example 3:

Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
 

Constraints:

0 <= s.length <= 5 * 104
s consists of English letters, digits, symbols and spaces.

 */

static int LengthOfLongestSubstring(string s)
{
    if (string.IsNullOrEmpty(s)) return 0;

    int maxLength = 0;
    int left = 0;
    HashSet<char> set = new HashSet<char>();

    for (int right = 0; right < s.Length; right++)
    {
        // If the character is already in the set, remove characters from the left until it's removed
        while (set.Contains(s[right]))
        {
            set.Remove(s[left]);
            left++;
        }

        // Add the current character to the set
        set.Add(s[right]);

        // Calculate the length of the current window and update maxLength if it's larger
        maxLength = Math.Max(maxLength, right - left + 1);
    }

    return maxLength;
}

string example1 = "abcabcbb";
Console.WriteLine(example1);
Console.WriteLine(LengthOfLongestSubstring(example1)); // 3

string example2 = "bbbbb";
Console.WriteLine(example2);
Console.WriteLine(LengthOfLongestSubstring(example2)); // 1

string example3 = "pwwkew";
Console.WriteLine(example3);
Console.WriteLine(LengthOfLongestSubstring(example3)); // 3

string example4 = "aa";
Console.WriteLine(example4);
Console.WriteLine(LengthOfLongestSubstring(example4)); // 1

string example5 = "au";
Console.WriteLine(example5);
Console.WriteLine(LengthOfLongestSubstring(example5)); // 2

string example6 = "aab";
Console.WriteLine(example6);
Console.WriteLine(LengthOfLongestSubstring(example6)); // 2

Console.ReadLine();