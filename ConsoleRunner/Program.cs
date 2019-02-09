using System;
using Algorithms.StringSearch;

namespace ConsoleRunner
{
   class Program
   {
      static void Main(string[] args)
      {
         var bmh = new BoyerMoreHorspool();
         Console.WriteLine(bmh.CanFind("hardbrushcltheantotohtohbrtoothush", "tooth"));
      }
   }
}
