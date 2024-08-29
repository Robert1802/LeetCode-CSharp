// https://leetcode.com/problems/palindrome-number/
// Given an integer x, return true if x is a palindrome, and false otherwise.

static bool IsPalindrome(int x)
{
    string palindrome = x.ToString();
    string reversePalindrome = new(palindrome.Reverse().ToArray());
    return palindrome == reversePalindrome;
}

int input = 121;
var result = IsPalindrome(input);
Console.WriteLine(result);