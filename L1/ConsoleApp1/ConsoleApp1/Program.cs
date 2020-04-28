using System;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            metka:
            double x, y ;
            bool t = true;
            Console.Write("Введите х для вычисления выражения: √(x^10-e^x)-cos(x^3)-ln(x)\n");
            x = Convert.ToDouble (Console.ReadLine());
            if (Math.Pow(x, 10) < Math.Exp(x))
            {
                Console.Write("Недопустимое значение под корнем\n");
                t = false;
            }
            if (x <= 0)
            {
                Console.Write("Недопустимое значение в логорифме\n");
                t = false;
            }
            
            if (t==true)
            {
                y = -Math.Cos(Math.Pow(x, 3)) - Math.Log(x) + Math.Sqrt(Math.Pow(x, 10) - Math.Exp(x));
                Console.Write("Значение выражения равно {0}\n", y);
            }
            Console.Write("Для повтора ввода нажмите 1\n");
            char s;
            s=Convert.ToChar(Console.ReadLine());
            if (s == '1') goto metka;
            else Console.Write("Спасибо за внимание!");
            Console.Read();
        }
    }
}
