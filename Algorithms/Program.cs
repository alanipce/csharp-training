using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] list = { 10, 25, 7, 2, 0 };

            Console.WriteLine("Before sort: {0}", string.Join(',', list));
            mergesort(list);
            Console.WriteLine("After sort: {0}", string.Join(',', list));
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

    }
}
