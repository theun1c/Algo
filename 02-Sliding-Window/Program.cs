// 643. Maximum Average Subarray I 
// Example 1:

// Input: nums = [1,12,-5,-6,50,3], k = 4
// Output: 12.75000
// Explanation: Maximum average is (12 - 5 - 6 + 50) / 4 = 51 / 4 = 12.75

// Example 2:

// Input: nums = [5], k = 1
// Output: 5.00000

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
