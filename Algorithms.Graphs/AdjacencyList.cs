using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Graphs
{
    public class AdjacencyList : IGraph
    {
	    private readonly Dictionary<Tuple<int, int>, int> _backingStore;
	    private readonly Dictionary<int, List<int>> _adjacencyList;
	    public AdjacencyList(int size, bool isUndirected)
	    {
		    NumberOfVertex = size;
		    IsUndirected = isUndirected;
			_backingStore = new Dictionary<Tuple<int, int>, int>();
			_adjacencyList = new Dictionary<int, List<int>>();
	    }

	    public void AddVertex()
	    {
		    ++NumberOfVertex;
	    }

	    public void AddEdge(int vertexOne, int vertexTwo, int weight = 0)
	    {
			if (vertexOne > NumberOfVertex || vertexTwo > NumberOfVertex
			                                               || vertexOne < 0 || vertexTwo < 0)
		    {
			    throw new IndexOutOfRangeException();
		    }

		    AddEdgeInternal(vertexOne, vertexTwo, weight);
		    if (IsUndirected)
		    {
			    AddEdgeInternal(vertexTwo, vertexOne, weight);
		    }
		}

	    private void AddEdgeInternal(int vertexOne, int vertexTwo, int weight)
	    {
		    var edge = new Tuple<int, int>(vertexOne, vertexTwo);
		    if (_backingStore.ContainsKey(edge))
		    {
			    _backingStore.Remove(edge);
			    --NumberOfEdges;
		    }
		    
			_backingStore.Add(edge, weight);
		    ++NumberOfEdges;

	        if (_adjacencyList.ContainsKey(vertexOne))
	        {
	            if (!_adjacencyList[vertexOne].Contains(vertexTwo))
	            {
	                _adjacencyList[vertexOne].Add(vertexTwo);
	            }
	        }
	        else
	        {
                _adjacencyList.Add(vertexOne, new List<int>(vertexTwo));
	        }
	    }

	    public int GetEdgeWeight(int vertexOne, int vertexTwo)
	    {
			if (PathExist(vertexOne, vertexTwo))
		    {
				return _backingStore[new Tuple<int, int>(vertexOne, vertexTwo)];
		    }

		    throw new InvalidOperationException("Vertices are not connected");
	    }

	    public bool PathExist(int vertexOne, int vertexTwo)
	    {
			if (vertexOne > NumberOfVertex || vertexTwo > NumberOfVertex
			                               || vertexOne < 0 || vertexTwo < 0)
		    {
			    throw new IndexOutOfRangeException();
		    }

		    var edge = new Tuple<int, int>(vertexOne, vertexTwo);
		    if (_backingStore.ContainsKey(edge))
		    {
			    return true;
		    }

		    return false;
	    }

	    public List<int> GetReachableNeighbours(int startingVertex)
	    {
	        if (startingVertex > NumberOfVertex || startingVertex < 0)
	        {
	            throw new IndexOutOfRangeException();
	        }

	        return _adjacencyList[startingVertex].ToList();
	    }

	    public int NumberOfEdges { get; private set; }
	    public int NumberOfVertex { get; private set; }
	    public bool IsUndirected { get; }
    }
}
