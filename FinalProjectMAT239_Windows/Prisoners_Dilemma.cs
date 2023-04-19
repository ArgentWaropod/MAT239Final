using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectMAT239_Windows
{
    public partial class Prisoners_Dilemma : Form
    {
        TextBox[] die = new TextBox[4];
        PictureBox[] coins = new PictureBox[4];
        PictureBox[] statuses = new PictureBox[4];

        public Prisoners_Dilemma()
        {
            InitializeComponent();
            die[0] = prisoner1die;
            die[1] = prisoner2die;
            die[2] = prisoner3die;
            die[3] = prisoner4die;
            coins[0] = Prisoner1Coin;
            coins[1] = Prisoner2Coin;
            coins[2] = Prisoner3Coin;
            coins[3] = Prisoner4Coin;
            statuses[0] = Prisoner1;
            statuses[1] = Prisoner2;
            statuses[2] = Prisoner3;
            statuses[3] = Prisoner4;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Scenario1Button_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (isMassSim)
            {
                float successes = 0;
                for (int i = 0; i < 10000; i++)
                {
                    if (scenarioOne(isMassSim))
                    {
                        successes++;
                    }
                }
                listBox1.Items.Add("The Success rate of this mass simulation was " + ((successes / 10000) * 100) + "%");
            }
            else
            {
                scenarioOne(isMassSim);
            }
        }

        bool isMassSim;

        int rollADice()
        {
            //Rolls a 6 sided dice
            Random rand = new Random();
            return rand.Next(1, 6);
        }

        int flipACoin()
        {
            //Flips a coin by picking either 0 (Heads) or 1 (Tails)
            Random rand = new Random();
            return rand.Next(2);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            isMassSim = checkBox1.Checked;
        }

        bool scenarioOne(bool isMassSim) //isMassSim removes any use of Console.WriteLine for the purposes of keeping the program clean and not filled with WriteLines
        {
            ClearBoard();
            int total = 0; //Keep track of total value of the rolls
            for (int i = 0; i < 4; i++)
            {
                //Prisoner i rolls a dice and adds their result to the total value
                int rollNumber = rollADice();
                if (!isMassSim)
                {
                    die[i].Text = rollNumber.ToString();
                    listBox1.Items.Add("Prisoner " + i + " rolled a " + rollNumber);
                }
                total += rollNumber;
            }
            //Now that the total number of prisoners have rolled, the verdict must be determined
            if (total >= 8)
            {
                if (!isMassSim)
                {
                    listBox1.Items.Add("Total is greater than 8, everyone is free to go!");

                }
                return true;
            }
            else
            {
                if (!isMassSim)
                {
                    listBox1.Items.Add("Total is less than 8, you'll be imprisoned forever!");

                }
                return false;
            }


        }

        bool scenarioTwo(bool isMassSim)
        {
            ClearBoard();
            for (int i = 0; i < 4; i++)
            {
                if (flipACoin() == 0)
                {

                    //if a prisoner gets heads, there's no need to check the results of the other prisoners, so just return back to menu;
                    if (!isMassSim)
                    {
                        coins[i].BackgroundImage = Properties.Resources.heads;
                        listBox1.Items.Add("Prisoner " + i + " got heads. Everyone is imprisoned forever!");
                        for (int j = 0; j < 4; j++)
                        {
                            statuses[j].BackColor = Color.Red;
                        }

                    }

                    return false;
                }
                else
                {
                    if (!isMassSim)
                    {
                        coins[i].BackgroundImage = Properties.Resources.tails;
                    }
                }
            }
            //The only way we can get here is if every prisoner got tails.
            if (!isMassSim)
            {
                listBox1.Items.Add("All of the prisoners got tails, everyone is free to go!");
                for (int j = 0; j < 4; j++)
                {
                    statuses[j].BackColor = Color.Green;
                }

            }

            return true;
        }

        bool scenarioThree(bool isMassSim)
        {
            ClearBoard();
            for (int i = 0; i < 4; i++) //4 Prisoners to go through
            {
                if (!isMassSim)
                {
                    listBox1.Items.Add("Prisoner " + i + "'s turn");
                }
                if (flipACoin() == 0) //First flip a coin, if they get heads, then they must roll a dice. No need to do anything if they get tails
                {
                    if (!isMassSim)
                    {
                        coins[i].BackgroundImage = Properties.Resources.heads;
                        listBox1.Items.Add("Prisoner " + i + " got heads, they must now roll a die");
                    }
                    int result = rollADice();
                    die[i].Text = result.ToString();
                    if (result > 1) //Now they need to roll a die. If they get a result greater than 1, then the results of any subsequent attempts do not matter. It returns false, a failure
                    {
                        if (!isMassSim)
                        {
                            listBox1.Items.Add("Prisoner " + i + " rolled greater than a 1, everyone is imprisoned forever");
                            for (int j = 0; j < 4; j++)
                            {
                                statuses[j].BackColor = Color.Red;
                            }
                        }
                        return false;
                    }
                    else //If the player rolls a 1, the previous block won't run.
                    {
                        if (!isMassSim)
                        {
                            listBox1.Items.Add("Prisoner " + i + " rolled a 1, you are safe for now...");
                        }
                    }
                }
                else
                {
                    if (!isMassSim)
                    {
                        coins[i].BackgroundImage = Properties.Resources.tails;
                    }
                }
            }
            if (!isMassSim) //The only way you can reach this part of the code is if the prisoners only got tails or 1s. It returns True, a success
            {
                listBox1.Items.Add("The prisoners flipped tails or rolled 1s. You are free to go");
                for (int j = 0; j < 4; j++)
                {
                    statuses[j].BackColor = Color.Green;
                }
            }
            return true;
        }

        private void Scenario2Button_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (isMassSim)
            {
                float successes = 0;
                for (int i = 0; i < 10000; i++)
                {
                    if (scenarioTwo(isMassSim))
                    {
                        successes++;
                    }
                }
                listBox1.Items.Add("The Success rate of this mass simulation was " + ((successes / 10000) * 100) + "%");
            }
            else
            {
                scenarioTwo(isMassSim);
            }
        }

        void ClearBoard()
        {
            for (int i = 0; i < 4; i++)
            {
                die[i].Clear(); //Clear each of the die in Prisoner's Dilemma game
                coins[i].BackgroundImage = null; //Clear each of the coins
                statuses[i].BackColor = Color.Gray; //Clear each of the statuses
            }
        }

        private void Scenario3Button_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (isMassSim)
            {
                float successes = 0;
                for (int i = 0; i < 10000; i++)
                {
                    if (scenarioThree(isMassSim))
                    {
                        successes++;
                    }
                }
                listBox1.Items.Add("The Success rate of this mass simulation was " + ((successes / 10000) * 100) + "%");
            }
            else
            {
                scenarioThree(isMassSim);
            }
        }
    }
}
