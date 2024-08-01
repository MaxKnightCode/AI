using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClasses
{
    public interface IGameState<TSelf> where TSelf : IGameState<TSelf>, IEquatable<TSelf>
    {
        bool IsTerminal { get; set; }
        bool isMaximizer { get; }

        public bool Equals(TSelf other);
        

        //public Node<TSelf> BuildTree();

        public int? EndState();


        public List<IGameState<TSelf>> ChildBuilder();
    }
}
