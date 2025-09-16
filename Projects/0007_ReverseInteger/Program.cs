// https://leetcode.com/problems/reverse-integer
/*
 7. Reverse Integer (Medium)
    Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.

    Assume the environment does not allow you to store 64-bit integers (signed or unsigned).

    Example 1:

    Input: x = 123
    Output: 321
    Example 2:

    Input: x = -123
    Output: -321
    Example 3:

    Input: x = 120
    Output: 21
 */


static int Reverse(int x)
{
    // Use long to prevent overflow during intermediate calculations
    long reversed = 0;

    while (x != 0)
    {
        int digit = x % 10;
        reversed = reversed * 10 + digit;
        x /= 10;
    }

    // Check for overflow before casting back to int
    if (reversed > Int32.MaxValue || reversed < Int32.MinValue)
    {
        return 0;
    }

    return (int)reversed;
}

int x = 0;

x = 123;
Console.WriteLine(Reverse(x));
x = -123;
Console.WriteLine(Reverse(x));
x = 120;
Console.WriteLine(Reverse(x));
