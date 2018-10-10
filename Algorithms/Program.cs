using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = collectNumbers();
            Console.WriteLine(string.Join(',', numbers));

            Console.WriteLine("------ Merge Sort ------");
            int[] mergeSortNumbers = new int[numbers.Length];
            Array.Copy(numbers, mergeSortNumbers, numbers.Length);

            mergesort(mergeSortNumbers);
            Console.WriteLine(string.Join(',', mergeSortNumbers));

            Console.WriteLine("------ Quick Sort ------");
            int[] quicksortNumbers = new int[numbers.Length];
            Array.Copy(numbers, quicksortNumbers, numbers.Length);

            quicksort(quicksortNumbers);
            Console.WriteLine(string.Join(',', quicksortNumbers));

            int needle = readInteger();
            int index = binarySearch(needle, quicksortNumbers);
            Console.WriteLine("Index of {0}: {1}", needle, index);
        }


        // array must be sorted in ascending order!
        static int binarySearch(int needle, int[] haystack) {
            return binarySearch(needle, haystack, 0, haystack.Length - 1);
        }

        static int binarySearch(int needle, int[] haystack, int start, int end) {
            if (start > end || start < 0 || end >= haystack.Length) {
                return -1;
            }

            int mid = start + (end - start) / 2;

            if (haystack[mid] == needle) {
                return mid;
            } else if (haystack[mid] > needle) {
                return binarySearch(needle, haystack, start, mid - 1);
            } else {
                return binarySearch(needle, haystack, mid + 1, end);
            }
        }

        static void quicksort(int[] array) {
            quicksort(array, 0, array.Length - 1);
        }

        static void quicksort(int[] array, int left, int right)
        {
            if (left >= right || left < 0 || right >= array.Length) {
                return;
            }

            int pivot = partition(array, left, right);
            quicksort(array, left, pivot - 1);
            quicksort(array, pivot + 1, right);
        }

        static int partition(int[] array, int left, int right) 
        {
            // start by picking arbitrary reference value as pivot
            int pivot = left + (right - left) / 2;

            while (left < right) {
                while (left < array.Length && array[left] <= array[pivot])
                {
                    ++left;
                }

                while (right > 0 && array[right] > array[pivot])
                {
                    --right;
                }

                if (left < right) {
                    // swap values of right and left
                    swap(array, left, right);
                }

            }

            // The final state of left and right pointers:

            // The left pointer will end up at the position after the "true" pivot location
            // or out of bounds. Everything to its left will be less than or equal to the current pivot value
            // ,and everything at its location and to the right will be greater than the pivot value.

            // The right pointer will end up at the "true" pivot position. It will always stop when it crosses
            // the left pointer (because everything to the left of the left pointer is less than or equal to pivot value).
            // The position pointed to by the right pointer will have everything to its right be greater than the current
            // pivot value, and everything at its location and to the left less than or equal to the pivot value. This
            // is the definition of the pivot and therefore the "true" pivot position.
            swap(array, pivot, right);
            pivot = right;

            return pivot;
        }

        static void swap(int[] array, int index1, int index2) {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        static void mergesort(int[] array) {
            mergesort(array, 0, array.Length - 1);
        }

        static void mergesort(int[] array, int start, int end) 
        {
            if (start >= end || start < 0 || end >= array.Length) 
            {
                return;
            }

            int mid = start + (end - start) / 2;
            mergesort(array, start, mid);
            mergesort(array, mid + 1, end);

            merge(array, start, mid, end);
        }

        static void merge(int[] array, int start, int mid, int end) 
        {
            // copy the contents of the array's left and right partition to merge w/o overwriting
            int[] leftArray = new int[mid - start + 1];
            int[] rightArray = new int[end - mid];

            for (int i = 0; i < leftArray.Length; ++i) {
                leftArray[i] = array[start + i];
            }

            for (int i = 0; i < rightArray.Length; ++i) {
                rightArray[i] = array[mid + 1 + i];
            }

            int leftPtr = 0;
            int rightPtr = 0;
            int arrayPtr = start;

            while (leftPtr < leftArray.Length && rightPtr < rightArray.Length) {
                if (leftArray[leftPtr] <= rightArray[rightPtr]) {
                    array[arrayPtr] = leftArray[leftPtr];
                    ++leftPtr;
                    ++arrayPtr;
                } else {
                    array[arrayPtr] = rightArray[rightPtr];
                    ++rightPtr;
                    ++arrayPtr;
                }
            }


            // copy the remaining items of the remaining partition
            while (leftPtr < leftArray.Length) {
                array[arrayPtr] = leftArray[leftPtr];
                ++leftPtr;
                ++arrayPtr;
            }

            while (rightPtr < rightArray.Length) {
                array[arrayPtr] = rightArray[rightPtr];
                ++rightPtr;
                ++arrayPtr;
            }
        }

        static int[] collectNumbers()
        {
            Console.Write("Give me some numbers to crunch (separate multiple values with comma): ");
            string input = Console.ReadLine();

            string[] inputArray = input.Split(',');

            try
            {
                int[] inputNumbers = new int[inputArray.Length];

                for (int i = 0; i < inputArray.Length; ++i)
                {
                    inputNumbers[i] = int.Parse(inputArray[i]);
                }

                return inputNumbers;
            }
            catch (Exception)
            {
                int[] defaultNumbers = new int[] { 10, 25, 7, 2, 0 };
                Console.WriteLine("It's OK I picked some for you! {0}", string.Join(',', defaultNumbers));

                return defaultNumbers;
            }
        }

        static int readInteger()
        {
            int integer;

            Console.Write("Give me a number to find: ");

            while (true)
            {

                string input = Console.ReadLine();


                if (int.TryParse(input, out integer))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("That didn't work...try another number");
                }
            }

            return integer;
        }
    }
}
