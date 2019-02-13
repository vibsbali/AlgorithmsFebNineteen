using System;
using System.ComponentModel;
using Algorithms.StringSearch;
using Algorithms.Trees;

namespace ConsoleRunner
{
   class Program
   {
      static void Main(string[] args)
      {
         var maxHeap = new MaxHeap<int>();

		  maxHeap.Add(3);
	      if (maxHeap.Pop() != 3)
	      {
		      throw new Exception();
	      }

		  maxHeap.Add(5);
		  maxHeap.Add(6);

	      Console.WriteLine(maxHeap.Pop());
	      Console.WriteLine(maxHeap.Pop());

	      maxHeap.Add(5);
	      maxHeap.Add(6);
	      maxHeap.Add(4);

	      Console.WriteLine();
	      Console.WriteLine(maxHeap.Pop());
	      Console.WriteLine(maxHeap.Pop());
	      Console.WriteLine(maxHeap.Pop());


	      maxHeap.Add(5);
	      maxHeap.Add(6);
	      maxHeap.Add(3);
	      maxHeap.Add(4);

	      Console.WriteLine();
	      Console.WriteLine(maxHeap.Pop());
	      Console.WriteLine(maxHeap.Pop());
	      Console.WriteLine(maxHeap.Pop());
	      Console.WriteLine(maxHeap.Pop());

	      maxHeap.Add(6);
	      maxHeap.Add(8);
	      maxHeap.Add(12);
	      maxHeap.Add(4);
	      maxHeap.Add(-3);

	      Console.WriteLine();
	      Console.WriteLine(maxHeap.Pop());
	      Console.WriteLine(maxHeap.Pop());
	      Console.WriteLine(maxHeap.Pop());
	      Console.WriteLine(maxHeap.Pop());
	      Console.WriteLine(maxHeap.Pop());

	      maxHeap.Add(25);
	      maxHeap.Add(100);
	      maxHeap.Add(125);
	      maxHeap.Add(4);
	      maxHeap.Add(89);
	      maxHeap.Add(25);
	      maxHeap.Add(25);
	      maxHeap.Add(2);
	      maxHeap.Add(225);
	      maxHeap.Add(250);
	      maxHeap.Add(-25);
	      maxHeap.Add(-12);
	      maxHeap.Add(160);
	      maxHeap.Add(1180);

	      Console.WriteLine();
	      while (maxHeap.Count != 0)
	      {
		      Console.WriteLine(maxHeap.Pop());
		      
	      }
		}
	}
}
