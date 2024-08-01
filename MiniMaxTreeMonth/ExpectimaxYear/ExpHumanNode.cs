using CommonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpectimaxYear
{
    internal class ExpHumanNode<T> : INode<T> where T : IGameState<T>, IEquatable<T>
    {
        public float? Score { get; set; }
        public NodeType Type { get; set; }
        public IGameState<T> State { get; set; }
        public List<INode<T>> Children { get; set; }
        public float Chance { get; set; }


        public ExpHumanNode(IGameState<T> value, float chance = 0, int? score = null)
        {
            State = value;
            Chance = chance;
            Score = score;

            Type = NodeType.Human;

            Children = new();
        }


        public List<INode<T>> GenerateChildren()
        {

            //GENERATE MAXIMIZER NODES

            List<IGameState<T>> temp = State.ChildBuilder();

            if (temp.Count > 0)
            {

                for (int i = 0; i < temp.Count; i++)
                {
                    Children.Add(new ExpMinMaxNode<T>(temp[i]));
                }
            }

            return Children;
        }



        public void ScoreFunction(float? ScoreHolder)
        {
            // % of the next node choice (will be even) * score of all the children

            float? sumn = new();

            if (Children.Count != 0)
            {
                for (int i = 0; i < Children.Count; i++)
                {

                    sumn += Children[i].Score * Children[i].Chance;
                }
            }

            Score = sumn;
        }

        public INode<T> ReturnNextNode()
        {
            throw new NotImplementedException();
        }
    }
}
