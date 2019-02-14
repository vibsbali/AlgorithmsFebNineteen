using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Algorithms.Sorting;


namespace ConsoleRunner
{
	class Program
	{
		static void Main(string[] args)
		{
			var array1 = new[] {4, 2, 12, 5, 9, -3, -54, int.MaxValue, int.MinValue, 43, 987, 4, 3, -54, 4};
			var array2 = new[] {4, 2, 12, 5, 9, -3, -54, int.MaxValue, int.MinValue, 43, 987, 4, 3, -54, 4};
			var array3 = new[] {4, 2, 12, 5, 9, -3, -54, int.MaxValue, int.MinValue, 43, 987, 4, 3, -54, 4};

			new BubbleSort().Sort(array1);
			new InsertionSort().Sort(array2);
			new MergeSort().Sort(array3);

			for (int i = 0; i < array1.Length; i++)
			{
				array1[i] = array1.OrderBy(index => index).ToArray()[i];
				array2[i] = array2.OrderBy(index => index).ToArray()[i];
				array3[i] = array3.OrderBy(index => index).ToArray()[i];
			}
		}
	}


}
