using CommonClasses;

namespace CommonClasses
{
    public interface INode<TState> where TState : IGameState<TState>, IEquatable<TState>
    {
        public float? Score { get; set; }
        public NodeType Type { get; set; }
        public IGameState<TState> State { get; set; }
        public List<INode<TState>> Children { get; set; }

        


        public float Chance { get; set; }

        public List<INode<TState>> GenerateChildren();

        public void ScoreFunction(float? ScoreHolder = null);

        public INode<TState> ReturnNextNode();

    }
}
