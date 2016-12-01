using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    class Mas_3
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Введите число елементов массива ");
            n = Convert.ToInt16(Console.ReadLine());

            double[] x = new double[n];
            for (int i = 0; i < x.Length; i++)
            {
                Console.WriteLine("Введите елемент массива");
                x[i] = double.Parse(Console.ReadLine());

                Console.WriteLine();
            };
            double pos = x.Where(p => p > 0).Sum();
            double neg = x.Where(p =>  p < 0).Sum();
            double f;

            f = Math.Log10(pos + 20 / neg);
            Console.WriteLine("Выполним действие Ln({0} + 20 / {1})",pos, neg);
            Console.WriteLine("Результат равен {0}", f);
            Console.ReadLine();
            
        }
    }
}
