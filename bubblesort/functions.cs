using System;
using System.Collections.Generic;
using System.Text;

namespace bubblesort
{
    class functions
    {
        /// <summary>
        /// This will sort a random array from the smallest number to the biggest number.
        /// </summary>
        /// <argo>
        /// First check if the first one is bigger then the second one.
        /// If that is the case then switch them.
        /// Then do the same for the rest of the array.
        /// When at the end: igore the top one.
        /// </argo>
        /// <returns>The bubblesort array from the smallest number to the biggest.</returns>
        public static int[] sortWithBubbleSort(int[] bubblesort) {

            for (int repeat = 0; repeat < bubblesort.Length; repeat++)
            {
                for (int place = 0; place < bubblesort.Length - 1 - repeat; place++)
                {
                    if (bubblesort[place] > bubblesort[place + 1])
                    {
                        int top = bubblesort[place];
                        bubblesort.SetValue(bubblesort[place + 1], place);
                        bubblesort.SetValue(top, place + 1);
                    }
                }
            }
            return bubblesort;
        }

        /// <summary>
        /// This will write the bubblesort array to the console.
        /// </summary>
        /// <param name="bubblesort">The bubblesort int array.</param>
        public static void writeBubbleSortArrayToConsole(int[] bubblesort) {
            for (int place = 0; place < bubblesort.Length; place++)
            {
                Console.WriteLine("[" + place + "] => " + bubblesort[place]);
            }
        }

        /// <summary>
        /// This generate an random int array for the bubblesort.
        /// </summary>
        /// <param name="size">The amount of random numbers in the array.</param>
        /// <param name="min">The minimum value of a value in the array.</param>
        /// <param name="max">The maximum value of a value in the array.</param>
        /// <returns>An int[] for bubblesort.</returns>
        public static int[] getRandonBubblesort(int size, int min, int max) {
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
