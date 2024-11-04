using Task8;

namespace Tests;

public class Task8
{
    private readonly DateProcessor dateProcessor = new DateProcessor();

    [Fact]
    public void ValidDate_ShouldIncreaseBy15Days()
    {
        string input = "Event on 10.03.2023.";
        string expected = "Event on 25.03.2023.";

        string result = dateProcessor.IncreaseDatesBy15Days(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void LeapYear_February_ShouldIncreaseCorrectly()
    {
        string input = "Meeting on 15.02.2024.";
        string expected = "Meeting on 01.03.2024.";

        string result = dateProcessor.IncreaseDatesBy15Days(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void EndOfMonth_ShouldWrapToNextMonth()
    {
        string input = "Appointment on 28.02.2023.";
        string expected = "Appointment on 15.03.2023.";

        string result = dateProcessor.IncreaseDatesBy15Days(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void InvalidDate_ShouldRemainUnchanged()
    {
        string input = "Invalid date 31.02.2024."; // Февраль 31
        string expected = "Invalid date 31.02.2024."; // Невалидная дата, поэтому без изменений

        string result = dateProcessor.IncreaseDatesBy15Days(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void NonDateString_ShouldRemainUnchanged()
    {
        string input = "This is just a number 15.2024 without a proper date.";
        string expected = "This is just a number 15.2024 without a proper date.";

        string result = dateProcessor.IncreaseDatesBy15Days(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void MultipleDates_ShouldAllBeIncreasedBy15Days()
    {
        string input = "Dates: 01.01.2023, 10.01.2023, 25.01.2023.";
        string expected = "Dates: 16.01.2023, 25.01.2023, 09.02.2023.";

        string result = dateProcessor.IncreaseDatesBy15Days(input);

        Assert.Equal(expected, result);
    }
}
