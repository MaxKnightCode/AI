using CommonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace MiniMaxTreeMonth
{
    public class Node<T> where T : IGameState<T>, IEquatable<T>
    {
        public int? Score { get; set; }

        public IGameState<T> Value;

        public bool isMaximizer
        {
            get;
            set;
        }

        public List<Node<T>> Children { get; private set; }

        public Node(IGameState<T> value, int? score = null)
        {
            Value = value;

            Score = score;

            Children = new();
        }

        public virtual Node<T> BuildTree()
        {
            Node<T> Pointer = new Node<T>(Value);

            BuildTreeHelper(Pointer);

            return Pointer;
        }


        public int? BuildTreeHelper(Node<T> Pointer)
        {
            List<IGameState<T>> PointerChildren = Pointer.Value.ChildBuilder();



            for (int i = 0; i < PointerChildren.Count; i++)
            {
                Pointer.Children.Add(new Node<T>(PointerChildren[i]));
            }


            if (Pointer.Children.Count == 0)
            {
                //Score this node! THIS IS THE BASE CASE
                //return Score for this node
                Pointer.Score = Pointer.Value.EndState()!.Value;
                return Pointer.Score;
            }

            //loop over all children, and keep traack of the lowest or highest score.
            for (int i = 0; i < Pointer.Children.Count; i++)
            {
                //recursion
                BuildTreeHelper(Pointer.Children[i]);

                //UPDATE SCORE HERE
                int? ChildScoreHolder = Pointer.Children[i].Score;
                Pointer.ScoreFcn(ChildScoreHolder);
            }

            //RETURN SCORE
            return Pointer.Score;

        }


        public void ScoreFcn(int? ScoreHolder)
        {
            //set the pointer's score
            if (Value.isMaximizer)
            {
                if (Score < ScoreHolder || Score == null)
                {
                    Score = ScoreHolder;
                }
            }
            else if (Value.isMaximizer != true)
            {
                if (Score > ScoreHolder || Score == null)
                {
                    Score = ScoreHolder;
                }
            }
        }

    }
}
