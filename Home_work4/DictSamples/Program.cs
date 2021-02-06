// Кудряшов Сергей

// 3. * Дан фрагмент программы:
// Dictionary<string, int> dict = new Dictionary<string, int>()
//  {
//    {"four",4 },
//    {"two",2 },
//    { "one",1 },
//    {"three",3 },
//  };
// var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
// foreach (var pair in d)
// {
//    Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
// }
// а) Свернуть обращение к OrderBy с использованием лямбда-выражения $.
// б) *Развернуть обращение к OrderBy с использованием делегата Predicate<T>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictSamples
{
    class Program
    {
        //public delegate int Predicate<T>(T obj);
        static void Main(string[] args)
        {
            Func<KeyValuePair<string, int>, int> mypredicate = GetValue;

            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };
            //var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            var d = dict.OrderBy(x => x.Value);
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }

            Console.WriteLine("\nПредикат:");
            var b = dict.OrderBy(mypredicate);
            foreach (var pair in b) Console.WriteLine("{0} - {1}", pair.Key, pair.Value);

            Console.ReadLine();
        }

        static int GetValue(KeyValuePair<string, int> kvp)
        {
            return (kvp.Value);
        }

    }
}
