using System.Drawing;

namespace _8Puzzle
{


    public partial class GameForm : Form
    {
        const int NumShuffles = 100;

        public List<Button> AllButtons = new();
        public GameForm()
        {
            InitializeComponent();

            AllButtons.Add(button1);
            AllButtons.Add(button2);
            AllButtons.Add(button3);
            AllButtons.Add(button4);
            AllButtons.Add(button5);
            AllButtons.Add(button6);
            AllButtons.Add(button7);
            AllButtons.Add(button8);


            ShuffleCount.Text = "0";
        }

        //<Button, Button> Switcher = new();

        private void ButtonClick(object sender, EventArgs e)
        {
            if (sender is not Button button) return;

            for (int i = 0; i < AllButtons.Count; i++)
            {
                AllButtons[i].BackColor = Color.White;
            }

            if (CanMove(button) == MoveDirection.None)
            {
                button.BackColor = Color.Fuchsia;
            }
            else
            {
                Point tempPoint = new();

                tempPoint = button.Location;
                button.Location = blankButton.Location;
                blankButton.Location = tempPoint;
                button.BackColor = Color.LightSeaGreen;
            }

        }

        private MoveDirection CanMove(Button button)
        {
            const int DistanceToButton = 160;

            //left
            if (blankButton.Location.X == button.Location.X - DistanceToButton && blankButton.Location.Y == button.Location.Y) return MoveDirection.Left;
            //right
            if (blankButton.Location.X == button.Location.X + DistanceToButton && blankButton.Location.Y == button.Location.Y) return MoveDirection.Right;
            //up
            if (blankButton.Location.X == button.Location.X && blankButton.Location.Y == button.Location.Y - DistanceToButton) return MoveDirection.Up;
            //down
            if (blankButton.Location.X == button.Location.X && blankButton.Location.Y == button.Location.Y + DistanceToButton) return MoveDirection.Down;


            return MoveDirection.None;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void blankButton_Click(object sender, EventArgs e)
        {

        }

        Random Gen = new Random(1);
        int shuffleTracker;

        private void Shuffle_Click(object sender, EventArgs e)
        {

            if (timer1.Enabled)
            {
                timer1.Enabled = false;
            }
            else
            {
                timer1.Enabled = true;
                shuffleTracker = 0;
            }

        }



        private void timer1_Tick(object sender, EventArgs e)
        {

            if (shuffleTracker < NumShuffles)
            {

                Button temp = AllButtons[Gen.Next(1, 8)];


                for (int f = 0; f < AllButtons.Count; f++)
                {
                    AllButtons[f].BackColor = Color.White;
                }

                if (CanMove(temp) == MoveDirection.None)
                {
                    shuffleTracker--;
                }
                else
                {
                    Point tempPoint = new();

                    tempPoint = temp.Location;
                    temp.Location = blankButton.Location;
                    blankButton.Location = tempPoint;
                    temp.BackColor = Color.LightSeaGreen;


                }

                shuffleTracker++;
                ShuffleCount.Text = shuffleTracker.ToString();
            }


        }
    }
}