using System;
using System.Linq;

namespace Quicksort_a_la_Hoare
{
    class QuickSort
    {
        private static int step = 0;
        /// <summary>
        /// Sort an random int array from small to large.
        /// <algo>
        /// First: Change the Hpos value to one less if its value is not less or equal to the value of pivot. 
        /// Second: Change the Lpos value to one more if its value is equal or higher then the value of pivot.
        /// if: L pos is less then H pos
        ///     switch the values around and repeat.
        /// else:
        ///     Switch H and pivot values around.
        ///     Now H is at the correct possition.
        ///     So trigger itself 2 times, one for everthing before H and one for everything after H.
        /// </algo>
        /// </summary>
        /// <param name="quicksort">The quicksort array.</param>
        /// <param name="H">The most right value of the part that you want to sort.</param>
        /// <param name="L">The most left value of the part that you want to sort.</param>
        /// <param name="pivot">The starting point. (Most of the time it will be the pos before L.)</param>
        public static int[] sortWithQuickSort(int[] quicksort, int pivotpos, int L, int H)
        {
            int Lpos = L;
            int Hpos = H;
            int maxsize = quicksort.Length - 1;

            if (pivotpos >= maxsize || Lpos > maxsize || Hpos > maxsize)
            {
                Console.WriteLine("");
                Console.WriteLine("Size: " + quicksort.Length);
                Console.WriteLine("L: " + Lpos);
                Console.WriteLine("H: " + Hpos);
            }
            else
            {
                if (Hpos - Lpos > 2)
                {
                    // Possibly check if given values are allowed?
                    if (Lpos < Hpos && Lpos != Hpos)
                    {
                        while (L < H)
                        {
                            while (quicksort[H] >= quicksort[pivotpos])
                            {
                                if (quicksort[H] >= quicksort[pivotpos])
                                {
                                    H--;
                                }
                                if (H == pivotpos) { break; }
                            }
                            while (quicksort[L] < quicksort[pivotpos])
                            {
                                if (quicksort[L] < quicksort[pivotpos])
                                {
                                    L++;
                                }
                                if (L == H) { break;  }
                            }
                            // For debug reasons.
                            Console.WriteLine("");
                            Console.WriteLine("pivot: " + pivotpos + " [" + quicksort[pivotpos] + "]");
                            Console.WriteLine("L: " + quicksort[L] + " [" + L + "]");
                            Console.WriteLine("H: " + quicksort[H] + " [" + H + "]");

                            if (L < H)
                            {
                                int remember = quicksort[L];
                                quicksort[L] = quicksort[H];
                                quicksort[H] = remember;
                            }
                            else
                            {
                                Console.WriteLine(Environment.NewLine + "H: " + H);
                                // Now H is correct.
                                // And split the rest into new self calls.
                                Console.WriteLine(Environment.NewLine + "New selfcall 1." + Environment.NewLine + "sortWithQuickSort(quicksort, " + pivotpos + ", " + Lpos + ", " + H + ");");
                                sortWithQuickSort(quicksort, pivotpos, Lpos, H);
                                Console.WriteLine(Environment.NewLine + "New selfcall 2." + Environment.NewLine + "sortWithQuickSort(quicksort, " + (H + 1) + ", " + (H + 2) + ", " + (quicksort.Length - 1) + ");");
                                sortWithQuickSort(quicksort, H + 1, H + 2, quicksort.Length - 1);
                            }
                        }
                    }
                }
                else
                {
                    if (Hpos - Lpos == 2 && quicksort[Lpos] > quicksort[Hpos])
                    {
                        int remember = quicksort[Lpos];
                        quicksort[Lpos] = quicksort[Hpos];
                        quicksort[Hpos] = remember;
                    }
                }
            }
            return quicksort;
        }

        /// <summary>
        /// This will write the quicksort array to the console.
        /// </summary>
        /// <param name="quicksort">The quicksort int array.</param>
        public static void writeQuicksortArrayToConsole(int[] quicksort)
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
        public static int[] getRandonQuicksort(int size, int min, int max)
        {
            Random random = new Random();
            int[] result = new int[size];
            for (int place = 0; place < size; place++)
            {
                result.SetValue(random.Next(min, max), place);
            }
            return result;
        }
    }
}
