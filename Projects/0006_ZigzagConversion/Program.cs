﻿// https://leetcode.com/problems/zigzag-conversion/description
/*
 6. Zigzag Conversion
Medium
Topics
premium lock icon
Companies
The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

P   A   H   N
A P L S I I G
Y   I   R
And then read line by line: "PAHNAPLSIIGYIR"

Write the code that will take a string and make this conversion given a number of rows:

string convert(string s, int numRows);
 

Example 1:

Input: s = "PAYPALISHIRING", numRows = 3
Output: "PAHNAPLSIIGYIR"
Example 2:

Input: s = "PAYPALISHIRING", numRows = 4
Output: "PINALSIGYAHRPI"
Explanation:
P     I    N
A   L S  I G
Y A   H R
P     I
Example 3:

Input: s = "A", numRows = 1
Output: "A"
 */

static string Convert(string s, int numRows)
{
    if (numRows <= 1 || s.Length <= 1) { return s; }

    var result = new char[s.Length];
    var index = 0;
    for (int i = 0; i < numRows; i++)
    {
        for (int j = 0; (numRows * 2 - 2) * j + i < s.Length; j++)
        {
            var originalIndex = (numRows * 2 - 2) * j + i;
            result[index++] = s[originalIndex];

            if (i == 0 || i == numRows - 1) { continue; }

            originalIndex = originalIndex + (numRows * 2 - 2) - i * 2;
            if (originalIndex < s.Length)
            {
                result[index++] = s[originalIndex];
            }
        }
    }

    return new string(result);
}

string input = "PAYPALISHIRING";
int numRows = 3;
Console.WriteLine(Convert(input, numRows));
