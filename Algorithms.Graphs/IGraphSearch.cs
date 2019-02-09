using System;
using System.Collections.Generic;

namespace Algorithms.Graphs
{
    public interface IGraphSearch
    {
        bool CanFind(int startingVertex, int goalVertex);
        List<int> PathToGoal();
    }
}
