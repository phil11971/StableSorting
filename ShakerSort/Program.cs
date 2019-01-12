using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShakerSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = new int[] { 9, 6, 10, 8, 43, 2, 6, 24, 6 };

            Console.WriteLine("Src mas");
            PrintMas(mas);

            ShakerSort(mas);

            Console.WriteLine("Res mas");
            PrintMas(mas);

            Console.ReadKey();
        }

        //Сложность алгоритма: O(n^2)
        public static void ShakerSort(int[] array)
        {
            int buff;
            int left = 0;
            int right = array.Length - 1;
            do
            {
                for (int i = left; i < right; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        buff = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = buff;
                    }
                }
                right--;
                for (int i = right; i > left; i--)
                {
                    if (array[i] < array[i - 1])
                    {
                        buff = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = buff;
                    }
                }
                left++;
            }
            while (left < right);
        }

        static void PrintMas(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}
