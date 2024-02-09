// https://leetcode.com/problems/two-sum/description/

static int[] TwoSum(int[] nums, int target)
{
    int[] result = new int[2];

    for (int i = 0; i < nums.Length; i++)
    {
        for (int j = 0; j < nums.Length; j++)
        {
            if (i != j)
            {
                if (nums[i] + nums[j] == target)
                {
                    result[0] = i;
                    result[1] = j;
                    Console.WriteLine(result[0] + ", " + result[1]);
                    return result;
                }
            }
        }
    }

    return result;
}

int[] nums = { 2, 7, 11, 15 };
int target = 9;

//int[] nums = { 3, 2, 4 };
//int target = 6;

//int[] nums = { 3, 3 };
//int target = 6;

TwoSum(nums, target);