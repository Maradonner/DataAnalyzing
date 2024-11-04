using System.Globalization;
using System.Text.RegularExpressions;

namespace Task8;

public class DateProcessor
{
    public string IncreaseDatesBy15Days(string text)
    {
        string updatedText = Regex.Replace(text, @"\b(\d{2})\.(\d{2})\.(\d{4})\b", match =>
        {
            int day = int.Parse(match.Groups[1].Value);
            int month = int.Parse(match.Groups[2].Value);
            int year = int.Parse(match.Groups[3].Value);

            if (!DateTime.TryParseExact($"{day:D2}.{month:D2}.{year}", "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                return match.Value;
            }

            DateTime newDate = date.AddDays(15);
            return newDate.ToString("dd.MM.yyyy");
        });
        return updatedText;
    }
}