// 643. Maximum Average Subarray I 
// Example 1:

// Input: nums = [1,12,-5,-6,50,3], k = 4
// Output: 12.75000
// Explanation: Maximum average is (12 - 5 - 6 + 50) / 4 = 51 / 4 = 12.75

// Example 2:

// Input: nums = [5], k = 1
// Output: 5.00000

using System.Diagnostics.CodeAnalysis;
using System.Text;

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

// 1493. Longest Subarray of 1's After Deleting One Element
// Example 1:

// Input: nums = [1,1,0,1]
// Output: 3
// Explanation: After deleting the number in position 2, [1,1,1] contains 3 numbers with value of 1's.

// Example 2:

// Input: nums = [0,1,1,1,0,1,1,0,1]
// Output: 5
// Explanation: After deleting the number in position 4, [0,1,1,1,1,1,0,1] longest subarray with value of 1's is [1,1,1,1,1].

// Example 3:

// Input: nums = [1,1,1]
// Output: 2
// Explanation: You must delete one element.

int LongestSubarray(int[] nums)
{
    int begin = 0;
    int result = 0;
    int countZero = 0;
    for (int end = 0; end < nums.Length; end++)
    {
        if (nums[end] == 0)
        {
            countZero++;
        }

        while (countZero > 1)
        {
            if (nums[begin] == 0)
            {
                countZero--;
            }
            begin++;
        }

        result = Math.Max(result, end - begin + 1);
    }

    return result - 1;
}

Console.WriteLine(LongestSubarray([1,1,0,1]));
Console.WriteLine(LongestSubarray([0,1,1,1,0,1,1,0,1]));
Console.WriteLine(LongestSubarray([1, 1, 1]));

// 904. Fruit Into Baskets
// You are visiting a farm that has a single row of fruit trees arranged from left to right. The trees are represented by an integer array fruits where fruits[i] is the type of fruit the ith tree produces.

// You want to collect as much fruit as possible. However, the owner has some strict rules that you must follow:

//     You only have two baskets, and each basket can only hold a single type of fruit. There is no limit on the amount of fruit each basket can hold.
//     Starting from any tree of your choice, you must pick exactly one fruit from every tree (including the start tree) while moving to the right. The picked fruits must fit in one of your baskets.
//     Once you reach a tree with fruit that cannot fit in your baskets, you must stop.

// Given the integer array fruits, return the maximum number of fruits you can pick.

// Example 1:

// Input: fruits = [1,2,1]
// Output: 3
// Explanation: We can pick from all 3 trees.

// Example 2:

// Input: fruits = [0,1,2,2]
// Output: 3
// Explanation: We can pick from trees [1,2,2].
// If we had started at the first tree, we would only pick from trees [0,1].

// Example 3:

// Input: fruits = [1,2,3,2,2]
// Output: 4
// Explanation: We can pick from trees [2,3,2,2].
// If we had started at the first tree, we would only pick from trees [1,2].

int TotalFruit(int[] fruits)
{
    int begin = 0;
    Dictionary<int, int> windowState = new();
    int result = 0;

    for(int end = 0; end < fruits.Length; end++)
    {
        if (windowState.ContainsKey(fruits[end]))
        {
            windowState[fruits[end]]++;        
        }
        else
        {
            windowState[fruits[end]] = 1;        
        }

        while(windowState.Count > 2)
        {
            windowState[fruits[begin]]--;
            if(windowState[fruits[begin]] == 0)
            {
                windowState.Remove(fruits[begin]);
            }
            begin++;
        }

        result = Math.Max(result, end - begin + 1);
    }

    return result;
}