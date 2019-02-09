using System;
using System.Collections.Generic;

namespace Algorithms.StringSearch
{
   public class BoyerMoreHorspool
   {
      public bool CanFind(string originalString, string substring)
      {
         var badMatchTable = CreateBadMatchTable(substring);
         var substringZeroBasedLength = substring.Length - 1;

         var i = substringZeroBasedLength;
         while (i < originalString.Length - 1)
         {
            var idx = i;
            var k = substringZeroBasedLength;
            while (k >= 0 && originalString[idx] == substring[k])
            {
               --idx;
               --k;
            }

            if (k == -1)
            {
               return true;
            }

            if (badMatchTable.ContainsKey(originalString[idx]))
            {
               i = i + badMatchTable[originalString[idx]];
            }
            else
            {
               i = i + substring.Length;
            }
         }

         return false;
      }

      private static Dictionary<char, int> CreateBadMatchTable(string substring)
      {
         var badMatchTable = new Dictionary<char, int>();
         for (int i = substring.Length - 2, j = 1; i >= 0; i--, j++)
         {
            if (!badMatchTable.ContainsKey(substring[i]))
            {
               badMatchTable.Add(substring[i], j);
            }
         }

         return badMatchTable;
      }
   }
}
