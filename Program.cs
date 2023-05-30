using System;
using System.Linq;
using System.Globalization;

namespace TaskSolutions
{
    class Program
    {
        static string SwapBinaryStringFromPosition(string input, int position)
        {
            char[] chars = input.ToCharArray();
            for (int i = position; i < chars.Length; i++)
            {
                chars[i] = chars[i] == '0' ? '1' : '0';
            }

            return new string(chars);
        }

        static int CalculateDaysToGivenDate(DateTime givenDate)
        {
            DateTime currentDate = DateTime.Now;
            if (givenDate < currentDate)
            {
                Console.WriteLine("Вказана дата вже минула.");
                return -1;
            }

            TimeSpan timeSpan = givenDate - currentDate;
            return timeSpan.Days;
        }

        static void AnalyzeDates(string dateString)
        {
            DateTime[] dates = dateString.Split(',')
                                          .Select(x => DateTime.ParseExact(x.Trim(), "dd.MM.yyyy", CultureInfo.InvariantCulture))
                                          .ToArray();

            DateTime minYearDate = dates.OrderBy(x => x.Year).First();
            DateTime[] springDates = dates.Where(x => x.Month >= 3 && x.Month <= 5).ToArray();
            DateTime latestDate = dates.OrderByDescending(x => x).First();

            Console.WriteLine($"Рік з найменшим номером: {minYearDate.Year}");
            Console.WriteLine("Весняні дати:");
            foreach (DateTime date in springDates)
            {
                Console.WriteLine(date.ToString("dd.MM.yyyy"));
            }
            Console.WriteLine($"Сама пізніша дата: {latestDate.ToString("dd.MM.yyyy")}");
        }

        static void Main(string[] args)
        {
            // Завдання 1
            string input = "11001100";
            int position = 3;
            string result = SwapBinaryStringFromPosition(input, position);
            Console.WriteLine($"Результат заміни одиниць на нулі і навпаки з позиції {position}: {result}");

            // Завдання 2
            DateTime givenDate = new DateTime(2023, 5, 1);
            int daysToGivenDate = CalculateDaysToGivenDate(givenDate);
            if (daysToGivenDate != -1)
            {
                Console.WriteLine($"Кількість днів до вказаної дати: {daysToGivenDate}");
            }

            // Завдання 3
            string dateString = "01.01.2020, 15.04.2022, 30.11.2021";
            AnalyzeDates(dateString);
        }
    }
}
