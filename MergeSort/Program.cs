using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = new int[] { 9, 6, 10, 8, 43, 2, 6, 24, 6 };

            Console.WriteLine("Src mas");
            PrintMas(mas);

            mas = MergeSort(mas, 0, mas.Length - 1);

            Console.WriteLine("Res mas");
            PrintMas(mas);

            Console.ReadKey();
        }

        //Сложность алгоритма: O(n*logn)
        static int[] MergeSort(int[] elements, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;
                MergeSort(elements, low, mid);
                MergeSort(elements, mid + 1, high);
                Merge(elements, low, mid, high);
            }
            return elements;
        }

        private static void Merge(int[] subset, int low, int mid, int high)
        {

            int n = high - low + 1;
            int[] Temp = new int[n];

            int i = low, j = mid + 1;
            int k = 0;

            while (i <= mid || j <= high)
            {
                if (i > mid)
                    Temp[k++] = subset[j++];
                else if (j > high)
                    Temp[k++] = subset[i++];
                else if (subset[i] < subset[j])
                    Temp[k++] = subset[i++];
                else
                    Temp[k++] = subset[j++];
            }
            for (j = 0; j < n; j++)
                subset[low + j] = Temp[j];
        }

        static void PrintMas(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}
