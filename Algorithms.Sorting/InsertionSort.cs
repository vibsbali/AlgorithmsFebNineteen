using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
	public class InsertionSort
	{
		public void Sort<T>(T[] arrayToSort)
			where T : IComparable<T>
		{
			if (arrayToSort.Length <= 0)
			{
				return;
			}

			for (int i = 1; i < arrayToSort.Length; i++)
			{
				var idx = i;
				while (idx > 0 && arrayToSort[i].CompareTo(arrayToSort[idx - 1]) <= 0)
				{
					--idx;
				}

				if (idx != i)
				{
					var temp = arrayToSort[i];
					Array.Copy(arrayToSort, idx, arrayToSort, idx + 1, i - idx);
					arrayToSort[idx] = temp;
				}
			}
		}
	}
}
