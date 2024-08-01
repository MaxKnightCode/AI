using CommonClasses;
using ExpectimaxYear;
using MiniMaxTreeMonth;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace TicTacToe
{
    public partial class Form1 : Form
    {

        TicTacState ThisGameState { get; set; }

        public PictureBox[,] pictureBoxes = new PictureBox[3, 3];


        Dictionary<TileEnum, Image> Placeholder = new();

        ExpectimaxTree<TicTacState> AI;

        int? Result;


        public Form1()
        {
            InitializeComponent();

            pictureBoxes[0, 0] = pictureBox1;
            pictureBoxes[0, 1] = pictureBox2;
            pictureBoxes[0, 2] = pictureBox3;
            pictureBoxes[1, 0] = pictureBox4;
            pictureBoxes[1, 1] = pictureBox5;
            pictureBoxes[1, 2] = pictureBox6;
            pictureBoxes[2, 0] = pictureBox7;
            pictureBoxes[2, 1] = pictureBox8;
            pictureBoxes[2, 2] = pictureBox9;
            label1.Text = "continue please";


            TileEnum[,] Blank = new TileEnum[3, 3];

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Blank[x, y] = TileEnum.Empty;
                }
            }





            Placeholder.Add(TileEnum.O, Image.FromFile("Resources/flamingO.jpg"));
            Placeholder.Add(TileEnum.X, Image.FromFile("Resources/X.jpg"));
            Placeholder.Add(TileEnum.Empty, Image.FromFile("Resources/download.png"));





            ThisGameState = new TicTacState(TileEnum.X, Blank);
            ThisGameState.Player = TileEnum.X;

            
            AI = new ExpectimaxTree<TicTacState>(new ExpMinMaxNode<TicTacState>(ThisGameState, 1));

            ;

            //ThisGameState.GameState = FormsGSTracker;

            
            ThisGameState = (TicTacState)(AI.ReturnBestMove());
            AI.UpdateState(ThisGameState);
            GameStateDrawer(ThisGameState.GameState, pictureBoxes);
            
        }





        private void pictureBoxClick(object sender, EventArgs e)
        {
            if (Result != 0 || Result != 1 || Result != -1)
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        if (pictureBoxes[x, y] == sender && ThisGameState.GameState[x, y] == TileEnum.Empty)
                        {
                            ThisGameState.GameState[x, y] = ThisGameState.Turn;
                            ThisGameState.Turn = ThisGameState.OppositeTurn;
                        }
                    }
                }


                AI.UpdateState(ThisGameState);


                GameStateDrawer(ThisGameState.GameState, pictureBoxes);


                
                ThisGameState = (TicTacState)(AI.ReturnBestMove());
                AI.UpdateState(ThisGameState);
                

                GameStateDrawer(ThisGameState.GameState, pictureBoxes);


                Result = ThisGameState.EndState();
                if (Result == 1)
                {
                    label1.Text = "X wins!!!!";
                }
                else if (Result == -1)
                {
                    label1.Text = "O Wins!!!!!";
                }
                else if (Result == 0)
                {
                    label1.Text = "Tie!!!!!!!!!!!!!!!!!!!! Dammit";
                }
                else
                {
                    label1.Text = "continue please";
                }
            }

        }



        public void GameStateDrawer(TileEnum[,] GameState, PictureBox[,] pictureBoxes)
        {
            Image SignController;

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (GameState[x, y] == TileEnum.X)
                    {
                        SignController = Placeholder[TileEnum.X];
                        pictureBoxes[x, y].BackgroundImage = SignController;

                    }
                    else if (GameState[x, y] == TileEnum.O)
                    {
                        SignController = Placeholder[TileEnum.O];
                        pictureBoxes[x, y].BackgroundImage = SignController;
                    }
                    else
                    {
                        SignController = Placeholder[TileEnum.Empty];
                        pictureBoxes[x, y].BackgroundImage = SignController;
                    }

                }
            }


        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (pictureBoxes[x, y].BackgroundImage != null)
                    {
                        pictureBoxes[x, y].BackgroundImage = null;
                        ThisGameState.GameState[x, y] = TileEnum.Empty;
                    }
                }
            }

            Result = null;
            label1.Text = "continue please";

        }

        private void AIButton_Click(object sender, EventArgs e)
        {

            //ThisGameState = (TicTacState)(AI.ReturnBestMove(ThisGameState));
            ;



        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{


        //Result = ThisGameState.IsEndstate();


        //if (Result == 1)
        //{
        //    label1.Text = "X wins!!!!";
        //}
        //else if (Result == -1)
        //{
        //    label1.Text = "O Wins!!!!!";
        //}
        //else if (Result == 0)
        //{
        //    label1.Text = "Tie!!!!!!!!!!!!!!!!!!!! Dammit";
        //}
        //else
        //{
        //    label1.Text = "continue please";
        //}


        //}
    }
}