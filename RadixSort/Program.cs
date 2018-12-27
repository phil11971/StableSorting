using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadixSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = new int[] { 9, 6, 10, 8, 43, 2, 6, 24, 6 };

            Console.WriteLine("Src mas");
            PrintMas(mas);

            mas = RadixSort(mas, 2);//следить за length

            Console.WriteLine("Res mas");
            PrintMas(mas);

            Console.ReadKey();
        }

        //Cложность алгоритма: O(nk)
        static int[] RadixSort(int[] arr, int length)//length - кол-во разрядов в числе
        {
            List<int>[] lists = new List<int>[10];
            for (int i = 0; i < 10; i++)
                lists[i] = new List<int>();

            for (int step = 0; step < length; step++)
            {
                //распределение по спискам
                for (int i = 0; i < arr.Length; i++)
                {
                    int temp = (arr[i] % (int)Math.Pow(10, step + 1)) / (int)Math.Pow(10, step);
                    lists[temp].Add(arr[i]);
                }
                //сборка
                int k = 0;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < lists[i].Count; j++)
                    {
                        arr[k++] = (int)lists[i][j];
                    }
                }
                for (int i = 0; i < 10; ++i)
                    lists[i].Clear();
            }
            return arr;
        }

        static void PrintMas(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}
