using System.Text.RegularExpressions;

namespace Task7;

public class RomanConverter
{
    private readonly Dictionary<char, int> RomanValues = new()
    {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 }
    };

    private bool IsValidRomanNumeral(string roman)
    {
        string validPattern = @"^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
        return Regex.IsMatch(roman, validPattern);
    }

    public int RomanToArabic(string roman)
    {
        if (string.IsNullOrEmpty(roman) || !IsValidRomanNumeral(roman))
            return 0;

        int total = 0;
        int prevValue = 0;

        for (int i = roman.Length - 1; i >= 0; i--)
        {
            int currentValue = RomanValues[roman[i]];

            if (currentValue < prevValue)
                total -= currentValue;
            else
                total += currentValue;

            prevValue = currentValue;
        }

        return total;
    }

    public string ReplaceRomanNumerals(string text)
    {
        string pattern = @"\b[IVXLCDM]+\b";

        return Regex.Replace(text, pattern, match =>
        {
            string romanNumeral = match.Value;
            if (IsValidRomanNumeral(romanNumeral))
            {
                int arabicNumber = RomanToArabic(romanNumeral);
                return arabicNumber.ToString();
            }
            return romanNumeral;
        });
    }
}
