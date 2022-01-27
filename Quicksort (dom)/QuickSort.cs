using System;
using System.Linq;

namespace quicksort
{
    class QuickSort
    { 
    public static int resultpos = 0;

    /// <summary>
    /// Sort the random quicksort array from small to large.
    /// </summary>
    /// <argo>
    /// First determin the avarge of the quicksort array.
    /// Split the quicksort into 2 arrays. One for everything lower or equal to the avarage and one for everthing higher then average.
    /// Then check if the higher array is empty.
    ///     if true : Add low to result and hight if its not empty.
    ///     if false : Call itself and do it again.
    /// </argo>
    /// <param name="quicksort">The quicksort array.</param>
    public static void sortWithQuickSort(decimal[] quicksort)
    {
        decimal avg = Enumerable.Average(quicksort);
        int lowpos = 0;
        int highpos = 0;

        foreach (decimal number in quicksort)
        {
            if (number <= avg) { lowpos++; } else { highpos++; }
        }
        if (highpos == 0) return;


        decimal[] low = new decimal[lowpos];
        decimal[] high = new decimal[highpos];

        foreach (decimal number in quicksort)
        {
            if (number <= avg) low[--lowpos] = number;
            else high[--highpos] = number;
        }
        sortWithQuickSort(low);
        sortWithQuickSort(high);

        for (int i = 0; i < low.Length; i++) quicksort[i] = low[i];
        for (int i = 0; i < high.Length; i++) quicksort[i + low.Length] = high[i];
        writeQuicksortArrayToConsole(quicksort);
    }

    /// <summary>
    /// This will write the quicksort array to the console.
    /// </summary>
    /// <param name="quicksort">The quicksort int array.</param>
    public static void writeQuicksortArrayToConsole(decimal[] quicksort)
    {
        for (int place = 0; place < quicksort.Length; place++)
        {
            Console.WriteLine("[" + place + "] => " + quicksort[place]);
        }
    }

    /// <summary>
    /// This generate an random int array for the quicksort.
    /// </summary>
    /// <param name="size">The amount of random numbers in the array.</param>
    /// <param name="min">The minimum value of a value in the array.</param>
    /// <param name="max">The maximum value of a value in the array.</param>
    /// <returns>An int[] for quicksort.</returns>
    public static decimal[] getRandonQuicksort(int size, int min, int max)
    {
        Random random = new Random();
        decimal[] result = new decimal[size];
        for (int place = 0; place < size; place++)
        {
            result.SetValue((decimal)random.Next(min, max), place);
        }
        return result;
    }
}
}
