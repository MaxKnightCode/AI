using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CommonClasses
{
    public class TicTacState : IGameState<TicTacState>, IEquatable<TicTacState>
    {
        //board
        public TileEnum Turn;

        public bool isMaximizer => Turn == TileEnum.X;



        public TicTacState(IGameState<TicTacState> Value)
        {


        }

        public bool Equals(TicTacState? other)
        {
            if (other == null) return false;

            bool Result = true;

            for (int xi = 0; xi < 3; xi++)
            {
                for (int yi = 0; yi < 3; yi++)
                {
                    if (other.GameState[xi,yi] != this.GameState[xi,yi])
                    {
                        Result = false;
                        return Result;
                    }

                }
            }

            return Result;

        }



        public TileEnum OppositeTurn
        {
            get
            {
                if (Turn == TileEnum.X)
                {
                    return TileEnum.O;
                }
                if (Turn == TileEnum.O)
                {
                    return TileEnum.X;
                }
                return TileEnum.Empty;
            }
        }

        public TileEnum Player;
        public TileEnum Opponent
        {
            get
            {
                if(Player == TileEnum.X)
                {
                    return TileEnum.O;
                }
                else if (Player == TileEnum.O)
                {
                    return TileEnum.X;
                }
                else
                {
                    return TileEnum.Empty;
                }
            }
        }


        public bool IsTerminal { get; set; }



        public TileEnum[,] GameState;

        public TicTacState(TileEnum turn, TileEnum[,] gameState)
        {

            Turn = turn;

            GameState = gameState;
        }








        //public Node<TicTacState> BuildTree()
        //{
        //    Node<TicTacState> Pointer = new Node<TicTacState>(this);

        //    //this

        //    BuildTreeHelper(Pointer);

        //    return Pointer;
        //}


        //public int? BuildTreeHelper(Node<TicTacState> Pointer)//build tree, it can return a int!!!
        //{
        //    List<Node<TicTacState>> PointerChildren = BTNeighborBuilder(Pointer);

        //    if (PointerChildren.Count == 0)
        //    {
        //        //Score this node! THIS IS THE BASE CASE
        //        //return Score for this node
        //        return Pointer.Value.IsEndstate()!.Value;
        //    }

        //    //loop over all children, and keep traack of the lowest or highest score.
        //    for (int i = 0; i < PointerChildren.Count; i++)
        //    {
        //        //recursion
        //        BuildTreeHelper(PointerChildren[i]);

        //        //UPDATE SCORE HERE
        //        int? ChildScoreHolder = PointerChildren[i].Score;
        //        ScoreFcn(Pointer, ChildScoreHolder);
        //    }

        //    //RETURN SCORE
        //    return Pointer.Value.Score;

        //}






        //
        public List<IGameState<TicTacState>> ChildBuilder() //Get successors
                                                                                    // this should build and return a list of all the children so the build tree can loop it
        {
            List<IGameState<TicTacState>> Result = new ();

            if (EndState() == null)
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        if (GameState[x, y] == TileEnum.Empty)
                        {
                            TileEnum[,] tempster = new TileEnum[3, 3];


                            for (int xi = 0; xi < 3; xi++)
                            {
                                for (int yi = 0; yi < 3; yi++)
                                {
                                    tempster[xi, yi] = GameState[xi, yi];
                                }
                            }

                            tempster[x, y] = Turn;

                            TicTacState Tempy = new TicTacState(OppositeTurn, tempster);
                            Tempy.Player = Player;

                            Result.Add(Tempy);
                        }
                    }
                }
            }

            return Result;
        }





        public int? EndState()
        {
            if (IsWin(Player))
            {
                IsTerminal = true;
                return 1;
            }

            if (IsWin(Opponent))
            {
                IsTerminal = true;
                return -1;
            }

            if (IsDraw())
            {
                IsTerminal = true;
                return 0;
            }

            IsTerminal = false;
            return null;
        }

        private bool IsDraw()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (GameState[x, y] == TileEnum.Empty)
                    {
                        return false;
                    }
                }
            }

            if (IsWin(Player))
            {
                return false;
            }

            if (IsWin(Opponent))
            {
                return false;
            }

            return true;
        }

        private bool IsWin(TileEnum PlayerHolder)
        {
            for (int x = 0; x < 3; x++)//Horizontal Checks
            {
                if (GameState[x, 0] != TileEnum.Empty && GameState[x, 1] != TileEnum.Empty && GameState[x, 2] != TileEnum.Empty)
                {
                    if (GameState[x, 0] == GameState[x, 1] && GameState[x, 0] == GameState[x, 2] && GameState[x, 1] == GameState[x, 2] && PlayerHolder == GameState[x, 0])
                    {
                        return true;
                    }
                }
            }

            for (int y = 0; y < 3; y++)//vertical Checks
            {
                if (GameState[0, y] != TileEnum.Empty && GameState[1, y] != TileEnum.Empty && GameState[2, y] != TileEnum.Empty)
                {
                    if (GameState[0, y] == GameState[1, y] && GameState[0, y] == GameState[2, y] && GameState[1, y] == GameState[2, y] && PlayerHolder == GameState[0, y])
                    {
                        return true;
                    }
                }
            }

            //Diagonal Checks
            //[0,0][0,1][0,2]
            //[1,0][1,1][1,2]
            //[2,0][2,1][2,2]

            if (GameState[0, 0] != TileEnum.Empty && GameState[1, 1] != TileEnum.Empty && GameState[2, 2] != TileEnum.Empty)
            {
                if (GameState[0, 0] == GameState[1, 1] && GameState[0, 0] == GameState[2, 2] && GameState[1, 1] == GameState[2, 2] && PlayerHolder == GameState[0, 0])
                {
                    return true;
                }
            }

            if (GameState[2, 0] != TileEnum.Empty && GameState[1, 1] != TileEnum.Empty && GameState[0, 2] != TileEnum.Empty)
            {
                if (GameState[0, 2] == GameState[1, 1] && GameState[2, 0] == GameState[0, 2] && GameState[1, 1] == GameState[2, 0] && PlayerHolder == GameState[0, 2])
                {
                    return true;
                }
            }

            return false;
        }

    }
}
