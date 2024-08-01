﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProgram
{
    internal class Edge<T> where T : IEquatable<T>
    {
        public Vertex<T> StartingPoint {  get;  set; }
        public Vertex<T> EndingPoint {  get;  set; }

        public float Distance;

        public Edge(Vertex<T> startingPoint, Vertex<T> endingPoint, float distance = 1)
        {
            StartingPoint = startingPoint;
            EndingPoint = endingPoint;
            Distance = distance;
        }


    }
}
