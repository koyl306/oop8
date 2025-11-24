using System;

namespace _8pr
{
    class Program
    {
        delegate T CalcDel<T>(T a, T b);
        
        static void Main(string[] args)
        {
            static int AddInt(int a, int b) => a + b;
        static int SubInt(int a, int b) => a - b;
        static int MulInt(int a, int b) => a * b;
        static int DivInt(int a, int b)
        {
            if (b == 0)
            {
                Console.WriteLine("Помилка: ділення на нуль.");
                return 0;
            }
            return a / b;
        }

        static double AddDouble(double a, double b) => a + b;
        static double SubDouble(double a, double b) => a - b;
        static double MulDouble(double a, double b) => a * b;
        static double DivDouble(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("Помилка: ділення на нуль.");
                return 0;
            }
            return a / b;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть перше число: ");
            string s1 = Console.ReadLine();

            Console.Write("Введіть друге число: ");
            string s2 = Console.ReadLine();

            Console.Write("Введіть операцію (+, -, *, /): ");
            string op = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(s1) ||
                string.IsNullOrWhiteSpace(s2) ||
                string.IsNullOrWhiteSpace(op))
            {
                Console.WriteLine("Потрібно ввести числа та операцію.");
                return;
            }

            bool isInt1 = int.TryParse(s1, out int intA);
            bool isInt2 = int.TryParse(s2, out int intB);

            bool isDbl1 = double.TryParse(s1, out double dblA);
            bool isDbl2 = double.TryParse(s2, out double dblB);

            if (isInt1 && isInt2)
            {
                CalcDel<int> del;

                switch (op)
                {
                    case "+":
                        del = AddInt;
                        break;
                    case "-":
                        del = SubInt;
                        break;
                    case "*":
                        del = MulInt;
                        break;
                    case "/":
                        del = DivInt;
                        break;
                    default:
                        Console.WriteLine("Невідома операція.");
                        return;
                }

                Console.WriteLine($"Результат: {del(intA, intB)}");
            }
            else if (isDbl1 && isDbl2)
            {
                CalcDel<double> del;

                switch (op)
                {
                    case "+":
                        del = AddDouble;
                        break;
                    case "-":
                        del = SubDouble;
                        break;
                    case "*":
                        del = MulDouble;
                        break;
                    case "/":
                        del = DivDouble;
                        break;
                    default:
                        Console.WriteLine("Невідома операція.");
                        return;
                }

                Console.WriteLine($"Результат: {del(dblA, dblB)}");
            }
            else
            {
                Console.WriteLine("Помилка: введено некоректні числа.");
            }

            Console.ReadKey();
        }
    }
}