using System;
using System.Collections.Generic;

namespace Algorithms.Graphs
{
	public class AdjacencyMatrix : IGraph
	{
		private int[,] _backingStore;
		private readonly Dictionary<Tuple<int, int>, int> _edges;
		public AdjacencyMatrix(int size, bool isUndirected)
		{
			_backingStore = new int[size,size];
			_edges = new Dictionary<Tuple<int, int>, int>();
			IsUndirected = isUndirected;
			NumberOfVertex = size;
		}

		public void AddVertex()
		{
			++NumberOfVertex;
			var temp = new int[NumberOfVertex, NumberOfVertex];
			for (int i = 0; i < _backingStore.GetUpperBound(0); i++)
			{
				for (int j = 0; j < _backingStore.GetUpperBound(1); j++)
				{
					temp[i, j] = _backingStore[i, j];
				}
			}

			_backingStore = temp;
		}

		public void AddEdge(int vertexOne, int vertexTwo, int weight = 0)
		{
			if (vertexOne > _backingStore.GetUpperBound(0) || vertexTwo > _backingStore.GetUpperBound(0) 
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
			_backingStore[vertexOne, vertexTwo] = 1;
			var tuple = new Tuple<int, int>(vertexOne, vertexTwo);
			if (_edges.ContainsKey(tuple))
			{
				_edges.Remove(tuple);
				--NumberOfEdges;
			}
			_edges.Add(tuple, weight);
			++NumberOfEdges;
		}

		public int GetEdgeWeight(int vertexOne, int vertexTwo)
		{
			if (vertexOne > _backingStore.GetUpperBound(0) || vertexTwo > _backingStore.GetUpperBound(0)
			                                               || vertexOne < 0 || vertexTwo < 0)
			{
				throw new IndexOutOfRangeException();
			}

			//If not connected throw error
			if (_backingStore[vertexOne, vertexTwo] != 1)
			{
				throw new InvalidOperationException("Vertices are not connected");
			}

			var edge = new Tuple<int, int>(vertexOne, vertexTwo);
			return _edges[edge];
		}

		public bool PathExist(int vertexOne, int vertexTwo)
		{
			if (vertexOne > _backingStore.GetUpperBound(0) || vertexTwo > _backingStore.GetUpperBound(0)
			                                               || vertexOne < 0 || vertexTwo < 0)
			{
				throw new IndexOutOfRangeException();
			}

			return _backingStore[vertexOne, vertexTwo] == 1;
		}

		public List<int> GetReachableNeighbours(int startingVertex)
		{
			if (startingVertex > _backingStore.GetUpperBound(0) || startingVertex < 0)
			{
				throw new IndexOutOfRangeException();
			}

			var listOfNodes = new List<int>();
			for (int i = 0; i < _backingStore.GetUpperBound(1); i++)
			{
				if (_backingStore[startingVertex, i] == 1)
				{
					listOfNodes.Add(i);
				}
			}

			return listOfNodes;
		}

		public int NumberOfEdges { get; private set; }
		public int NumberOfVertex { get; private set; }
		public bool IsUndirected { get; }
	}
}