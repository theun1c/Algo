// 643. Maximum Average Subarray I 
// Example 1:

// Input: nums = [1,12,-5,-6,50,3], k = 4
// Output: 12.75000
// Explanation: Maximum average is (12 - 5 - 6 + 50) / 4 = 51 / 4 = 12.75

// Example 2:

// Input: nums = [5], k = 1
// Output: 5.00000

using System.Diagnostics.CodeAnalysis;

double FindMaxAverage(int[] nums, int k)
{
    int begin = 0;
    double windowState = 0;
    double result = double.MinValue;
    
    for (int end = 0; end < nums.Length; end++)
    {   
        windowState += nums[end];
        if(end - begin + 1 == k)
        {
            result = Math.Max(result, windowState);
            windowState -= nums[begin];
            begin++;
        }
    }
    return result / k;
}

Console.WriteLine(FindMaxAverage([1, 12, -5, -6, 50, 3], 4));


// 209. Minimum Size Subarray Sum
// Example 1:

// Input: target = 7, nums = [2,3,1,2,4,3]
// Output: 2
// Explanation: The subarray [4,3] has the minimal length under the problem constraint.

// Example 2:

// Input: target = 4, nums = [1,4,4]
// Output: 1

// Example 3:

// Input: target = 11, nums = [1,1,1,1,1,1,1,1]
// Output: 0

int MinSubArrayLen(int target, int[] nums)
{
    int begin = 0;
    int windowState = 0;
    int result = int.MaxValue;
    for(int end = 0; end < nums.Length; end++)
    {
        windowState += nums[end];
        while(windowState >= target)
        {
            result = Math.Min(result, end-begin+1);
            windowState -= nums[begin];
            begin++;
        }
    }

    if(result != int.MaxValue)
        return result;
    return 0;
}

Console.WriteLine(MinSubArrayLen(7, [2,3,1,2,4,3]));
Console.WriteLine(MinSubArrayLen(4, [1, 4, 4]));
Console.WriteLine(MinSubArrayLen(11, [1,1,1,1,1,1,1,1]));

// 1004. Max Consecutive Onec III
// Example 1:

// Input: nums = [1,1,1,0,0,0,1,1,1,1,0], k = 2
// Output: 6
// Explanation: [1,1,1,0,0,1,1,1,1,1,1]
// Bolded numbers were flipped from 0 to 1. The longest subarray is underlined.

// Example 2:

// Input: nums = [0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1], k = 3
// Output: 10
// Explanation: [0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,1,1,1,1]
// Bolded numbers were flipped from 0 to 1. The longest subarray is underlined.

int LongestOnes(int[] nums, int k)
{
    int begin = 0;
    int windowState = 0;
    int result = 0;

    for(int end = 0; end < nums.Length; end++)
    {
        if(nums[end] == 0)
            windowState++;
        while(windowState > k)
        {
            if(nums[begin] == 0)
                windowState--;
            begin++;
        }

        result = int.Max(result, end - begin + 1);
    }

    return result;
}