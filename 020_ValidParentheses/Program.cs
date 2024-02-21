// https://leetcode.com/problems/valid-parentheses/description/

/*
 Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:

Open brackets must be closed by the same type of brackets.
Open brackets must be closed in the correct order.
Every close bracket has a corresponding open bracket of the same type.

Example 1:

Input: s = "()"
Output: true
Example 2:

Input: s = "()[]{}"
Output: true
Example 3:

Input: s = "(]"
Output: false

 */


static bool IsValid(string s)
{
    while (s.Contains("()") || s.Contains("{}") || s.Contains("[]"))
    {
        if (s.Contains("()"))
        {
            s = s.Replace("()", "");
        }

        if (s.Contains("{}"))
        {
            s = s.Replace("{}", "");
        }

        if (s.Contains("[]"))
        {
            s = s.Replace("[]", "");
        }
    }
    if (s.Length == 0)
    {
        return true;
    }
    else
    {
        return false;
    }
}

string input = "()";
Console.WriteLine(IsValid(input)); //true

input = "()[]{}";
Console.WriteLine(IsValid(input)); //true

input = "(]";
Console.WriteLine(IsValid(input)); //false

input = "{[]}";
Console.WriteLine(IsValid(input)); //true