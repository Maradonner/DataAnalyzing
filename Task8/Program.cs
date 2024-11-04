using Task8;

string text = "Сегодня 02.11.2024 и следующее мероприятие начнется 17.11.2024.";

var dateProcessor = new DateProcessor();
var updatedText = dateProcessor.IncreaseDatesBy15Days(text);

Console.WriteLine("Первоначальный текст:" + text);
Console.WriteLine("Обновленный текст:" + updatedText);