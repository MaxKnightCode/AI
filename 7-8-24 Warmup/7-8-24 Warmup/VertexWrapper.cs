using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GraphProgram
{
    internal class VertexWrapper<T> where T : IEquatable<T>
    {
        public Vertex<T> Vertex;
        public VertexWrapper<T> Previous;
        public float Cost;


        public VertexWrapper(Vertex<T> vertex, VertexWrapper<T> previous = null, float cost = 0) 
        {
            Vertex = vertex;
            Previous = previous;
            Cost = cost;
        }

        public List<VertexWrapper<T>> FronteirWrapReturn(VertexWrapper<T> Pointer, Func<Vertex<T>, Vertex<T>, Edge<T>> EdgeFinder)
        {
            List<VertexWrapper<T>> WrappedNeighbors = new();

            //returns wrapped neighbors with updated costs


            for(int i = 0; i< Pointer.Vertex.NeighborCount; i++)//neighbor wrapping
            {
                float newCost = Pointer.Cost + EdgeFinder(Pointer.Vertex, Pointer.Vertex.Neighbors[i].EndingPoint).Distance;
                WrappedNeighbors.Add(new VertexWrapper<T>(Pointer.Vertex.Neighbors[i].EndingPoint, Pointer, newCost));
            }

            return WrappedNeighbors;

        }




    }
}
