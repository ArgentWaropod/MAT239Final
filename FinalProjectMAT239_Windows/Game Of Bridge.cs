using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectMAT239_Windows
{



    public partial class Game_Of_Bridge : Form
    {
        PictureBox[] pictures = new PictureBox[54];
        public Game_Of_Bridge()
        {
            InitializeComponent();
            pictures[0] = Tile1; //This is super ugly but I'm honestly not sure how else to get an array of these picture boxes set up, so you'll just have to deal with it. We can't all be forgiven for our sins.
            pictures[1] = Tile2;
            pictures[2] = Tile3;
            pictures[3] = Tile4;
            pictures[4] = Tile5;
            pictures[5] = Tile6;
            pictures[6] = Tile7;
            pictures[7] = Tile8;
            pictures[8] = Tile9;
            pictures[9] = Tile10;
            pictures[10] = Tile11;
            pictures[11] = Tile12;
            pictures[12] = Tile13;
            pictures[13] = Tile14;
            pictures[14] = Tile15;
            pictures[15] = Tile16;
            pictures[16] = Tile17;
            pictures[17] = Tile18;
            pictures[18] = Tile19;
            pictures[19] = Tile20;
            pictures[20] = Tile21;
            pictures[21] = Tile22;
            pictures[22] = Tile23;
            pictures[23] = Tile24;
            pictures[24] = Tile25;
            pictures[25] = Tile26;
            pictures[26] = Tile27;
            pictures[27] = Tile28;
            pictures[28] = Tile29;
            pictures[29] = Tile30;
            pictures[30] = Tile31;
            pictures[31] = Tile32;
            pictures[32] = Tile33;
            pictures[33] = Tile34;
            pictures[34] = Tile35;
            pictures[35] = Tile36;
            pictures[36] = Tile37;
            pictures[37] = Tile38;
            pictures[38] = Tile39;
            pictures[39] = Tile40;
            pictures[40] = Tile41;
            pictures[41] = Tile42;
            pictures[42] = Tile43;
            pictures[43] = Tile44;
            pictures[44] = Tile45;
            pictures[45] = Tile46;
            pictures[46] = Tile47;
            pictures[47] = Tile48;
            pictures[48] = Tile49;
            pictures[49] = Tile50;
            pictures[50] = Tile51;
            pictures[51] = Tile52; 
            pictures[52] = Tile53; 
            pictures[53] = Tile54;
        }




        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            isMassSim = checkBox1.Checked;
        }

        void ClearBoard()
        {
            for (int i = 0; i < 54; i++)
            {
                pictures[i].BackColor = Color.Gray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isMassSim)
            {
                listBox1.Items.Clear();
                float successes = 0;
                for (int i = 0; i < 10000; i++)
                {

                    successes += GameOfBridge(2, isMassSim);
                }
                listBox1.Items.Add("The average number of victors of this mass sim was " + (successes / 10000));
            }
            else
            {
                listBox1.Items.Clear();
                GameOfBridge(2, isMassSim);
            }
        }

        bool isMassSim;
        bool gameIsActive;

        List<bridgeSegment> setUpBoard(int width) //This function creates the bridge
        {
            Random rand = new Random();
            List<bridgeSegment> bridge = new List<bridgeSegment>(); //Creates the Bridge
            for (int i = 0; i < 18; i++) //For each row of the bridge
            {
                bridge.Add(new bridgeSegment()); //Add a column of the bridge
                bool noRedPlaced = true; //Since both scenarios only require one red tile, this keeps track if there's a red tile
                for (int j = 0; j < width; j++) //For each column piece
                {
                    if ((rand.Next(2) == 1 && noRedPlaced) || (j == width - 1 && noRedPlaced)) //If there isn't a red tile and the builder selects a red tile or if it's the end of the Column and there's been no red
                    {
                        bridge[i].tiles.Add(new bridgeTile(1, false));
                        noRedPlaced = false;
                    }
                    else
                    {
                        bridge[i].tiles.Add(new bridgeTile(2, false));
                    }
                }
            }
            return bridge;
        }

        List<bridgeSegment> setUpKnown(int width) //Same thing as setUpBoard() but instead creates an empty board, representing the player's knowledge of the board (which is why it's empty at first)
        {
            List<bridgeSegment> known = new List<bridgeSegment>();
            for (int i = 0; i < 18; i++)
            {
                known.Add(new bridgeSegment());
                for (int j = 0; j < width; j++)
                {
                    known[i].tiles.Add(new bridgeTile(0, false));
                }
            }
            return known;
        }

        int GameOfBridge(int scenario, bool isMassSim)
        {
            List<bridgeSegment> gameBridge = setUpBoard(scenario); //Set up the board that the game will use
            List<bridgeSegment> knowninfo = setUpKnown(scenario); //Set up a board that represents what the players see
            int totalPlayersCompleted = 0;
            if (!isMassSim)
            {
                colorBoard(gameBridge, scenario);
            }
            for (int players = 0; players < 20; players++) //Number of players
            {
                if (!isMassSim)
                {
                    listBox1.Items.Add("Player " + (players) + " is going now!");
                }
                bool hasPlayerFailed = false;
                for (int segments = 0; segments < 18; segments++) //Number of segments on board is always static
                {
                    int selection = -1; //
                    for (int column = 0; column < scenario; column++) //First, check the known board to see if there are any known green tiles.
                    {
                        if (knowninfo[segments].tiles[column].tileStatus == 2 && knowninfo[segments].tiles[column].isKnown)
                        {
                            selection = column; //If there's a known green tile, use that rather than take a risk on a msytery tile
                        }

                    }
                    while (selection == -1) //If there are no known green tiles, randomly select a tile to try
                    {
                        Random rand = new Random();
                        int testSelection = rand.Next(scenario);
                        if (knowninfo[segments].tiles[testSelection].tileStatus != 1)
                        {
                            selection = testSelection;
                        }
                    }

                    if (!isMassSim)
                    {
                        listBox1.Items.Add("Player " + (players) + " is selecting tile " + (selection) + " on segment " + (segments));
                    }

                    if (gameBridge[segments].tiles[selection].tileStatus == 2) //If this tile is a green tile
                    {
                        if (!isMassSim)
                        {
                            listBox1.Items.Add("Plaier " + (players) + " has made it past segment " + segments);
                        }
                        if (!knowninfo[segments].tiles[selection].isKnown)
                        {
                            knowninfo[segments].tiles[selection].isKnown = true;
                            knowninfo[segments].tiles[selection].tileStatus = 2; //Now future players know this is a green tile
                        }
                    }
                    else //If this tile is a red tile
                    {
                        if (!isMassSim)
                        {
                            listBox1.Items.Add("Player " + (players) + " has stepped on a red tile and fallen!");
                        }
                        knowninfo[segments].tiles[selection].tileStatus = 1; //Now future players know this is a red tile
                        hasPlayerFailed = true;
                        break;
                    }
                }
                if (!hasPlayerFailed)
                {
                    if (!isMassSim)
                    {
                        listBox1.Items.Add("Player " + (players) + " has crossed the bridge succesfully!");
                    }
                    totalPlayersCompleted++;
                }
            }
            if (!isMassSim)
            {
                listBox1.Items.Add("Total players completed bridge = " + totalPlayersCompleted);
            }
            return totalPlayersCompleted;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isMassSim)
            {

                listBox1.Items.Clear();
                float successes = 0;
                for (int i = 0; i < 10000; i++)
                {

                    successes += GameOfBridge(3, isMassSim);
                }
                listBox1.Items.Add("The average number of victors of this mass sim was " + (successes / 10000));
            }
            else
            {
                listBox1.Items.Clear();
                GameOfBridge(3, isMassSim);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void colorBoard(List<bridgeSegment> bridgeList, int scenario)
        {
            if (!isMassSim)
            {
                int total = 0;
                for (int i = 0; i < 18; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (scenario == 2 && j == 2)
                        {
                            pictures[total].BackColor = Color.Gray;
                        }
                        else
                        {
                            if (bridgeList[i].tiles[j].tileStatus == 1 && bridgeList[i].tiles[j] != null)
                            {
                                pictures[total].BackColor = Color.Red;
                            }
                            else
                            {
                                pictures[total].BackColor = Color.Green;
                            }
                        }
                        total++;
                    }
                }
            }
        }
    }

    class bridgeSegment //The Vertical part of the bridge for the Game of Bridge
    {
        public List<bridgeTile> tiles = new List<bridgeTile>();
    }

    class bridgeTile
    {
        public int tileStatus; //0 = Unknown, 1 = Red Tile, 2 = Green Tile
        public bool isKnown;

        public bridgeTile(int r, bool k)
        {
            tileStatus = r;
            isKnown = k;
        }

    }
}
