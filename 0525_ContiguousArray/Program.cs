// https://leetcode.com/problems/contiguous-array

/*
 525. Contiguous Array (Medium)
Given a binary array nums, return the maximum length of a contiguous subarray with an equal number of 0 and 1.

Example 1:

Input: nums = [0,1]
Output: 2
Explanation: [0, 1] is the longest contiguous subarray with an equal number of 0 and 1.
Example 2:

Input: nums = [0,1,0]
Output: 2
Explanation: [0, 1] (or [1, 0]) is a longest contiguous subarray with equal number of 0 and 1.
Example 3:

Input: nums = [0,1,1,1,1,1,0,0,0]
Output: 6
Explanation: [1,1,1,0,0,0] is the longest contiguous subarray with equal number of 0 and 1. 
 */

static int FindMaxLength(int[] nums)
{
    var prefixIndex = new Dictionary<int, int>();
    prefixIndex[0] = -1; // handle subarrays starting from index 0

    int maxLen = 0;
    int sum = 0;

    for (int i = 0; i < nums.Length; i++)
    {
        // treat 0 as -1, 1 as +1
        sum += nums[i] == 1 ? 1 : -1;

        if (prefixIndex.ContainsKey(sum))
        {
            // same sum seen before → subarray from prefixIndex[sum]+1 to i has equal 0s and 1s
            maxLen = Math.Max(maxLen, i - prefixIndex[sum]);
        }
        else
        {
            prefixIndex[sum] = i; // first time we see this prefix sum
        }
    }

    return maxLen;
}

int[] nums = [0, 1];
Console.WriteLine(FindMaxLength(nums)); // Output: 2 - [0, 1]

nums = [0, 1, 0];
Console.WriteLine(FindMaxLength(nums)); // Output: 2 - [0, 1] (or [1, 0])


nums = [0, 1, 1, 1, 1, 1, 0, 0, 0];
Console.WriteLine(FindMaxLength(nums)); // Output: 6 - [1,1,1,0,0,0]