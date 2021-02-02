// Кудряшов Сергей

// * Добавить в пример Lesson3 обобщенный делегат.
// Попробуйте задать область определения функции от отрицательного числа с шагом 0,1

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDelegate2_Lesson3
{
    class Program
    {
        public delegate double Fun<T>(T x);

        static double MyNegativeSquareFunc(double x)
        {
            try
            {
                // Если х не попадает в область определения, то генерируется исключение
                if (x == -1) throw new ArgumentException($"Функция при х = {x} не определена.");
                else return 1 / Math.Pow(1 + x, 2);
            }
            catch
            {
                throw;
            }
        }

        public static void Table(Fun<double> f, double a, double b, double h)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (a <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", a, f?.Invoke(a));
                a += h;
            }
            Console.WriteLine("---------------------");
        }

        static void Main(string[] args)
        {
            try
            {
                Console.Write("a=");
                double a = double.Parse(Console.ReadLine().Replace('.', ','));
                Console.Write("b=");
                double b = double.Parse(Console.ReadLine().Replace('.', ','));
                Console.Write("h=");
                double h = double.Parse(Console.ReadLine().Replace('.', ','));
                Table(MyNegativeSquareFunc, a, b, h);
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат ввода данных");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }            
        }
    }
}
