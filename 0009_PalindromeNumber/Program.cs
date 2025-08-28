// https://leetcode.com/problems/palindrome-number/
// Given an integer x, return true if x is a palindrome, and false otherwise.

static bool IsPalindrome(int x)
{
    string word = x.ToString();
    string reverseWord = new(word.Reverse().ToArray());
    return word == reverseWord;
}

int input = 121;
var result = IsPalindrome(input);
Console.WriteLine(result);