using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe_Application
{
    public partial class Form1 : Form
    {

        bool turn = true;
        int turn_count = 0;
        static String player1, player2;

        public Form1()
        {
            InitializeComponent();
        }

        public static void setPlayerName(String p1, String p2)
        {
            player1 = p1;
            player2 = p2;
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            lblPlayer1.Text = player1;
            lblPlayer2.Text = player2;

        }

        private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tic-Tac-Toe Game\n Developed by Balong's Team", "About");
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button buttonClicked = (Button) sender;
            if (turn)
                buttonClicked.Text = "X";
            else
                buttonClicked.Text = "O";
            turn = !turn;

            buttonClicked.Enabled = false;

            turn_count++;
            checkWinner();

        }

        private void checkWinner()
        {
            bool checkWinner = false;

            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                checkWinner = true;
            else if((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                checkWinner = true;
            else if((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                checkWinner = true;
            //=================
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                checkWinner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                checkWinner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                checkWinner = true;
            //======================
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                checkWinner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                checkWinner = true;



            if (checkWinner)
            {
                String winner = "";
                if (turn)
                {
                    winner = player2;
                    Ocount.Text = (Int32.Parse(Ocount.Text) + 1).ToString();
                }
                else
                {
                    winner = player1;
                    Xcount.Text = (Int32.Parse(Xcount.Text) + 1).ToString();
                }
                MessageBox.Show("Player " + winner + " Wins!", "Congratulations");
                resetWin();
            }
            else
            {
                if(turn_count == 9)
                {
                    drawCount.Text = (Int32.Parse(drawCount.Text) + 1).ToString();
                    MessageBox.Show("Draw!", "No Winner");
                    resetWin();
                }
            }
        }

        private void disabledButton()
        {
                foreach (Control c in Controls)
                {
                    try
                    {
                        Button b = (Button)c;
                        b.Enabled = false;
                    }
                    catch { }
                    }
        }

        public void resetWin()
        {
            turn = true;
            turn_count = 0;

            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = null;
                }
                catch { }
            }
        }

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;

                foreach (Control c in Controls)
                {
                    try
                    {
                        Button b = (Button)c;
                        b.Enabled = true;
                        b.Text = null;
                    }
                    catch { }
                }
        }

        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button_enter(object sender, EventArgs e)
        {
            Button buttonEnter = (Button) sender;
            if (buttonEnter.Enabled)
            {
                if(turn)
                buttonEnter.Text = "X";
                else
                buttonEnter.Text = "O";
            }

        }

        private void button_leave(object sender, EventArgs e)
        {
            Button buttonEnter = (Button)sender;
            if (buttonEnter.Enabled)
                buttonEnter.Text = "";
        }

        private void ResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Xcount.Text = "0";
            Ocount.Text = "0";
            drawCount.Text = "0";

            turn = true;
            turn_count = 0;


            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = null;
                }
                catch { }
            }

        }
    }
}
