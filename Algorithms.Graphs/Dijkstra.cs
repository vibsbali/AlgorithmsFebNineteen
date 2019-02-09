using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs
{
   public class Dijkstra : IGraphSearch
   {
      internal struct Node
      {
         public int Vertex { get; set; }
         public int Weight { get; set; }

         public Node(int vertex, int weight)
         {
            Vertex = vertex;
            Weight = weight;
         }
      }

      private readonly IGraph _graph;
      private readonly IDictionary<int, Node> _parentMap;

      public Dijkstra(IGraph graph)
      {
         _graph = graph;
         _parentMap = new Dictionary<int, Node>();
      }

      public bool CanFind(int startingVertex, int goalVertex)
      {
         if (startingVertex <= 0) throw new ArgumentOutOfRangeException(nameof(startingVertex));
         if (goalVertex <= 0) throw new ArgumentOutOfRangeException(nameof(goalVertex));

         StartingVertex = startingVertex;
         GoalVertex = goalVertex;

         var listOfVisited = new List<int>();
         if (startingVertex == goalVertex)
         {
            return true;
         }

         var minHeap = new List<Node>
         {
            new Node(startingVertex, 0)
         };

         while (minHeap.Count > 0)
         {
            //Order by weight 
            var curr = minHeap.OrderBy(i => i.Weight).First();
            minHeap.Remove(curr);

            var currentVertex = curr.Vertex;
            var weight = curr.Weight;

            if (currentVertex == goalVertex)
            {
               return true;
            }

            if (listOfVisited.Contains(currentVertex))
            {
               continue;
            }

            listOfVisited.Add(currentVertex);

            var neighbours = _graph.GetReachableNeighbours(currentVertex);
            foreach (var neighbour  in neighbours.Where(n => !listOfVisited.Contains(n)))
            {
               var edgeWeight = _graph.GetEdgeWeight(currentVertex, neighbour);
               var cumulativeWeight = edgeWeight + weight;

               //if we have already added the node and that node's weight is less than revised weight we simple move on!
               //Otherwise we remove that node from the heap and parent 
               if (minHeap.Any(n => n.Vertex == neighbour))
               {
                  var node = minHeap.Single(n => n.Vertex == neighbour);
                  if (node.Weight > cumulativeWeight)
                  {
                     minHeap.Remove(node);
                     _parentMap.Remove(neighbour);
                  }
                  else
                  {
                     continue;
                  }
               }

               minHeap.Add(new Node(neighbour, cumulativeWeight));
               _parentMap.Add(neighbour, new Node(currentVertex, cumulativeWeight));
            }
         }

         return false;
      }

      private int GoalVertex { get; set; }

      private int StartingVertex { get; set; }

      public List<int> PathToGoal()
      {
         var stack = new Stack<int>();
         stack.Push(GoalVertex);
         while (true)
         {
            var parent = _parentMap[GoalVertex];
            stack.Push(parent.Vertex);
            if (parent.Vertex == StartingVertex)
            {
               return stack.ToList();
            }
         }
      }
   }
}
