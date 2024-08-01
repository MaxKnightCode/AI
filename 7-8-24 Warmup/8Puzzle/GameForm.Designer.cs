namespace _8Puzzle
{
    partial class GameForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button8 = new Button();
            button7 = new Button();
            blankButton = new Button();
            Shuffle = new Button();
            label1 = new Label();
            ShuffleCount = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(10, 10);
            button1.Name = "button1";
            button1.Size = new Size(150, 150);
            button1.TabIndex = 0;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = false;
            button1.Click += ButtonClick;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(170, 10);
            button2.Name = "button2";
            button2.Size = new Size(150, 150);
            button2.TabIndex = 1;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = false;
            button2.Click += ButtonClick;
            // 
            // button3
            // 
            button3.BackColor = Color.White;
            button3.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(330, 10);
            button3.Name = "button3";
            button3.Size = new Size(150, 150);
            button3.TabIndex = 2;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = false;
            button3.Click += ButtonClick;
            // 
            // button6
            // 
            button6.BackColor = Color.White;
            button6.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            button6.Location = new Point(330, 170);
            button6.Name = "button6";
            button6.Size = new Size(150, 150);
            button6.TabIndex = 5;
            button6.Text = "6";
            button6.UseVisualStyleBackColor = false;
            button6.Click += ButtonClick;
            // 
            // button5
            // 
            button5.BackColor = Color.White;
            button5.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            button5.Location = new Point(170, 170);
            button5.Name = "button5";
            button5.Size = new Size(150, 150);
            button5.TabIndex = 5;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = false;
            button5.Click += ButtonClick;
            // 
            // button4
            // 
            button4.BackColor = Color.White;
            button4.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(10, 170);
            button4.Name = "button4";
            button4.Size = new Size(150, 150);
            button4.TabIndex = 3;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = false;
            button4.Click += ButtonClick;
            // 
            // button8
            // 
            button8.BackColor = Color.White;
            button8.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            button8.Location = new Point(170, 330);
            button8.Name = "button8";
            button8.Size = new Size(150, 150);
            button8.TabIndex = 7;
            button8.Text = "8";
            button8.UseVisualStyleBackColor = false;
            button8.Click += ButtonClick;
            // 
            // button7
            // 
            button7.BackColor = Color.White;
            button7.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            button7.Location = new Point(10, 330);
            button7.Name = "button7";
            button7.Size = new Size(150, 150);
            button7.TabIndex = 6;
            button7.Text = "7";
            button7.UseVisualStyleBackColor = false;
            button7.Click += ButtonClick;
            // 
            // blankButton
            // 
            blankButton.BackColor = Color.White;
            blankButton.Enabled = false;
            blankButton.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            blankButton.Location = new Point(330, 330);
            blankButton.Name = "blankButton";
            blankButton.Size = new Size(150, 150);
            blankButton.TabIndex = 9;
            blankButton.UseVisualStyleBackColor = false;
            blankButton.Click += blankButton_Click;
            // 
            // Shuffle
            // 
            Shuffle.Location = new Point(521, 59);
            Shuffle.Name = "Shuffle";
            Shuffle.Size = new Size(128, 65);
            Shuffle.TabIndex = 10;
            Shuffle.Text = "Shuffle";
            Shuffle.UseVisualStyleBackColor = true;
            Shuffle.Click += Shuffle_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(514, 140);
            label1.Name = "label1";
            label1.Size = new Size(140, 20);
            label1.TabIndex = 11;
            label1.Text = "Steps from Solution";
            // 
            // ShuffleCount
            // 
            ShuffleCount.AutoSize = true;
            ShuffleCount.Location = new Point(573, 170);
            ShuffleCount.Name = "ShuffleCount";
            ShuffleCount.Size = new Size(17, 20);
            ShuffleCount.TabIndex = 12;
            ShuffleCount.Text = "0";
            // 
            // timer1
            // 
            timer1.Interval = 10;
            timer1.Tick += timer1_Tick;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 488);
            Controls.Add(ShuffleCount);
            Controls.Add(label1);
            Controls.Add(Shuffle);
            Controls.Add(blankButton);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "GameForm";
            Text = "8 Puzzle Solver";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button8;
        private Button button7;
        private Button blankButton;
        private Button Shuffle;
        private Label label1;
        private Label ShuffleCount;
        private System.Windows.Forms.Timer timer1;
    }
}