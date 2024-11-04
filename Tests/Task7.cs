using Task7;

namespace Tests;

public class Task7
{
    private readonly RomanConverter romanConverter = new RomanConverter();

    [Theory]
    [InlineData("I", 1)]
    [InlineData("IV", 4)]
    [InlineData("IX", 9)]
    [InlineData("XV", 15)]
    [InlineData("XL", 40)]
    [InlineData("XC", 90)]
    [InlineData("C", 100)]
    [InlineData("D", 500)]
    [InlineData("M", 1000)]
    [InlineData("MM", 2000)]
    [InlineData("MMM", 3000)]
    [InlineData("MMMCMXCIX", 3999)]
    public void RomanToArabic_ShouldConvertCorrectly(string roman, int expectedArabic)
    {
        int result = romanConverter.RomanToArabic(roman);
        Assert.Equal(expectedArabic, result);
    }

    [Theory]
    [InlineData("I", "1")]
    [InlineData("I, IV, IX, XV, MM, MMMCMXCIX.", "1, 4, 9, 15, 2000, 3999.")]
    [InlineData("Numbers: I, V, X.", "Numbers: 1, 5, 10.")]
    [InlineData("Строка без чисел", "Строка без чисел")]
    [InlineData("Invalid numerals like MMMM or IIII.", "Invalid numerals like MMMM or IIII.")]
    public void ReplaceRomanNumeralsWithArabic_ShouldReplaceCorrectly(string input, string expectedOutput)
    {
        string result = romanConverter.ReplaceRomanNumerals(input);
        Assert.Equal(expectedOutput, result);
    }
}
