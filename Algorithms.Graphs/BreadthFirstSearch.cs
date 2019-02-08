using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Graphs
{
    public class BreadthFirstSearch : IGraphSearch
    {
        private readonly IGraph _graph;
        private readonly Dictionary<int, int> _parentMap;
        private int StartingVertex { get; set; }
        private int GoalVertex { get; set; }

        public BreadthFirstSearch(IGraph graph)
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

            var visited = new List<int>();
            var queue = new Queue<int>();

            queue.Enqueue(startingVertex);
            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                visited.Add(current);

                var neighbours = _graph.GetReachableNeighbours(current);
                foreach (var unseenNeighbour in neighbours.Where(n => !visited.Contains(n)))
                {
                    _parentMap.Add(unseenNeighbour, current);
                    if (unseenNeighbour == goalVertex)
                    {
                        return true;
                    }

                    queue.Enqueue(unseenNeighbour);
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
                if (path.Peek() == StartingVertex)
                    break;
            }

            return path.ToList();
        }
    }
}