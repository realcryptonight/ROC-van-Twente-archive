using System;

namespace Quicksort_a_la_Hoare
{
    class Program
    {
        private static int size = 20;
        static void Main(string[] args)
        {
            //int[] quicksort = QuickSort.getRandonQuicksort(size, 1, 10);
            int[] quicksort = new int[] { 5, 1, 3, 7, 1, 2 };
            //int[] quicksort = new int[]{ 3, 1, 6, 1, 4 };
            //int[] quicksort = new int[] { 9, 8, 6, 7, 5, 6 };
            //int[] quicksort = new int[] { 3, 3, 7, 7, 4, 5, 8, 7, 8, 9, 2, 1, 9, 4, 9, 7, 7, 3, 8, 8 };
            Console.WriteLine("Input:");
            QuickSort.writeQuicksortArrayToConsole(quicksort);
            int[] result = QuickSort.sortWithQuickSort(quicksort, 0, 1, quicksort.Length - 1);
            Console.WriteLine("");
            Console.WriteLine("Output:");
            if (result != null) { QuickSort.writeQuicksortArrayToConsole(result); } else { Console.WriteLine("Result was NULL!"); }
        }
    }
}
