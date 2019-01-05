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
            int[] mas = new int[] { 9, 6, 10, 8, 43, 2 , 6, 24, 6};
            int[] tmp = new int[3];
            Console.WriteLine("Src mas");
            PrintMas(mas);

            mas = MergeSort(mas);

            Console.WriteLine("Res mas");
            PrintMas(mas);

            Console.ReadKey();
        }

        private static int[] MergeSort(int[] arr)
        {
            if (arr.Length <= 1) return arr;

            var left = new List<int>();
            var right = new List<int>();

            for (int i = 0; i < arr.Length / 2; i++)
            {
                left.Add(arr[i]);
            }
            for (int i = arr.Length / 2; i < arr.Length; i++)
            {
                right.Add(arr[i]);
            }

            left = MergeSort(left.ToArray()).ToList();
            right = MergeSort(right.ToArray()).ToList();

            return Merge(left, right);
        }

        private static int[] Merge(List<int> left, List<int> right)
        {
            var res = new List<int>();

            while (left.Count > 0 && right.Count > 0)
            {
                if (left.First() <= right.First())
                {
                    res.Add(left.First());
                    left.RemoveAt(0);
                }
                else
                {
                    res.Add(right.First());
                    right.RemoveAt(0);
                }
            }

            while (left.Count > 0)
            {
                res.Add(left.First());
                left.RemoveAt(0);
            }

            while (right.Count > 0)
            {
                res.Add(right.First());
                right.RemoveAt(0);
            }

            return res.ToArray();
        }

        static void PrintMas(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}
