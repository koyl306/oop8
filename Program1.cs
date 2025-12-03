using System;

namespace _8pr
{
    delegate double FuncDel(double x);

    class Program
    {
        public static double PositiveFunction(double x)
        {
            return x * x + 4;
        }

        public static double NonPositiveFunction(double x)
        {
            return 0;
        }

        static void Main(string[] args)
        {
            Console.Write("Введіть число x: ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Потрібно було ввести число");
                return;
            }

            if (!double.TryParse(input, out double x))
            {
                Console.WriteLine("Введено не число");
                return;
            }

            FuncDel f;

            if (x > 0)
            {
                f = new FuncDel(PositiveFunction);
            }
            else
            {
                f = new FuncDel(NonPositiveFunction);
            }

            double result = f(x);
            Console.WriteLine($"F({x}) = {result}");

            Console.ReadKey();
        }
    }
}
