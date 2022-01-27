using System;

namespace quicksort
{
    class Program
    {
        public static int size = 20;
        static void Main(string[] args)
        {
            //QuickSort.result = new decimal[size];
            decimal[] quicksort = QuickSort.getRandonQuicksort(size, 1, 200);
            //decimal[] quicksort = new decimal[4]{ 4, 1, 4, 4 };
            Console.WriteLine("Input:");
            QuickSort.writeQuicksortArrayToConsole(quicksort);
            QuickSort.sortWithQuickSort(quicksort);
            Console.WriteLine("Output:");
            //QuickSort.writeQuicksortArrayToConsole(QuickSort.result);
        }
    }
}
