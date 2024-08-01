using CommonClasses;
using MiniMaxTreeMonth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ExpectimaxYear
{
    public class ExpectimaxTree<TState> where TState : IGameState<TState>, IEquatable<TState>
    {

        public INode<TState> CurrentAINode;



        public ExpectimaxTree(INode<TState> StartingNode)
        {
            CurrentAINode = StartingNode;

            BuildTreeHelper(CurrentAINode);
            ;
        }


        public IGameState<TState> ReturnBestMove()
        {
            CurrentAINode = CurrentAINode.ReturnNextNode();
            return CurrentAINode.State;
        }


        public void UpdateState(TState currentState)
        {
            for (int i = 0; i < CurrentAINode.Children.Count; i++)
            {
                if (CurrentAINode.Children[i].State.Equals(currentState))
                {
                    CurrentAINode = CurrentAINode.Children[i];
                    return;
                }
            }
        }


        //Idea corner: PEN-fifteen
        //it is a vape company targeted towards the youth


        public float? BuildTreeHelper(INode<TState> Pointer)
        {
            //GENERATE NODE CHILDREN
            List<INode<TState>> PointerChildren = Pointer.GenerateChildren();

            ;

            if (Pointer.Children.Count == 0)
            {
                //Score this node! THIS IS THE BASE CASE
                //return Score for this node
                Pointer.ScoreFunction();
                return Pointer.Score;
            }



            //loop over all children, and keep traack of the lowest or highest score.
            for (int i = 0; i < Pointer.Children.Count; i++)
            {
                //recursion
                BuildTreeHelper(Pointer.Children[i]);

                //UPDATE SCORE IS INCORRECT!!!!!!!!!!
                float? ChildScoreHolder = Pointer.Children[i].Score;
                Pointer.ScoreFunction(ChildScoreHolder);
            }


            //CALCULATE THE EXPECTIMAX SCORE HERE
            INode<TState> bestNodeTemp = Pointer.ReturnNextNode();
            float? CalculatedScore = bestNodeTemp.Score * Pointer.Chance;

            float? AvgHolder = 0;

            for (int i = 0; i < Pointer.Children.Count; i++)
            {
                AvgHolder += Pointer.Children[i].Score;
            }
            AvgHolder = AvgHolder / Pointer.Children.Count;

            CalculatedScore += AvgHolder;


            Pointer.Score = CalculatedScore;
            //RETURN SCORE
            return Pointer.Score;

        }
    }
}
