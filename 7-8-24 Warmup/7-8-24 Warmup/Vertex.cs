using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProgram
{
    internal class Vertex<T> where T : IEquatable<T>
    {
        public T Value;
        public List<Edge<T>> Neighbors { get; set; }
        public int NeighborCount => Neighbors.Count;

        public Vertex(T value)
        {
            Value = value;
            Neighbors = new List<Edge<T>>();
        }

    }
}
