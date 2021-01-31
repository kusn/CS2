//Кудряшов Сергей

//1. Построить три класса (базовый и 2 потомка), описывающих некоторых работников
// с почасовой оплатой (один из потомков) и фиксированной оплатой (второй потомок).
// а) Описать в базовом классе абстрактный метод для расчёта среднемесячной заработной платы.
// Для «повременщиков» формула для расчета такова: «среднемесячная заработная 
// плата = 20.8 * 8 * почасовая ставка», для работников с фиксированной оплатой 
// «среднемесячная заработная плата = фиксированная месячная оплата».
// б) Создать на базе абстрактного класса массив сотрудников и заполнить его.
// в) *Реализовать интерфейсы для возможности сортировки массива, используя Array.Sort().
// г) *Создать класс, содержащий массив сотрудников, и реализовать возможность вывода данных 
// с использованием foreach.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Workers
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeBasedWorker timeBasedWorker = new TimeBasedWorker(5);
            FixedPaymentWorker fixedPaymentWorker = new FixedPaymentWorker(3);

            foreach (Object tbw in timeBasedWorker)
                Console.Write("{0,4}", tbw);

            Console.WriteLine("");

            IEnumerator ie = timeBasedWorker as IEnumerator;
            while (ie.MoveNext())
                Console.WriteLine(ie.Current);

            foreach (Object fpw in fixedPaymentWorker)
                Console.Write("{0,4}", fpw);

            Console.WriteLine("");

            IEnumerator _ie = fixedPaymentWorker as IEnumerator;
            while (_ie.MoveNext())
                Console.WriteLine(_ie.Current);

            TimeBasedWorker[] timeBaseds = new TimeBasedWorker[3] {new TimeBasedWorker("One", "Two", 2), new TimeBasedWorker("Three", "Four", 1), new TimeBasedWorker("Five", "Six", 3) };
            FixedPaymentWorker[] fixedPayments = new FixedPaymentWorker[3] {new FixedPaymentWorker("One", "Two", 20), new FixedPaymentWorker("Three", "Four", 100), new FixedPaymentWorker("Five", "Six", 30) };

            foreach (Object tbw in timeBaseds)
                Console.WriteLine((tbw as Worker).FirstName + " " + (tbw as Worker).LastName);

            // Сортировка по имени
            Console.WriteLine("Сортировка по имени");
            Array.Sort(timeBaseds, new SortByFirstName());
            
            foreach (Object tbw in timeBaseds)
                Console.WriteLine((tbw as Worker).FirstName + " " + (tbw as Worker).LastName);

            // Сортировка по фамилии
            Console.WriteLine("Сортировка по фамилии");
            Array.Sort(timeBaseds, new SortByLastName());

            foreach (Object tbw in timeBaseds)
                Console.WriteLine((tbw as Worker).FirstName + " " + (tbw as Worker).LastName);

            Console.ReadKey();
        }
    }
}
