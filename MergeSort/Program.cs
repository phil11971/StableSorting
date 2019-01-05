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

            MergeSort(ref mas, 0, mas.Length - 1);

            Console.WriteLine("Res mas");
            PrintMas(mas);

            Console.ReadKey();
        }

        //Сложность алгоритма: O(n*logn)
        static void MergeSort(ref int[] elements, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;
                MergeSort(ref elements, low, mid);
                MergeSort(ref elements, mid + 1, high);
                Merge(elements, low, mid, high);
            }
        }

        private static void Merge(int[] arr, int low, int mid, int high)
        {

            int n = high - low + 1;
            int[] temp = new int[n];

            int i = low, j = mid + 1;
            int k = 0;

            while (i <= mid || j <= high)
            {
                if (i > mid)
                    temp[k++] = arr[j++];
                else if (j > high)
                    temp[k++] = arr[i++];
                else if (arr[i] < arr[j])
                    temp[k++] = arr[i++];
                else
                    temp[k++] = arr[j++];
            }

            for (j = 0; j < n; j++)
                arr[low + j] = temp[j];
        }

        static void PrintMas(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}
