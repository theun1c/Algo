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

