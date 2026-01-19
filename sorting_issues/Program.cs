using System;

namespace sorting_issues
{
	public class Program
	{
		static void Main(string[] args)
		{
			int[] sortArrayBySelection = { 2, 10, -3, -7, 11, 5, 8, 18, 1, 27, -32, -99};
			SelectionSortMethod(sortArrayBySelection);

            int[] sortArrayByMerge = { 12, 1, -3, -17, 6, 15, -8, 18, 10, 37, 20, -99 };
            MergeSortMethod(sortArrayByMerge);

            int[] sortArrayByInsertion = { 22, 100, -13, -27, 1, 25, -8, -18, -1, 47, 16, -99 };
            InsertionSortMethod(sortArrayByInsertion);

			Console.WriteLine("This is  for selection sorting with the while loop!");
			Console.WriteLine(string.Join(" / ", sortArrayBySelection));

			Console.WriteLine("\n");

			Console.WriteLine("This is for Merge sorting with the while loop");
			Console.WriteLine(string.Join(" + ", sortArrayByMerge));

            Console.WriteLine("\n");
            Console.WriteLine("This is for Insertion sorting with the while loop");
            Console.WriteLine(string.Join(" * ", sortArrayByInsertion));

            Console.ReadKey();
		}

		static void SelectionSortMethod(int[] x)
		{
			int i = 0;
			while (i < x.Length - 1)
			{
				int minValue = x[i];
				int minIndex = i;

				int j = i + 1;
				while(j < x.Length)
				{
					if (x[j] < minValue)
					{
						minValue = x[j];
						minIndex = j;
					}
					j++;
				}
				(x[i], x[minIndex]) = (x[minIndex], x[i]);
                i++;
            }
		}
		
		static void InsertionSortMethod(int[] y)
		{
            // The first element is assumed to be already sorted
            // We start from the second element and insert it into the sorted part
            for (int i = 1; i < y.Length; i++)
			{
                // j tracks the position of the element as it moves left
                int j = i ;
                // Move the element left while it is smaller than the previous one
                while (j > 0 && y[j] < y[j - 1])
				{
					//then swap
					(y[j], y[j - 1]) = (y[j - 1], y[j]);

                    // Move left to check if it needs to go further
                    j--;
				}
			}
		}

		//Please note that the wermacht, AMGN, AMGS, Blitzkreig, heer words
		//Are just mere data containers for learning and no reference nor interest in
		//Nazi Germany army of 1930s. this is just for pure learning interest

		static void MergeSortMethod(int[] heer)
		{
			//Create a base case to terminate the recursive method
			if (heer.Length <= 1) return;

			//Find the midpoint
			int blitzkreig = heer.Length / 2;
			//Append midpoint to two aux unitsint

			int[] ArmyGroupNorth = Wehrmachtsgliederung(heer, 0, blitzkreig - 1);
			int[] ArmyGroupSouth = Wehrmachtsgliederung(heer, blitzkreig, heer.Length - 1);

			//Break the array further
			MergeSortMethod(ArmyGroupNorth);
			MergeSortMethod(ArmyGroupSouth);

			//Now time to sort back together
			//create aux for groups and parentgroup
			int a = 0, b = 0, c = 0;
			while(a < ArmyGroupNorth.Length && b < ArmyGroupSouth.Length)
			{
				if (ArmyGroupNorth[a] < ArmyGroupSouth[b])
				{
					//Append the smallest into the parentgrouppe
					heer[c++] = ArmyGroupNorth[a++];
				}
				else
				{
					heer[c++] = ArmyGroupSouth[b++];
				}
			}

			while(a < ArmyGroupNorth.Length)
			{
				heer[c++] = ArmyGroupNorth[a++];
			}

			while(b < ArmyGroupSouth.Length)
			{
				heer[c++] = ArmyGroupSouth[b++];
			}

        }

		static int[] Wehrmachtsgliederung(int[] x, int Anfang, int Ende)
		{
			int[] resultat = new int[Ende - Anfang + 1];
			Array.Copy(x, Anfang, resultat, 0, Ende - Anfang + 1);
			return resultat;
		}

    }
}

