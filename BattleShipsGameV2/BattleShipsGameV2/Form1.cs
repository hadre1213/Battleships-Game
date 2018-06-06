using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShipsGameV2
{
    public partial class Form1 : Form
    {
        List<Button> playerPosition;
        List<Button> enemyPosition;
        List<Button> allPlayerPosition;
        List<Button> allEnemyPosition;
        List<Button> listIfReset1 = new List<Button> { };
        List<Button> listIfReset2 = new List<Button> { };
        bool turn = true;
        bool gameSetup = true;
        Random rand = new Random();
        int totalShips = 4; // player 1 number of ships
        int totalEnemy = 4; // player 2 number of ships
        int rounds = 12;
        int playerTotalScore = 0;
        int player2TotalScore = 0;
        int positionTurn = 0;

        public Form1()
        {
            InitializeComponent();
            loadButtons();
            pictureBox4.Visible = true;
  



        }



        private void playerPicksPosition(object sender, EventArgs e)
        {
            if (gameSetup == true)
            {
                var button = (Button)sender; // which button was clicked
                button.Enabled = false;
                button.BackColor = System.Drawing.Color.ForestGreen;
                if (totalShips > 0)
                {
                    if (turn == true)
                    {

                        totalShips--;
                        listIfReset1.Add(button);
                        playerPosition.Remove(button); // delete button from List (I want to know which button has ship on it)

                    }
                    if (totalShips == 0)
                    {
                        endTurnButton.Visible = true;
                        whoShoots();
                    }

                }

                if (totalEnemy > 0)
                {
                    if (turn == false)
                    {

                        totalEnemy--;
                        listIfReset2.Add(button);
                        enemyPosition.Remove(button);


                        if (totalEnemy == 0)
                        {
                            endTurnButton.Visible = true;
                            whoShoots();
                        }
                    }
                }
            }

            if (gameSetup == false)
            {
                resetButton.Visible = false;
                whoShoots();
                var button = (Button)sender; // which button was clicked
                button.Enabled = false;
                if (turn == true)//player 1 turn
                {
                    rounds++;

                    if (!enemyPosition.Contains(button))
                    {
                        hitOrMiss.Text = "Hit";
                        button.BackColor = Color.Red;
                        playerTotalScore++;
                        whoWins();
                    }
                    else
                    {
                        hitOrMiss.Text = "Miss";
                        button.BackColor = Color.Blue;
                        turn = !turn;
                        whoShoots();

                    }

                }
                else // player 2 turn
                {
                    rounds++;

                    if (!playerPosition.Contains(button))
                    {
                        hitOrMiss.Text = "Hit";
                        button.BackColor = Color.Red;
                        player2TotalScore++;
                        whoWins();

                    }
                    else
                    {
                        hitOrMiss.Text = "Miss";
                        button.BackColor = Color.Blue;
                        turn = !turn;
                        whoShoots();


                    }
                }

            }
        }

        private void loadButtons()
        {
            allPlayerPosition = new List<Button> { a1, a2, a3, a4, a5, a6, b1, b2, b3, b4, b5, b6, c1, c2, c3, c4, c5, c6, d1, d2, d3, d4, d5, d6, e1, e2, e3, e4, e5, e6, f1, f2, f3, f4, f5, f6 };
            playerPosition = new List<Button> { a1, a2, a3, a4, a5, a6, b1, b2, b3, b4, b5, b6, c1, c2, c3, c4, c5, c6, d1, d2, d3, d4, d5, d6, e1, e2, e3, e4, e5, e6, f1, f2, f3, f4, f5, f6 };
            allEnemyPosition = new List<Button> { a1e, a2e, a3e, a4e, a5e, a6e, b1e, b2e, b3e, b4e, b5e, b6e, c1e, c2e, c3e, c4e, c5e, c6e, d1e, d2e, d3e, d4e, d5e, d6e, e1e, e2e, e3e, e4e, e5e, e6e, f1e, f2e, f3e, f4e, f5e, f6e };
            enemyPosition = new List<Button> { a1e, a2e, a3e, a4e, a5e, a6e, b1e, b2e, b3e, b4e, b5e, b6e, c1e, c2e, c3e, c4e, c5e, c6e, d1e, d2e, d3e, d4e, d5e, d6e, e1e, e2e, e3e, e4e, e5e, e6e, f1e, f2e, f3e, f4e, f5e, f6e };
        }

        private void loadPlayer2Buttons()
        {
            allEnemyPosition = new List<Button> { a1e, a2e, a3e, a4e, a5e, a6e, b1e, b2e, b3e, b4e, b5e, b6e, c1e, c2e, c3e, c4e, c5e, c6e, d1e, d2e, d3e, d4e, d5e, d6e, e1e, e2e, e3e, e4e, e5e, e6e, f1e, f2e, f3e, f4e, f5e, f6e };
            enemyPosition = new List<Button> { a1e, a2e, a3e, a4e, a5e, a6e, b1e, b2e, b3e, b4e, b5e, b6e, c1e, c2e, c3e, c4e, c5e, c6e, d1e, d2e, d3e, d4e, d5e, d6e, e1e, e2e, e3e, e4e, e5e, e6e, f1e, f2e, f3e, f4e, f5e, f6e };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(playerPosition.Count.ToString() + " " + enemyPosition.Count.ToString());

        }

        private void endTurn_Click(object sender, EventArgs e)
        {
            turn = !turn;
            pictureBox3.Visible = !turn;
            pictureBox4.Visible = turn;
            rounds++;
            positionTurn++;
            if (positionTurn == 2)
            {
                pictureBox3.Visible = !turn;
                pictureBox4.Visible = !turn;
                endTurnButton.Visible = false;
                hideShips();
                gameSetup = false;
                whoShoots();
            }

            if (totalShips == 0)
            {
                endTurnButton.Visible = false; // button dissappears after player 1 ends ship deployment
            }
        }

        private void hideShips()
        {
            foreach (Control c in Controls)
            {
                if (c is Button)
                {
                    c.BackColor = Color.Transparent; // make buttons transparent after deploying ships
                    c.Enabled = true; // enable all buttons
                }
            }
        }

        private void whoShoots()
        {
            if (turn == true)
            {
                whoseTurnLabel.Text = "Player 1 shoots!";
                foreach (Control c in Controls)
                {
                    if (c is Button && allPlayerPosition.Contains(c))
                    {
                        c.Enabled = false;
                    }
                    else
                    {
                        c.Enabled = true;
                    }
                }
                if(gameSetup == false)
                {
                    whoseTurnLabel.Visible = true;
                    whoseTurnLabel.BackColor = Color.GreenYellow;
                }
            }
            else if (turn == false)
            {
                whoseTurnLabel.Text = "Player 2 shoots!";
                foreach (Control c in Controls)
                {
                    if (c is Button && allEnemyPosition.Contains(c))
                    {
                        c.Enabled = false;
                    }
                    else
                    {
                        c.Enabled = true;
                    }
                }
            }


        }

        private void whoWins()
        {
            if (playerTotalScore == 4)
            {
                MessageBox.Show("Player 1 won", "Bravo!");
                Close();
            }
            else if (player2TotalScore == 4)
            {
                MessageBox.Show("Player 2 won", "Bravo!");
                Close();
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (gameSetup == true)
                {
                    if (c is Button && (listIfReset1.Contains(c) && turn == true))
                    {
                        c.BackColor = Color.Transparent;
                        c.Enabled = true;
                        totalShips = 4;
                        endTurnButton.Visible = false;
                        loadButtons();
                        hideShips();
                        endTurnButton.BackColor = Color.GreenYellow;
                        resetButton.BackColor = Color.GreenYellow;
                    }
                    if (c is Button && (listIfReset2.Contains(c) && turn == false))
                    {
                        c.BackColor = Color.Transparent;
                        c.Enabled = true;
                        totalEnemy = 4;
                        endTurnButton.Visible = false;
                        loadPlayer2Buttons();
                        hideShips();
                        endTurnButton.BackColor = Color.GreenYellow;
                        resetButton.BackColor = Color.GreenYellow;
                    }
                }
            }
        }
    }
}