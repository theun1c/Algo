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