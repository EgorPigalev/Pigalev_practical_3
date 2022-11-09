using System;

namespace Практическая3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Вычисление системы функций");
                double x;
                while (true) // Ввод x
                {
                    Console.Write("Введите x: ");
                    try
                    {
                        x = Convert.ToDouble(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Необходимо ввести вещественное число! Повторите ввод!\n");
                    }
                }
                if (x <= 0) // Решение системы функций
                {
                    FirstFunction(x);
                    // Console.WriteLine(FirstFunctionPlug());
                }
                else
                {
                    SecondlyFunction(x);
                    // Console.WriteLine(SecondlyFunctionPlug());
                }
                Console.WriteLine("\nВыберите действие:\n1 - Запустить программу повторно\n2 - Выйти из программы");
                int otvet; // Переменная для диалога с пользователем
                while (true) // Диалог с пользователем о повторном запуске программы
                {
                    try
                    {
                        otvet = Convert.ToInt32(Console.ReadLine());
                        if (otvet != 1 && otvet != 2)
                        {
                            Console.WriteLine("Необходимо выбрать действие из предложенных! Повторите ввод!");
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Необходимо ввести число 1 или 2! Повторите ввод!\n");
                    }
                }
                if (otvet == 2)
                {
                    break;
                }
                Console.Clear();
            }
        }
        static void FirstFunction(double x) // Решение первой функции
        {
            //double result = ((MathFunctions.Sin(x) + MathFunctions.Cos(x)) + MathFunctions.Cos(x)) * ((MathFunctions.Sin(x) + MathFunctions.Cos(x)) + MathFunctions.Cos(x));
            double result = ((SinPlug() + CosPlug()) + CosPlug()) * ((SinPlug() + CosPlug()) + CosPlug());
            Console.WriteLine("((sin({0}) + cos({0})) + cos({0}))^2 = {1}", x, result); ;
        }
        static void SecondlyFunction(double x) // Решение второй функции
        {
            // double result = MathFunctions.log(Math.E, x) * MathFunctions.log(5, x);
            double result = logPlug() * logPlug();
            Console.WriteLine("ln({0})*log5({0}) = {1}", x, result);
        }

        static double FirstFunctionPlug() // Заглушка для первой функции
        {
            return 1;
        }
        static double SecondlyFunctionPlug() // Заглушка для второй функции
        {
            return 0;
        }
        static double SinPlug() // Заглушка для синуса
        {
            return 0;
        }
        public static double CosPlug() // Заглушка для косинуса
        {
            return 1;
        }
        public static double logPlug() // Заглушка для логарифма
        {
            return 1;
        }
    }
    public class MathFunctions // Вычисление математических функций
    {
        public static double Sin(double x) // Функция для подсчета синуса по ряду Тейлора
        {
            const double eps = 0.000000000000001; // погрешность вычислений
            double sum = 0; // сумма степенных функций
            double t = x; // член ряда
            int n = 1; // показатель степени
            while (Math.Abs(t) > eps) // условие выполнения цикла
            {
                sum = sum + t; // прибавление члена ряда
                n = n + 2; // увеличение степени с шагом 2. n: 1,3,5,7,...
                t = -t * x * x / (n * (n - 1)); // подсчет нового члена ряда
            }
            return sum;
        }

        public static double Cos(double x) // Функция для подсчета косинуса по ряду Тейлора
        {
            const double eps = 0.000000000000001; // погрешность вычислений
            double sum = 0; // сумма степенных функций
            double t = 1; // член ряда
            int n = 0; // показатель степени
            while (Math.Abs(t) > eps) // условие выполнения цикла
            {
                sum = sum + t; // прибавление члена ряда
                n = n + 2; // увеличение степени с шагом 2. n: 0,2,4,5,...
                t = -t * x * x / (n * (n - 1)); // подсчет нового члена ряда
            }
            return sum;
        }
        public static double log(double osn, double x) // Функция для подсчета логарифма (osn - основание; x - число)
        {
            double s = 0.000001; // Начальное значение
            while (Math.Pow(osn, s) < x) // Методом перебора находим логарифм
            {
                s += 0.000001;
            }
            return s;
        }
    }
}