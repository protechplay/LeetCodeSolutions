// LeetCode Problem #13: Roman to Integer
// Converts a Roman numeral to an integer.
// Problem details can be found at https://leetcode.com/problems/roman-to-integer/

public class Solution
{
    // Converts a single Roman numeral character to its integer value.
    // Handles both uppercase and lowercase representations.
    public static int ToRomanValue(char c) => c switch
    {
        'I' => 1, 'V' => 5, 'X' => 10, 'L' => 50, 'C' => 100, 'D' => 500, 'M' => 1000,
        'i' => 1, 'v' => 5, 'x' => 10, 'l' => 50, 'c' => 100, 'd' => 500, 'm' => 1000,
        // Throws an exception if the character is not a valid Roman numeral
        _ => throw new ArgumentOutOfRangeException(nameof(c), $"Unexpected value: {c}")
    };

    // Converts a string of Roman numerals to an integer.
    // The conversion is done by iterating from the end of the string to the beginning,
    // comparing each numeral's value to the one before it to decide whether to add or subtract it.
    public int RomanToInt(string s)
    {
        int sum = 0; // Accumulator for the result
        int previousValue = 0; // Holds the integer value of the previous Roman numeral

        // Iterate over the string in reverse order
        for (int i = s.Length - 1; i >= 0; i--){
            int currentValue = ToRomanValue(s[i]); // Convert the current Roman numeral to its integer value
            
            // If the current value is less than the previous value, subtract it from the sum
            // This handles cases like IV (4) where the numeral I (1) comes before V (5)
            if (currentValue < previousValue) {
                sum -= currentValue;
            }
            // Otherwise, add the current value to the sum
            else {
                sum += currentValue;
            }
            
            previousValue = currentValue; // Update the previous value for the next iteration
        }

        return sum; // Return the final result
    }
}
