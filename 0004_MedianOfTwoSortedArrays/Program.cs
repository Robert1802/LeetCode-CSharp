// https://leetcode.com/problems/median-of-two-sorted-arrays/

/*
 4. Median of Two Sorted Arrays

Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.

The overall run time complexity should be O(log (m+n)).

Example 1:

Input: nums1 = [1,3], nums2 = [2]
Output: 2.00000
Explanation: merged array = [1,2,3] and median is 2.
Example 2:

Input: nums1 = [1,2], nums2 = [3,4]
Output: 2.50000
Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.
 
 */

static double FindMedianSortedArrays(int[] nums1, int[] nums2)
{
    // Ensure nums1 is the smaller array to optimize binary search
    if (nums1.Length > nums2.Length)
    {
        return FindMedianSortedArrays(nums2, nums1);
    }

    int x = nums1.Length;
    int y = nums2.Length;
    int low = 0, high = x;

    while (low <= high)
    {
        int partitionX = (low + high) / 2;
        int partitionY = (x + y + 1) / 2 - partitionX;

        int maxX = (partitionX == 0) ? int.MinValue : nums1[partitionX - 1];
        int maxY = (partitionY == 0) ? int.MinValue : nums2[partitionY - 1];

        int minX = (partitionX == x) ? int.MaxValue : nums1[partitionX];
        int minY = (partitionY == y) ? int.MaxValue : nums2[partitionY];

        if (maxX <= minY && maxY <= minX)
        {
            // We have partitioned the array correctly
            if ((x + y) % 2 == 0)
            {
                return ((double)Math.Max(maxX, maxY) + Math.Min(minX, minY)) / 2;
            }
            else
            {
                return (double)Math.Max(maxX, maxY);
            }
        }
        else if (maxX > minY)
        {
            // Move towards the left in nums1
            high = partitionX - 1;
        }
        else
        {
            // Move towards the right in nums1
            low = partitionX + 1;
        }
    }

    throw new InvalidOperationException("Input arrays are not sorted.");
}