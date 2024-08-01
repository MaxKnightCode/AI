using System.Data;

namespace CSPWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            //two plus two equals 4
            Variable O = new Variable(new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9});
            Variable R = new Variable(new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Variable C1 = new Variable(new List<int>() { 0, 1 });
            Variable W = new Variable (new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Variable U = new Variable (new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Variable C2 = new Variable(new List<int>() { 0, 1});
            Variable T = new Variable (new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Variable C3 = new Variable(new List<int>() { 0, 1});
            Variable F = new Variable (new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            List<Variable> VarList = new List<Variable>() { O, R, C1, W, U, C2, T, C3, F };

            TwoPlusTwoConstraint twoPlusTwoConstraint = new TwoPlusTwoConstraint();

            RecursiveDescent TwoFourSoln = new RecursiveDescent(VarList, twoPlusTwoConstraint);

            //string result = TwoFourSoln.Solver();

            ;



            // Graph Coloring CSP
            List<Variable> ColoredGraph = new List<Variable>();
            

            for (int i = 0; i < 9; i ++)
            {
                Variable temp = new Variable(new List<int>() { 0, 1, 2 });
                ColoredGraph.Add(temp);
            }

            GraphColoringConstraint GCC = new GraphColoringConstraint();



            RecursiveDescent GCSoln = new RecursiveDescent(ColoredGraph, GCC);

            //string result = GCSoln.Solver();

            //0 = red
            //1 = green
            //2 = blue


            ;



            //Arc Consistency

            List<Variable> ABCGraph = new List<Variable>();


            for (int i = 0; i < 3; i++)
            {
                Variable temp = new Variable(new List<int>() { 1, 2, 3 });
                ABCGraph.Add(temp);
            }

            ABCConstraints ABCC = new ABCConstraints();



            RecursiveDescent ABCSoln = new RecursiveDescent(ABCGraph, ABCC);

            string result = ABCSoln.Solver();

            ;
        }
    }
}