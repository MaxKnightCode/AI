using _7_8_24_Warmup;
using System.Drawing;

namespace GraphProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            GraphMaker NewGraph = new GraphMaker(5, 4);
            Graph<Point> TheGraph = NewGraph.output;


            TheGraph.Goal = TheGraph.Search(new Point(3, 2));


            //List<Edge<Point>> check1 = TheGraph.GraphTraversal(TheGraph.Search(new Point(0,0)), TheGraph.Search(new Point(3, 2)), TheGraph.DepthFirstSearch);
            //List<Edge<Point>> check2 = TheGraph.GraphTraversal(TheGraph.Search(new Point(0, 0)), TheGraph.Search(new Point(3, 2)), TheGraph.BreadthFirstSearch);
            List<Edge<Point>> check2 = TheGraph.GraphTraversal(TheGraph.Search(new Point(0, 0)), TheGraph.UniformSearch);



            ;
        }
    }
}