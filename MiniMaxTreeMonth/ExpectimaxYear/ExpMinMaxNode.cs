using CommonClasses;
using MiniMaxTreeMonth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpectimaxYear
{
    public class ExpMinMaxNode<T> : INode<T> where T : IGameState<T>, IEquatable<T>
    {
        public float? Score { get; set; }
        public NodeType Type
        {
            get
            {
                if (isMaximizer) return NodeType.Maximizer;
                else return NodeType.Minimizer;
            }
            set { }
        }
        public IGameState<T> State { get; set; }
        public List<INode<T>> Children { get; set; }

        public bool isMaximizer => State.isMaximizer;

        public float Chance { get; set; }



        public ExpMinMaxNode(IGameState<T> value, int? score = null)
        {
            State = value;
            Score = score;

            if (isMaximizer) Chance = .9f;
            else Chance = 1f;

            Children = new();
        }



        public List<INode<T>> GenerateChildren()
        {
            
            /*
            if (isMaximizer)
            {
                //CREATING FIRST LAYER OF MINIMZER
                /*
                ExpMinMaxNode<T> minTemp9 = new ExpMinMaxNode<T>(State, .9f);
                minTemp9.Type = NodeType.Minimizer;
                ExpMinMaxNode<T> minTemp1 = new ExpMinMaxNode<T>(State, .1f);
                minTemp1.Type = NodeType.Minimizer;
                List<INode<T>> minimizerTemp = new();
                minimizerTemp.Add(minTemp9);
                minimizerTemp.Add(minTemp1);


                


                //GIVING FIRST LAYER OF MINIMZER THEIR PROPER CHILDREN
                if (temp.Count > 0)
                {
                    for (int i = 0; i < minimizerTemp.Count; i++)
                    {
                        for (int i2 = 0; i2 < temp.Count; i2++)
                        { 
                            minimizerTemp[i].Children.Add(new ExpHumanNode<T>(temp[i2]));
                            
                        }

                    }
                }

                Children = minimizerTemp;
            }

                */



            List<IGameState<T>> temp = State.ChildBuilder();

            //creating minimizer nodes
            if (isMaximizer)
            {

                if (temp.Count > 0)
                {
                    for (int i = 0; i < temp.Count; i++)
                    {
                        Children.Add(new ExpMinMaxNode<T>(temp[i]));
                    }
                }


            }

            //Creating Maximizer Nodes
            else
            {
                if (temp.Count > 0)
                {
                    for (int i = 0; i < temp.Count; i++)
                    {
                        Children.Add(new ExpMinMaxNode<T>(temp[i]));
                    }
                }
            }

            return Children;
        }



        public void ScoreFunction(float? ScoreHolder)
        {
            if (Children.Count == 0)
            {
                Score = State.EndState();
                return;
            }

            else
            {

                if (isMaximizer)
                {
                    if (Score < ScoreHolder || Score == null)
                    {
                        Score = ScoreHolder;
                    }
                }
                else if (isMaximizer != true)
                {
                    if (Score > ScoreHolder || Score == null)
                    {
                        Score = ScoreHolder;
                    }
                }
            }

        }
        public INode<T> ReturnNextNode()
        {
            float? scoreHolder = Children[0].Score;
            int index = 0;

            for (int i = 0; i < Children.Count; i++)
            {
                if (Children[i].Score > scoreHolder && isMaximizer)
                {
                    scoreHolder = Children[i].Score;

                    index = i;
                }
                else if (Children[i].Score < scoreHolder && isMaximizer != true)
                {
                    scoreHolder = Children[i].Score;

                    index = i;
                }
            }

            return Children[index];
        }
    }
}
