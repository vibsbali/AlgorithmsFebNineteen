using System;

namespace Algorithms.Sorting
{
    public class BubbleSort
    {
	    public void Sort<T>(T[] arrayToSort) where T: IComparable<T>
	    {
		    if (arrayToSort.Length <= 1)
		    {
			    return;
		    }

		    bool hasSwapped;
		    do
		    {
			    hasSwapped = false;
			    for (int i = 1; i < arrayToSort.Length; i++)
			    {
				    if (arrayToSort[i].CompareTo(arrayToSort[i - 1]) < 0)
				    {
					    arrayToSort.Swap(i, i - 1);
					    hasSwapped = true;
				    }
			    }

		    } while (hasSwapped);
	    }

    }

	public static class Extensions
	{
		public static void Swap<T>(this T[] array, int i, int j)
		{
			var temp = array[i];
			array[i] = array[j];
			array[j] = temp;
		}
	}
}
