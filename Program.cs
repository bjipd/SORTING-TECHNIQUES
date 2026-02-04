using System; 
using System.Diagnostics;

namespace SortingTechniques
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Create an array for testing sorting techniques
            Random random = new();
            int [] testArray = Enumerable.Range(0, 100000).Select(_ => random.Next(0, 10000)).ToArray();

            //Create a stopwatch to measure time taken by sorting algorithms
            Stopwatch stopwatch = new ();
            //Measure time taken by Merge Sort
            int[] mergeSortArray = (int[])testArray.Clone();
            stopwatch.Start();
            MergeSort(mergeSortArray);
            stopwatch.Stop();
            var mergeSortTime = stopwatch.ElapsedMilliseconds;
            System.Console.WriteLine("Sorted Array using Merge Sort: " + string.Join(", ", mergeSortArray));
            System.Console.WriteLine("Merge Sort Time: " + mergeSortTime + " ms");

            //Measure time taken by Quick Sort
            int[] quickSortArray = (int[])testArray.Clone();
            stopwatch.Reset();
            stopwatch.Start();
            QuickSort(quickSortArray);
            stopwatch.Stop();
            var quickSortTime = stopwatch.ElapsedMilliseconds;
            System.Console.WriteLine("Sorted Array using Quick Sort: " + string.Join(", ", quickSortArray));
            System.Console.WriteLine("Quick Sort Time: " + quickSortTime + " ms");

            //Final verdict
            System.Console.WriteLine("Sorting Completed. Merge Sort took " + mergeSortTime + " ms.");
            System.Console.WriteLine("Sorting Completed. Quick Sort took " + quickSortTime + " ms.");
        }

        //Lets start with Merge Sort
        static void MergeSort(int[] array)
        {
            //Base case
            if(array.Length <= 1) return;
            int midPoint = array.Length / 2;
            int[]leftArray = GetSubArray(array, 0, midPoint - 1);
            int[]rightArray = GetSubArray(array, midPoint, array.Length - 1);
            MergeSort(leftArray);
            MergeSort(rightArray);
            //Array is sorted, now merge
            int i = 0, j = 0, k = 0;
            //Merge the two arrays
            while (i < leftArray.Length && j < rightArray.Length)
            {
                if(leftArray[i] <= rightArray[j])
                {
                    array[k++] = leftArray[i++];
                }
                else
                {
                    array[k++] = rightArray[j++];
                }
            }
            while (i < leftArray.Length)
            {
                array[k++] = leftArray[i++];
            }
            while (j < rightArray.Length)
            {
                array[k++] = rightArray[j++];
            }
        }

        static int[] GetSubArray(int[] array, int startIndex, int endIndex)
        {
            int length = endIndex - startIndex + 1;
            int[] subArray = new int[length];
            Array.Copy(array, startIndex, subArray, 0, length);
            return subArray;
        }

        //Next is Quick Sort
        static void QuickSort(int[] array)
        {
            QuickSortHelper(array, 0, array.Length - 1);
        }

        static void QuickSortHelper(int[] array, int low, int high)
        {
            //Base case
            if (low >= high) return;
            //Select pivot
            int pivot = array[high];
            //create marker 
            int j = low - 1; //marker for smaller element
            //loop through the array
            for (int i = low; i < high; i++)
            {
                if(array[i] <= pivot)
                {
                    j++;
                    //swap array[i] and array[j]
                    (array[j], array[i]) = (array[i], array[j]);
                }
            }
            //swap pivot into correct position
            int p = j + 1;
            (array[p], array[high]) = (array[high], array[p]);
            //recursively sort left and right subarrays
            QuickSortHelper(array, low, p - 1);
            QuickSortHelper(array, p + 1, high);    
        }
    }
}