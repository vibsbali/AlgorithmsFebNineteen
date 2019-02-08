using System.Collections.Generic;
using System.Text;

namespace Algorithms.Graphs
{
    public interface IGraph
    {
	    void AddVertex();
	    void AddEdge(int vertexOne, int vertexTwo, int weight = 0);
	    int GetEdgeWeight(int vertexOne, int vertexTwo);
	    bool PathExist(int vertexOne, int vertexTwo);
	    List<int> GetReachableNeighbours(int startingVertex);
		int NumberOfEdges { get; }
		int NumberOfVertex { get; }
		bool IsUndirected { get; }
    }
}
