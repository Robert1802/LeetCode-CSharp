// https://leetcode.com/problems/subarray-sum-equals-k

/*
 560. Subarray Sum Equals K (Medium)
Given an array of integers nums and an integer k, return the total number of subarrays whose sum equals to k.

A subarray is a contiguous non-empty sequence of elements within an array.

Example 1:

Input: nums = [1,1,1], k = 2
Output: 2
Example 2:

Input: nums = [1,2,3], k = 3
Output: 2
 */

static int SubarraySum(int[] nums, int k)
{
    int totalSubarrays = 0;
    int arraySize = nums.Length;

    for (int i = 0; i < arraySize; i++)
    {
        int subarraySum = 0;

        for (int j = i; j < arraySize; j++)
        {
            subarraySum += nums[j];

            if (subarraySum == k)
            {
                totalSubarrays++;
            }
        }
    }

    return totalSubarrays;
}

//int[] nums = [1, 1, 1];
//int k = 2;
//Console.WriteLine(SubarraySum(nums, k)); // 2

//int[] nums = [1,2,3];
//int k = 2;
//Console.WriteLine(SubarraySum(nums, k)); // 2

int[] nums = [1, 2, 1, 2, 1];
int k = 3;
Console.WriteLine(SubarraySum(nums, k)); // 4