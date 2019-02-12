using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Trees
{
    public class Tries
    {
        private class TrieNode
        {
            internal string Value { get; set; }
            internal TrieNode[] Next { get; } 
            internal TrieNode(int radixSize)
            {
                Next = new TrieNode[radixSize];
            }
        }

        private const int Radix = 256;
        private TrieNode Root { get; set; }


        public Tries()
        {
            Root = new TrieNode(Radix);
        }

        public void Add(string word)
        {
            word = word.ToLower();
            var current = Root;
            foreach (var character in word)
            {
                if (current.Next[character] == null)
                {
                    current.Next[character] = new TrieNode(Radix);
                }

                current = current.Next[character];
            }

            current.Value = word;
        }

        public List<string> FindWords(string prefix)
        {
            var current = Root;
            var listOfWords = new List<string>();
            prefix = prefix.ToLower();
            foreach (var character in prefix)
            {
                if (current.Next[character] == null)
                {
                    return listOfWords;
                }

                current = current.Next[character];
            }

            var queueOfNodes = new Queue<TrieNode>();
            queueOfNodes.Enqueue(current);
            while (queueOfNodes.Count != 0)
            {
                current = queueOfNodes.Dequeue();
                foreach (var trieNode in current.Next.Where(n => n != null))
                {
                    queueOfNodes.Enqueue(trieNode);
                    if (!string.IsNullOrWhiteSpace(trieNode.Value))
                    {
                        listOfWords.Add(trieNode.Value);
                    }
                }
            }

            return listOfWords;
        }
    }
}
