using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Graphs
{
   public class DepthFirstSearch : IGraphSearch
   {
      private readonly IGraph _graph;
      private int StartingVertex { get; set; }
      private int GoalVertex { get; set; }
      private readonly IDictionary<int, int> _parentMap;

      public DepthFirstSearch(IGraph graph)
      {
         _graph = graph;
         _parentMap = new Dictionary<int, int>();
      }

      public bool CanFind(int startingVertex, int goalVertex)
      {
         if (startingVertex == goalVertex)
         {
            return true;
         }

         StartingVertex = startingVertex;
         GoalVertex = goalVertex;

         var stack = new Stack<int>();
         var visited = new List<int>();
         stack.Push(startingVertex);
         while (stack.Count != 0)
         {
            var current = stack.Pop();
            if (visited.Contains(current))
            {
               continue;
            }

            var neighbors = _graph.GetReachableNeighbours(current);

            foreach (var neighbor in neighbors.Where(n => !visited.Contains(n)))
            {
               _parentMap.Add(neighbor, current);
               if (neighbor == goalVertex)
               {
                  return true;
               }
            }
         }

         return false;
      }
        
      public List<int> PathToGoal()
      {
         var path = new Stack<int>();
         path.Push(GoalVertex);
         while (true)
         {
            var parent = _parentMap[path.Peek()];
            path.Push(parent);
            if(path.Peek() == StartingVertex)
               break;
         }

         return path.ToList();
      }
   }
}