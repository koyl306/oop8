using System;

namespace _8pr
{
    class Program
    {
        delegate string MonthInfo(int monthNumber);
        
        static string[] monthNames =
        {
            "Січень", "Лютий", "Березень", "Квітень", "Травень", "Червень", "Липень", "Серпень", "Вересень", "Жовтень", "Листопад", "Грудень"
        };

        static double[] monthTemperature =
        {
            -4.5, -3.2, 2.1, 8.8, 15.2, 19.5, 22.0, 21.3, 16.0, 9.1, 3.0, -1.8
        };

        static string January(int number)
        {
            if (number == 1)
            {
                Console.WriteLine("Метод January");
                return $"{monthNames[0]} - середня температура: {monthTemperature[0]}°C";
            }
            return "";
        }

        static string May(int number)
        {
            if (number == 5)
            {
                Console.WriteLine("Метод May");
                return $"{monthNames[4]} - середня температура: {monthTemperature[4]}°C";
            }
            return "";
        }

        static string November(int number)
        {
            if (number == 11)
            {
                Console.WriteLine("Метод November");
                return $"{monthNames[10]} - середня температура: {monthTemperature[10]}°C";
            }
            return "";
        }
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть номер місяця (1–12): ");
            if (!int.TryParse(Console.ReadLine(), out int month) || month < 1 || month > 12)
            {
                Console.WriteLine("Невірний ввід");
                return;
            }

            MonthInfo info = January;
            info += May;
            info += November;

            Console.WriteLine();

            foreach (MonthInfo del in info.GetInvocationList())
            {
                string result = del(month);
                if (!string.IsNullOrEmpty(result))
                {
                    Console.WriteLine(result);
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}