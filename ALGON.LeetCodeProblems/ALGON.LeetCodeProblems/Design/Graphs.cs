using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Design
{
    public abstract class GraphBase
    {
        //Vertices
        public int V { get; }

        //Adjacency representation
        protected List<int>[] _Adjacencies;

        public GraphBase(int v)
        {
            V = v;

            _Adjacencies = new List<int>[v];
            for (int i = 0; i < _Adjacencies.Length; i++)
                _Adjacencies[i] = new List<int>();
        }

        public virtual IList<int> GetVertexAdjcency(int v)
            => _Adjacencies[v];
    }

    public class UndirectedGraph : GraphBase
    {
        public UndirectedGraph(int v) : base(v)
        {
        }
        
        /// <summary>
        /// Create edge between vertices
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        public void AddEdge(int v, int w) 
        {
            _Adjacencies[v].Add(w);
            _Adjacencies[w].Add(v);
        }
    }

    public class DirectedGraph : GraphBase
    {
        public DirectedGraph(int v) : base(v)
        {
        }

        public DirectedGraph Reverse() 
        {
            var reversed = new DirectedGraph(V);
            for (int v = 0; v < V; v++)
                foreach (var w in GetVertexAdjcency(v))
                    reversed.AddEdge(w, v);
            return reversed;
        }

        /// <summary>
        /// Create direct edge, ex: 1 -> 2, 1 -> 3, 1 -> 4, {1:2,3,4}
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        public void AddEdge(int v, int w) 
        {
            _Adjacencies[v].Add(w);
        }
    }
}
