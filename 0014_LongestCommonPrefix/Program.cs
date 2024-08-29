// https://leetcode.com/problems/longest-common-prefix/description/

/*
 Write a function to find the longest common prefix string amongst an array of strings.

If there is no common prefix, return an empty string "".

 

Example 1:

Input: strs = ["flower","flow","flight"]
Output: "fl"
Example 2:

Input: strs = ["dog","racecar","car"]
Output: ""
Explanation: There is no common prefix among the input strings.

 */


static string LongestCommonPrefix(string[] strs)
{
    string currentPrefix = "";
    var sorted = strs.OrderBy(n => n.Length);
    var shortest = sorted.FirstOrDefault();
    if (shortest.Length == 1)
    {
        int divisor = strs.Count(p => p.Substring(0, 1) != strs[0].Substring(0, 1));
        if (divisor > 0)
        {
            return "";
        }
        return shortest;
    }

    for (int i = 0; i <= shortest.Length - 1; i++)
    {
        currentPrefix = strs[0].Substring(0, 1 + i);
        for (int j = 0; j < strs.Length; j++)
        {
            Console.WriteLine(strs[j].Substring(0, 1 + i));
            if (currentPrefix != strs[j].Substring(0, 1 + i))
                return strs[j].Substring(0, i);
        }
    }
    return currentPrefix;
}

string[] strs = { "flower", "flow", "flight" };
Console.WriteLine(LongestCommonPrefix(strs));