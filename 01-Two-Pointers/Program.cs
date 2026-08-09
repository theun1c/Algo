// 344. Reverse String
// Example 1:
//
// Input: s = ["h","e","l","l","o"]
// Output: ["o","l","l","e","h"]
//
// Example 2:
//
// Input: s = ["H","a","n","n","a","h"]
// Output: ["h","a","n","n","a","H"]

// void ReverseString(char[] s)
// {
//     int left = 0;
//     int right = s.Length - 1;
//
//     while (right > left)
//     {
//         (s[left], s[right]) = (s[right], s[left]); 
//         left++;
//         right--;
//     }
//
//     Console.WriteLine(s);
// }

// perfect clean 
void ReverseString(char[] s)
{
    for (int l = 0, r = s.Length - 1; l < r; l++, r--)
    {
        (s[l], s[r]) = (s[r], s[l]);
    }
    
    Console.WriteLine(s);
}

ReverseString(['H', 'e', 'l', 'l', 'o']);

ReverseString(['H','a','n','n','a','h']);


// 125. Valid Palindrome
// Example 1:
//
// Input: s = "A man, a plan, a canal: Panama"
// Output: true
// Explanation: "amanaplanacanalpanama" is a palindrome.
//
// Example 2:
//
// Input: s = "race a car"
// Output: false
// Explanation: "raceacar" is not a palindrome.
//
// Example 3:
//
// Input: s = " "
// Output: true
// Explanation: s is an empty string "" after removing non-alphanumeric characters.
//     Since an empty string reads the same forward and backward, it is a palindrome.


bool IsPalindrome(string s)
{
    char[] letters = s.Where(char.IsLetterOrDigit).Select(char.ToLower).ToArray();

    for (int l = 0, r = letters.Length - 1; l < r; l++, r--)
    {
        if(letters[l] != letters[r])
            return false;
    }
     
    return true;
}

Console.WriteLine(IsPalindrome("A man, a plan, a canal: Panama"));
Console.WriteLine(IsPalindrome("Race a car"));
Console.WriteLine(IsPalindrome(" "));

// 167. Two Sum II - Input Array Is Sorted
// Example 1:
//
// Input: numbers = [2,7,11,15], target = 9
// Output: [1,2]
// Explanation: The sum of 2 and 7 is 9. Therefore, index1 = 1, index2 = 2. We return [1, 2].
//
//     Example 2:
//
// Input: numbers = [2,3,4], target = 6
// Output: [1,3]
// Explanation: The sum of 2 and 4 is 6. Therefore index1 = 1, index2 = 3. We return [1, 3].
//
//     Example 3:
//
// Input: numbers = [-1,0], target = -1
// Output: [1,2]
// Explanation: The sum of -1 and 0 is -1. Therefore index1 = 1, index2 = 2. We return [1, 2].

// ooomg perfect sol
int[] TwoSumSorted(int[] numbers, int target) {
    for (int l = 0, r = numbers.Length - 1; l < r; )
    {
        if (numbers[l] + numbers[r] > target)
            r--;
        else
            l++;
        
        if(numbers[l] + numbers[r] == target)
            return new int[] { l, r };
    }
    return new int[] { };
}

// 15. 3Sum
// Example 1:
//
// Input: nums = [-1,0,1,2,-1,-4]
// Output: [[-1,-1,2],[-1,0,1]]
// Explanation: 
// nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
//     nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
//     nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
//     The distinct triplets are [-1,0,1] and [-1,-1,2].
//     Notice that the order of the output and the order of the triplets does not matter.
//
//     Example 2:
//
// Input: nums = [0,1,1]
// Output: []
// Explanation: The only possible triplet does not sum up to 0.
//
//     Example 3:
//
// Input: nums = [0,0,0]
// Output: [[0,0,0]]
// Explanation: The only possible triplet sums up to 0.

IList<IList<int>> ThreeSum(int[] nums)
{
    nums = nums.OrderBy(x => x).ToArray();

    IList<IList<int>> result = new List<IList<int>>();

    for (int i = 0; i < nums.Length; i++)
    {
        if( i > 0 && nums[i] == nums[i-1])
            continue;
        
        int target = nums[i] * -1;
        int left = i + 1;
        int right = nums.Length - 1;
        
        while (left < right)
        {
            if(nums[left] + nums[right] > target)
                right--;
            else if(nums[left] + nums[right] < target)
                left++;
            else
            {
                result.Add(new List<int>{nums[left], nums[right], target*-1});

                while (left < right && nums[left] == nums[left+1])
                    left++;
                while (left < right && nums[right] == nums[right-1])
                    right--;
                
                left++;
                right--;
            }
        }
    }

    return result;
} 

// 977. Squares of a Sorted Array
// Example 1:
// 
// Input: nums = [-4,-1,0,3,10]
// Output: [0,1,9,16,100]
// Explanation: After squaring, the array becomes [16,1,0,9,100].
// After sorting, it becomes [0,1,9,16,100].
// 
// Example 2:
// 
// Input: nums = [-7,-3,2,3,11]
// Output: [4,9,9,49,121]

int[] SortedSquares(int[] nums)
{
    int[] result = new int[nums.Length];
    int len = nums.Length - 1;
    for (int left = 0, right = nums.Length - 1; left <= right; len--)
    {
        if (nums[left] * nums[left] > nums[right] * nums[right])
        {
            result[len] = nums[left]*nums[left];
            left++;
        }
        else
        {
            result[len] = nums[right]*nums[right];
            right--;
        }
    }
    
    return result;
}

// 11. Container With Most Water
// Input: height = [1,8,6,2,5,4,8,3,7]
// Output: 49
// Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In this case, the max area of water (blue section) the container can contain is 49.
// 
// Example 2:
// 
// Input: height = [1,1]
// Output: 1

int MaxArea(int[] height)
{
    int prev = 0;
    int result = 0;
    int width = 1;
    for (int left = 0, right = height.Length - 1; left < right;)
    {
        if(Math.Abs(right) - Math.Abs(left) > 0)
            width = right - left;
        
        if (height[left] > height[right])
        {
            prev = height[right] * width;
            right--;
        }
        else
        {
            prev = height[left] * width;
            left++;
        }
        
        result = int.Max(result, prev);
    }
    
    return result;
}

// 26. Remove Duplicates from Sorted Array
// Example 1:

// Input: nums = [1,1,2]
// Output: 2, nums = [1,2,_]
// Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
// It does not matter what you leave beyond the returned k (hence they are underscores).

// Example 2:

// Input: nums = [0,0,1,1,1,2,2,3,3,4]
// Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
// Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
// It does not matter what you leave beyond the returned k (hence they are underscores).


int RemoveDuplicates(int[] nums)
{
    int k = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[k] != nums[i])
        {
            k++;
            nums[k] = nums[i];
        }
    }
    return ++k;
}


// 283. Move Zeroes
// Example 1:
// Input: nums = [0,1,0,3,12]
// Output: [1,3,12,0,0]

void MoveZeroes(int[] nums)
{
    for (int i = 0, j = 0; i < nums.Length; i++)
    {
        if (nums[i] != 0)
        {
            (nums[i], nums[j]) = (nums[j], nums[i]);
            j++;
        }
    }
}

// 392. Is Subsequence
// Example 1:
// Input: s = "abc", t = "ahbgdc"
// Output: true
//
// Example 2:
// Input: s = "axc", t = "ahbgdc"
// Output: false

bool IsSubsequence(string s, string t)
{
    int i = 0;
    int j = 0;

    while (i < t.Length && j < s.Length)
    {
        if (t[i] == s[j])
            j++;
        i++;
    }

    return j == s.Length;
}