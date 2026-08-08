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
int[] TwoSum(int[] numbers, int target) {
    for (int l = 0, r = numbers.Length - 1; l < r; )
    {
        if (numbers[l] + numbers[r] > target)
            r--;
        if (numbers[l] + numbers[r] < target)
            l++;
        if(numbers[l] + numbers[r] == target)
            return new int[] { l, r };
    }
    return new int[] { };
}

