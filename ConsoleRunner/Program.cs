using System;
using Algorithms.StringSearch;
using Algorithms.Trees;

namespace ConsoleRunner
{
   class Program
   {
      static void Main(string[] args)
      {
          var trie = new Tries();
          trie.Add("amex");
          trie.Add("amir");
          trie.Add("amritsar");

          var words = trie.FindWords("am");
          foreach (var word in words)
          {
              Console.WriteLine(word);
          }

      }
   }
}
