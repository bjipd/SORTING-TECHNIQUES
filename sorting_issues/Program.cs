using System;
using System.Diagnostics;
using System.Linq;

namespace sorting_issues
{
	public class Program
	{
		static void Main(string[] args)
		{
            //STARTit
            //STARTit
            //STARTit 
            //Range an array
            Random randy = new();
			int[] testingArray = Enumerable.Range(1, 10).OrderBy(p => randy.Next()).ToArray();
			
			//We want to clone the testing array
			int[] arrayForMergeSort = (int[])testingArray.Clone();

            //Create a stopwatch 
            Stopwatch stopwatch = Stopwatch.StartNew();
			MergeSorter(arrayForMergeSort);
			stopwatch.Stop();

			Console.WriteLine($"It took about {stopwatch.ElapsedMilliseconds} ms to sort the array using Merge sort");
			Console.WriteLine($"The elements length is {arrayForMergeSort.Count()} " );
            Console.ReadKey();
		}

		
		//THIS PROGRAM IS A SORTING MECHANIC FOR
		//1. MERGE SORT
		//2. QUICK SORT
		//3. BUBBLE SORT 

		static void MergeSorter(int[] arr)
		{
			//The method is a recursive method
			//Create the base case to stop recursion
			if (arr.Length == 1) return;
			//create the midpoint
			int midpoint = arr.Length / 2;
			//Name the two sub arrays
			int[] subArrayOne = GetSubArray(arr, 0, midpoint - 1);
			int[] subArrayTwo = GetSubArray(arr, midpoint, arr.Length - 1);
			//call the method to break it further
			MergeSorter(subArrayOne);
			MergeSorter(subArrayTwo);

			//Merge section
			//Create aux int to index the append elements from subarray to parrent array
			int x = 0, y = 0, z = 0;

			while(x < subArrayOne.Length && y < subArrayTwo.Length)
			{
				if (subArrayOne[x] < subArrayTwo[y])
				{
					arr[z++] = subArrayOne[x++];
				}
				else
				{
					arr[z++] = subArrayTwo[y++];
				}
			}

			while(x < subArrayOne.Length)
			{
				arr[z++] = subArrayOne[x++];
			}

            while (y < subArrayTwo.Length)
            {
                arr[z++] = subArrayTwo[y++];
            }

			foreach(int p in arr)
			{
				Console.WriteLine($"{p} ");
			}
        }

		//This method assigns the divided array to each subarray
		static int[] GetSubArray(int[] ox, int beginIndex, int endIndex)
		{
			//Create the sub array to present. 
			int[] resultArray = new int[endIndex - beginIndex + 1];
			Array.Copy(ox, beginIndex, resultArray, 0, endIndex - beginIndex + 1);
			return resultArray;
		}

		//QUICK SORT METHOD

		static void QuickSortMethod(int[] x)
		{
            //Assuming we were given an array of 5 elements  [ 8, 3, 6, 2, 7 ]
            //QuickSortPart([ 8, 3, 6, 2, 7 ], 0, 5 - 1 = 4);
            QuickSortPart(x, 0, x.Length - 1);
		}

		static void QuickSortPart(int[] x, int beginIndex, int EndIndex)
		{
			//Base case to stop recursion
            if (beginIndex >= EndIndex) return;

			//Choose pivot as the last element of the array
			int pivot = x[EndIndex];

			//The marker or pointer 
			int j = beginIndex - 1;

			for(int i = beginIndex; i < EndIndex; i++)
			{
 				if (x[i] < pivot)
				{
					j++;
					//do a tuple swap
					(x[j], x[i]) = (x[i], x[j]);
				}
			}

			//Swap Pivot to its correct position
			int pivotIndex = j + 1;
			//Swap old pivot value to new pivot Index
			(x[pivotIndex], x[EndIndex]) = (x[EndIndex], x[pivotIndex]);

            //Now QuickSort recursively sort the left side
            QuickSortPart(x, beginIndex, pivotIndex - 1);
            //QuickSort  recursively sort the right side
            QuickSortPart(x, pivotIndex + 1, EndIndex); 
		}
    }
}

