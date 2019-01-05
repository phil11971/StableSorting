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
            Divide(arr, left, right);

            left = MergeSortList(left);
            right = MergeSortList(right);

            return Merge(left, right);
        }

        private static void Divide(int[] arr, List<int> left, List<int> right)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (IsOdd(i))
                    left.Add(arr[i]);
                else right.Add(arr[i]);
            }
        }

        private static bool IsOdd(int i)
        {
            return i % 2 > 0;
        }

        private static List<int> MergeSortList(List<int> list) {
            return MergeSort(list.ToArray()).ToList();
        }

        private static int[] Merge(List<int> left, List<int> right)
        {
            var res = new List<int>();

            while (NotEmpty(left) && NotEmpty(right))
            {
                MoveSmallerValInLeftOrRightToRes(left, right, res);
            }

            MoveRemainingValuesFromSrcToRes(left, res);
            MoveRemainingValuesFromSrcToRes(right, res);

            return res.ToArray();
        }

        private static bool NotEmpty(List<int> list)
        {
            return list.Count > 0;
        }

        private static void MoveSmallerValInLeftOrRightToRes(List<int> left, List<int> right, List<int> res)
        {
            if (left.First() <= right.First())
                MoveValFromSrcToRes(left, res);
            else
                MoveValFromSrcToRes(right, res);
        }

        private static void MoveValFromSrcToRes(List<int> list, List<int> res)
        {
            res.Add(list.First());
            list.RemoveAt(0);
        }

        private static void MoveRemainingValuesFromSrcToRes(List<int> list, List<int> res)
        {
            while (NotEmpty(list))
                MoveValFromSrcToRes(list, res);
        }

        static void PrintMas(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}
