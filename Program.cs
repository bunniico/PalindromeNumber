using System.Diagnostics;

/* Test 1
 * Expect: true */
var result = IsPalindrome(121);
Console.WriteLine(result);
Debug.Assert(result == true);

/* Test 2
 * Expect: false */
result = IsPalindrome(-121);
Console.WriteLine(result);
Debug.Assert(result == false);

/* Test 3
 * Expect: false */
result = IsPalindrome(10);
Console.WriteLine(result);
Debug.Assert(result == false);

/* Test 4
 * Expect: false */
result = IsPalindrome(1234567899);
Console.WriteLine(result);
Debug.Assert(result == false);

/// <summary>
/// Given an integer `x`, return `true` if `x` is a palindrome, and `false` otherwise
/// </summary>
static bool IsPalindrome(int x)
{
    // Quick elimination of non-palindromes:
    // Negative numbers are not palindromes because of the negative sign.
    if (x < 0)
        return false;

    // Zero is a palindrome.
    if (x == 0)
        return true;

    // If the last digit is 0, then the number must be divisible by 10, and thus it cannot be a palindrome unless it is 0 itself.
    if (x % 10 == 0 && x != 0)
        return false;

    /* Multiply reversed by 10 to shift its digits to the left
     * Then, add the last digit of x to reversed to build the reversed number
     * Finally, divide x by 10 to remove the last digit
     * Repeat this process until x is less than or equal to reversed
     * ---
     * Example:
     * Input: 121
     * 0: reversed = 0, x = 121
     * ...
     * 1: reversed = ((0 * 10 = 0 ) + (x % 10 = 1)) 1, x = (121 / 10) 12
     * 1.5: x > reversed? true, continue
     * ...
     * 2: reversed = ((1 * 10 = 10) + (x % 10 = 2)) 12, x = (12 / 10) 1 (integer division)
     * 2.5: x > reversed? true, continue
     * ...
     * 3: reversed = ((12 * 10 = 120) + (x % 10 = 1)) 121,
     * 3.5: x > reversed? false, stop
     * ...
     * x == reversed? true
     * return true
     */
    int reversed = 0;
    while (x > reversed)
    {
        reversed = reversed * 10 + x % 10;
        x /= 10;
    }

    /* If x is equal to reversed, then we have confirmed that the number is a palindrome.
     * If x divided by 10 is equal to reversed, then the number is also a palindrome. */
    return x == reversed || x == reversed / 10;
}