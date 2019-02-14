using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class MergeSort
    {
	    public void Sort<T>(T[] arrayToSort)
			where T : IComparable<T>
	    {
		    if (arrayToSort.Length <= 0)
		    {
			    return;
		    }

		    SortRecursively(arrayToSort);
	    }

	    private void SortRecursively<T>(T[] arrayToSort) where T : IComparable<T>
	    {
		    if (arrayToSort.Length <= 1)
		    {
			    return;
		    }

		    var midPoint = arrayToSort.Length / 2;
			var leftArray = new T[midPoint];
		    var rightArray = new T[arrayToSort.Length - midPoint];

		    Array.Copy(arrayToSort, 0, leftArray, 0, leftArray.Length);
			Array.Copy(arrayToSort, midPoint, rightArray, 0, rightArray.Length);
			SortRecursively<T>(leftArray);
			SortRecursively<T>(rightArray);
		    Merge(arrayToSort, leftArray, rightArray);
	    }

	    private void Merge<T>(T[] arrayToSort, T[] leftArray, T[] rightArray) where T : IComparable<T>
	    {
		    var i = 0;
		    var j = 0;
		    var k = 0;
		    do
		    {
			    if (leftArray[i].CompareTo(rightArray[j]) < 0)
			    {
				    arrayToSort[k++] = leftArray[i++];
			    }
			    else
			    {
				    arrayToSort[k++] = rightArray[j++];
			    }
		    } while (i < leftArray.Length && j < rightArray.Length);

		    if (i < leftArray.Length)
		    {
			    do
			    {
				    arrayToSort[k++] = leftArray[i++];
			    } while (i < leftArray.Length);
		    }

		    if (j < rightArray.Length)
		    {
				do
				{
					arrayToSort[k++] = rightArray[j++];
				} while (j < rightArray.Length);
			}
		    
	    }
    }
}

