using System;

namespace sorting_issues
{
	public class Program
	{
		static void Main(string[] args)
		{

            int[] sortArrayByMerge = { 12, 1, -3, -17, 6, 15, -8, 18, 10, 37, 20, -99 };
            MergeSortMethod(sortArrayByMerge);

			Console.WriteLine("This is for Merge sorting with the while loop");
			Console.WriteLine(string.Join(" + ", sortArrayByMerge));


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

		static int[] SubArrayMethod(int[] x, int Anfang, int Ende)
		{
			int[] resultat = new int[Ende - Anfang + 1];
			Array.Copy(x, Anfang, resultat, 0, Ende - Anfang + 1);
			return resultat;
		}
		

    }
}

