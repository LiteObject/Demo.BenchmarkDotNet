using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.FlowAnalysis;

namespace Demo.BenchmarkDotNet.Algo
{
    /// <summary>
    /// Breadth First Search:
    /// 
    /// Advantages:: A BFS will find the shortest path between the starting point and any other
    /// reachable node. A depth-first search will not necessarily find the shortest path
    ///
    /// Disadvantages: A BFS on a binary tree generally requires more memory than a DFS.
    /// </summary>
    public class BFS
    {
        private Dictionary<int, List<int>> _tree;

        public BFS(Dictionary<int, List<int>> tree)
        {
            /*   1
                / \
               2   3
              /   / \
             4   5   6
             |   |
             7   8
             
             tree.Add(1, new List<int> { 2, 3 });
             tree.Add(2, new List<int> { 4 });
             tree.Add(3, new List<int> { 5, 6 });
             tree.Add(4, new List<int> { 7 });
             tree.Add(5, new List<int> { 8 }); 

            */


            this._tree = tree;
        }

        public void Traverse()
        {
            /*
             * 1. First move horizontally and visit all the nodes of the current layer
             * 2. Move to the next layer
             */

            HashSet<int> visited = new();
            Queue<int> queue = new();
            queue.Enqueue(this._tree.ElementAt(0).Key);

            while (queue.Count > 0)
            {
                var element = queue.Dequeue();

                if(visited.Contains(element))
                {
                    continue;
                }else
                {
                    visited.Add(element);
                }

                List<int> neighbours;

                if(this._tree.TryGetValue(element, out neighbours))
                {
                    
                }
            }
        }
    }
}
