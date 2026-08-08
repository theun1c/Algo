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

void ReverseString(char[] s)
{
    int ptr1 = 0;
    int ptr2 = s.Length - 1;

    while (ptr2 > ptr1)
    {
        char temp = s[ptr1];
        s[ptr1] = s[ptr2];
        s[ptr2] = temp;
        ptr1++;
        ptr2--;
    }

    Console.WriteLine(s);
}

ReverseString(['H', 'e', 'l', 'l', 'o']);

ReverseString(['H','a','n','n','a','h']);
