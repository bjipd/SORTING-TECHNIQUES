using System;
using System.Diagnostics;

namespace sorting_issues
{
	public class Program
	{
		static void Main(string[] args)
		{
			//Creating random numbers for the array
			Random random = new();
			int[] arrayTesting = Enumerable.Range(1, 10000).OrderBy(x => random.Next()).ToArray();

			//Create a clone array and stopwatch to know how long it takes to sort array by MERGE SORTING
			int[] arrayByMerge = (int[])arrayTesting.Clone();
			Stopwatch stopwatch = Stopwatch.StartNew();
            MergeSortMethod(arrayByMerge);
			stopwatch.Stop();

			//Announce result
			Console.WriteLine($"This is the time it takes to sort the array of {arrayByMerge.Count()} elements using Merge sort");
			Console.WriteLine("Time taken : " + stopwatch.ElapsedMilliseconds + "ms");


			//DO THE SAME FOR QUICK SORTING
			int[] arrayByQuick = (int[])arrayTesting.Clone();
			stopwatch.Restart();
			QuickSortMethod(arrayByQuick);
			stopwatch.Stop();

            //Announce result
            Console.WriteLine($"This is the time it takes to sort the array of {arrayByQuick.Count()} elements using Quick sort");
            Console.WriteLine("Time taken : " + stopwatch.ElapsedMilliseconds + "ms");

            Console.ReadKey();
		}

		
		//THIS PROGRAM IS A SORTING MECHANIC FOR
		//1. MERGE SORT
		//2. QUICK SORT
		//3. BUBBLE SORT 
		
		static void MergeSortMethod(int[] arrayForMergeSort)
		{
			//Create a base case to terminate the recursive method
			if (arrayForMergeSort.Length <= 1) return;

			//Find the midpoint of the parent array
			int midpoint = arrayForMergeSort.Length / 2;

			//Append midpoint to two aux arrays : using Divide and Conquer
			int[] arrayGroupA = SubArrayMethod(arrayForMergeSort, 0, midpoint - 1);
			int[] arrayGroupB = SubArrayMethod(arrayForMergeSort, midpoint, arrayForMergeSort.Length - 1);

			//Break the array further until it is having just 1 element in each array
			MergeSortMethod(arrayGroupA);
			MergeSortMethod(arrayGroupB);

			//Now time to append elements back together
			//create aux int for all arrays and 
			int a = 0, b = 0, c = 0;
			while(a < arrayGroupA.Length && b < arrayGroupB.Length)
			{
				if (arrayGroupA[a] < arrayGroupB[b])
				{
					//Append the smallest into the parent array
					arrayForMergeSort[c++] = arrayGroupA[a++];
				}
				else
				{
                    arrayForMergeSort[c++] = arrayGroupB[b++];
                }
			}

			while(a < arrayGroupA.Length)
			{
                arrayForMergeSort[c++] = arrayGroupA[a++];
            }
			
			while(b < arrayGroupB.Length)
			{
                arrayForMergeSort[c++] = arrayGroupB[b++];
            }

        }

		static int[] SubArrayMethod(int[] x, int begin, int End)
		{
			int[] resultat = new int[End - begin + 1];
			Array.Copy(x, begin, resultat, 0, End - begin + 1);
			return resultat;
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

