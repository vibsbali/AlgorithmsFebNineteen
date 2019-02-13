using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Trees
{
    public class MaxHeap<T>
        where T: IComparable<T>
    {
        private IList<T> BackingStore { get; set; }
	    public int Count { get; private set; }
        public MaxHeap()
        {
            BackingStore = new List<T>();
        }

	    public T Pop()
	    {
		    if (Count <= 0)
		    {
			    throw new InvalidOperationException();
		    }

		    var itemToReturn = BackingStore[0];
		    --Count;
		    BackingStore[0] = BackingStore[Count];
		    BackingStore.RemoveAt(Count); //Same as setting BackingStore[Count] == default(T);
		    SwimDown(0);
		    return itemToReturn;
	    }

	    private void SwimDown(int idx)
	    {
		    var left = idx * 2 + 1;
		    var right = idx * 2 + 2;
		    var lastIdx = Count - 1;

		    if (left > lastIdx)
		    {
			    return;
		    }

		    int idxToCompare;
		    if (right <= lastIdx)
		    {
			    if (BackingStore[left].CompareTo(BackingStore[right]) <= 0)
			    {
				    idxToCompare = right;
			    }
			    else
			    {
				    idxToCompare = left;
			    }
		     }
		    else
		    {
			    idxToCompare = left;
		    }

		    if (BackingStore[idx].CompareTo(BackingStore[idxToCompare]) < 0)
		    {
			    Swap(idx, idxToCompare);
				SwimDown(idxToCompare);
		    }
	    }

	    public void Add(T item)
        {
			BackingStore.Add(item);
	        SwimUp(Count);
	        ++Count;
        }

	    private void SwimUp(int idx)
	    {
		    var parent = (idx - 1) / 2;
		    if (parent >= 0 && BackingStore[parent].CompareTo(BackingStore[idx]) < 0)
		    {
			    Swap(parent, idx);
				SwimUp(parent);
		    }
	    }

	    private void Swap(int left, int right)
	    {
		    var temp = BackingStore[left];
		    BackingStore[left] = BackingStore[right];
		    BackingStore[right] = temp;
	    }
    }

	
}
