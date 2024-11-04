using Task7;

RomanConverter romanConverter = new RomanConverter();
string input = "Нужно заменить римское число MMMCMXCIX";
string output = romanConverter.ReplaceRomanNumerals(input);
Console.WriteLine(output);