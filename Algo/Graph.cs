using System;
using System.Collections.Generic;

namespace Demo.BenchmarkDotNet.Algo
{
    /***********************************************************
     *  Undirected Graph
          1
         / \
        2   3

        Adjacency list: 
                    {1:{2, 3}, 2:{1}, 3:{1}}}
        basically,  vertex 1 has neighbors 2 and 3, 
                    vertex 2 has 1 as a neighbor,
                    vertex 3 also has 1 as a neighbor
    ***********************************************************/
    public class Graph<T>
    {
        // The keys are the vertices and the value of each vertex is its set of neighbors.
        public Dictionary<T, HashSet<T>> AdjacencyList { get; } = new();

        public Graph(IEnumerable<T> vertices)
        {
            foreach (T vertex in vertices)
            {
                _ = AddVertex(vertex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertices">The vertices (aka nodes)</param>
        /// <param name="edges">The edges (aka lines that connect nodes)</param>
        public Graph(T[] vertices, HashSet<T>[] edges)
        {
            foreach (T vertex in vertices)
            {
                _ = AddVertex(vertex);
            }

            for (int i = 0; i < vertices.Length; i++)
            {
                AddEdge(vertices[i], edges[i]);
            }
        }

        public bool AddVertex(T vertex)
        {
            if (AdjacencyList.ContainsKey(vertex))
            {
                return false;
            }

            AdjacencyList.Add(vertex, new HashSet<T>());
            return true;
        }

        public void AddEdge(T vertex, HashSet<T> neighbors)
        {
            ArgumentNullException.ThrowIfNull(neighbors, nameof(neighbors));

            // If not already there, add
            _ = AddVertex(vertex);

            foreach (T neighbor in neighbors)
            {
                _ = AddVertex(neighbor);

                _ = AdjacencyList[vertex].Add(neighbor);
                _ = AdjacencyList[neighbor].Add(vertex);
            }
        }
    }
}
