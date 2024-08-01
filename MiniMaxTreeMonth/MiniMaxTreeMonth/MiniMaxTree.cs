using CommonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMaxTreeMonth
{
    public class MiniMaxTree<TState> where TState : IGameState<TState>, IEquatable<TState>
    {
        private Node<TState> AIGameState; 

        public MiniMaxTree(Node<TState> startingPoint)
        {
            AIGameState = startingPoint;
        }

        public void TreeBuilder()
        {
            AIGameState = AIGameState.BuildTree();
        }

        public void UpdateState(TState CurrentState)
        {
            for (int i = 0; i < AIGameState.Children.Count; i++)
            {
                if (AIGameState.Children[i].Value.Equals(CurrentState))
                {
                    AIGameState = AIGameState.Children[i];
                    return;
                }
            }
        }

        public IGameState<TState> ReturnBestMove(IGameState<TState> CurrentState)
        {

            int? intHolder = AIGameState.Children[0].Score!.Value;
            int index = 0;
            bool isThisMax = CurrentState.isMaximizer;

            for (int i = 1; i < AIGameState.Children.Count; i++)
            {
                int thisChildScore = AIGameState.Children[i].Score!.Value;

                if (thisChildScore > intHolder && isThisMax)
                {
                    intHolder = thisChildScore;

                    index = i;
                }
                else if(thisChildScore < intHolder && isThisMax == false)
                {
                    intHolder = thisChildScore;

                    index = i;
                }
            }

            AIGameState = AIGameState.Children[index];
            return AIGameState.Value;
        }
    }
}
