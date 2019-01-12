using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnomeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = new int[] { 9, 6, 10, 8, 43, 2, 6, 24, 6 };

            Console.WriteLine("Src mas");
            PrintMas(mas);

            GnomeSort(mas);

            Console.WriteLine("Res mas");
            PrintMas(mas);

            Console.ReadKey();
        }

        //Сложность алгоритма: O(n^2)
        public static void GnomeSort(int[] a)
        {
            int i = 1;
            while (i < a.Length)
            {
                if (i == 0 || a[i - 1] <= a[i])
                    i++;
                else
                {
                    int temp = a[i];
                    a[i] = a[i - 1];
                    a[i - 1] = temp;
                    i--;
                }
            }
        }

        static void PrintMas(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}
