using System;

namespace sorting_issues
{
	public class Program
	{
		static void Main(string[] args)
		{
			int[] numbers = { 1, 9, 17, 0, 2, 6, 22, 5, -8, 14 };
			SelectionSorting(numbers);
			Console.WriteLine("This is the selection sort: ");
			Console.WriteLine(string.Join(",", numbers));

			Console.WriteLine("\nThis is the Merge Sort: ");
			Console.WriteLine(string.Join(" * ", numbers));

            Console.ReadKey();
		}

		static void SelectionSorting(int[] a)
		{
			//TO DOS
			for(int i = 0; i < a.Length - 1; i++)
			{
				int minValue = a[i];
				int minIndex = i;
				for(int j = i + 1; j < a.Length; j++)
				{
					if (a[j] < minValue)
					{
						minValue = a[j];
						minIndex = j;
					}
				}
				//Swapping values using tuple
				(a[i], a[minIndex]) = (a[minIndex], a[i]);
			}

		}

		
		static void MergeSorting(int[] heer)
		{
			//This is written to stop the recursive method.
			if (heer.Length <= 1) return;
			//We use divide and conquer approach in Merge sort
			int midPoint = heer.Length / 2;
			int[] ArmyGroupNorth = GetSubArray(heer, 0, midPoint - 1);
			int[] ArmyGroupSouth = GetSubArray(heer, midPoint, heer.Length - 1);
			//We recurse to break it further
			MergeSorting(ArmyGroupNorth);
			MergeSorting(ArmyGroupSouth);

			//We sort and recall groups back together
			int x = 0, y = 0, z = 0;
			while(x < ArmyGroupNorth.Length && y < ArmyGroupSouth.Length)
			{
				if (ArmyGroupNorth[x] < ArmyGroupSouth[y])
				{
					heer[z] = ArmyGroupNorth[x++];
				}
				else
				{
					heer[z] = ArmyGroupSouth[y++];
				}
				z++;
			}

			while(x < ArmyGroupNorth.Length)
			{
				heer[z++] = ArmyGroupNorth[x++];
			}
			while(y < ArmyGroupSouth.Length)
			{
				heer[z++] = ArmyGroupSouth[y++];
			}
        }

		static int[] GetSubArray(int[] AnyOfArmy, int beginIndex, int endIndex) 
		{
			int[] result = new int[endIndex - beginIndex + 1];
			Array.Copy(AnyOfArmy, beginIndex, result, 0, endIndex - beginIndex + 1);
			return result;
		}


	}
}

