// Кудряшов Сергей

// 2. Дана коллекция List<T>, требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
// а) для целых чисел;
// б) * для обобщенной коллекции;
// в) * используя Linq.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListSamples
{
    class Program
    {
        private static IDictionary<T,int> GetFrequencyOfElement<T>(ICollection<T> list)
        {
            Dictionary<T, int> found = new Dictionary<T, int>();
            List<T> uniques = new List<T>();
            
            foreach (T val in list)
            {
                if (!found.ContainsKey(val))
                {                    
                    found.Add(val, 1);                    
                }
                else
                {
                    found[val]++;
                }
            }
            return found;
        }

        static void Main(string[] args)
        {
            // Для целых чисел:
            Console.WriteLine("Для целых чисел:");
            List<int> intList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 8, 9 };
            Console.WriteLine("Коллекция:");
            foreach (int el in intList)
                Console.Write(el + " ");
            Console.WriteLine("\nЧастотный массив:");
            foreach (var el in GetFrequencyOfElement(intList))
                Console.WriteLine(el);

            // Для обобщенной коллекции;
            Console.WriteLine("Для обобщенной коллекции:");
            List<dynamic> genList = new List<dynamic>() { 'a', 'b', 'c', 'd', 'f', 'g', 'f', 'd', 's', 'w', 'e', 'r', 't', 'y', 't', 'r', 'e', 'w' , 'q', 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 8, 9 };
            Console.WriteLine("Коллекция:");
            foreach (var el in genList)
                Console.Write(el + " ");
            Console.WriteLine("\nЧастотный массив:");
            foreach (var el in GetFrequencyOfElement(genList))
                Console.WriteLine(el);
        }
    }
}
