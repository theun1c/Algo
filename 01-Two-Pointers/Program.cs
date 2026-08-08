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
