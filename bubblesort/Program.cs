using System;

namespace bubblesort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bubblesort = functions.getRandonBubblesort(20, 1, 200);
            Console.WriteLine("Input:");
            functions.writeBubbleSortArrayToConsole(bubblesort);
            Console.WriteLine("Output:");
            functions.writeBubbleSortArrayToConsole(functions.sortWithBubbleSort(bubblesort));
        }
    }
}