using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 * The program is to play a game on the board
 * 
 * Revision History
 *  Oct 21, 2019 Created by Yunice Kim
 *  
 */
namespace YKimAssignment2
{
    public partial class frmPlay : Form
    {
        //declare global variable
        PicBoxTile[,] board;
        //to hold information of the hero picture
        PicBoxTile heroPicBoxTile;
        PicBoxTile picBoxDestination;
        PicBoxTile picBoxBoxTile;
        //to initialize the current's hero location
        PicBoxTile currentHeroPostion;
        
        int heroRow = 0;
        int heroCol = 0;
        int boxRow = 0;
        int boxCol = 0;
        int totalPush = 0;
        int totalMove = 0;
        int destinationCount = 0;
        int boxCount = 0;        
        const int INIT_LEFT = 20;
        const int INIT_TOP = 20;
        const int WIDTH = 50;
        const int HEIGHT = 50;

        //to check whether or not all the destination's locations match all the box's locations
        bool isDestination = false;
        Dictionary<int, Match> allDestination;
        Dictionary<int, Match> allBox;
        Match match;

        public frmPlay()
        {
            InitializeComponent();
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<int> lstNumFromFile = new List<int>();
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "Game Board (*.game)|*.game";
            openDlg.ShowDialog();
            string path = openDlg.FileName;

            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(openDlg.FileName))
                {
                    while (reader.EndOfStream == false)
                    {
                        //read all the elements to the list of Number
                        lstNumFromFile.Add(int.Parse(reader.ReadLine()));
                    }
                }

                ClearBoard();
                DrawBoard(lstNumFromFile);
            }
            else 
            {
                MessageBox.Show("No file to open");
            }
        }

        /// <summary>
        /// Draw the board with all the elements of the list
        /// </summary>
        /// <param name="lstNumFromFile"></param>
        private void DrawBoard(List<int> lstNumFromFile)
        {
            int rowsCount = lstNumFromFile.ElementAt(0); 
            int colsCount = lstNumFromFile.ElementAt(1);
            //set the tile type default value(none)
            TileType activeType = TileType.None;

            //remove the first two element of the int list
            //to calculate the position of TileType easily
            lstNumFromFile.RemoveAt(0);
            lstNumFromFile.RemoveAt(0);

            //to find the exact type position in the list
            //can't use the number of row or column
            //because all row and column's values are between 0 to 7
            int positionOfType = 0;

            //save all elements to the 2 dimension array to check the property of the cell
            board = new PicBoxTile[rowsCount, colsCount];
            //save all destination and box's location infor(row, col) 
            //to compare all the element are the same(finishing condition)
            allDestination = CreateDictionary();
            allBox = CreateDictionary();

            for (int row = 0; row < rowsCount; row++)
            {
                for (int column = 0; column < colsCount; column++)
                {
                    PicBoxTile picBoxTile = new PicBoxTile(row, column);

                    //check the active type from the list to show the right image on the board
                    activeType = (TileType)lstNumFromFile.ElementAt(3 * (positionOfType + 1) - 1);
                    positionOfType++;

                    switch (activeType)
                    {
                        case TileType.None:
                            picBoxTile.Image = null;
                            picBoxTile.Type = TileType.None;
                            picBoxTile.Tag = "";
                            break;
                        case TileType.Hero:
                            picBoxTile.Image = imgLst.Images[1];
                            //hold the hero's position
                            heroRow = row;
                            heroCol = column;
                            picBoxTile.Type = TileType.None;
                            heroPicBoxTile = picBoxTile;
                            break;
                        case TileType.Wall:
                            picBoxTile.Image = imgLst.Images[2];
                            picBoxTile.Type = TileType.Wall;
                            picBoxTile.Tag = "";
                            break;
                        case TileType.Box:
                            picBoxTile.Image = imgLst.Images[3];
                            picBoxTile.Type = TileType.Box;
                            picBoxTile.Tag = "";
                            match = new Match(row, column);
                            //hold the current box's information on the dictionary
                            allBox.Add(boxCount, match);
                            boxCount++;
                            break;
                        case TileType.Destination:
                            picBoxTile.Image = imgLst.Images[4];
                            picBoxTile.Type = TileType.Destination;
                            picBoxTile.Tag = "Destination";
                            match = new Match(row, column);
                            //hold the current destination's information on the dictionary
                            allDestination.Add(destinationCount, match);
                            destinationCount++;
                            break;
                        default:
                            break;
                    }
                    board[row, column] = picBoxTile;
                    pnlGameBoard.Controls.Add(board[row, column]);
                }
            }
        }

        /// <summary>
        /// When click the Left button,
        /// check the before one to move the hero
        /// and move/// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (heroPicBoxTile != null)
            {
                PicBoxTile picBoxTile = GetTile(heroRow, heroCol - 1);

                switch (picBoxTile.Type)
                {
                    case TileType.None:
                        picBoxDestination = new PicBoxTile(heroRow, heroCol);
                        IntializeCurrentHeroLocation();

                        if (CheckDestination(heroRow, heroCol))
                        {
                            SetDestination();
                        }

                        heroCol--;
                        SetHero();

                        txtNumbersOfMove.Text = (++totalMove).ToString();

                        break;
                    case TileType.Hero:
                        //never come to here because Hero is only one to be moved by arrow
                        break;
                    case TileType.Wall:
                        //nothing to happen
                        break;
                    case TileType.Box:
                        PicBoxTile picBoxPreviousTile = GetTile(heroRow, heroCol - 2);
                        
                        if (picBoxPreviousTile.Type == TileType.None)
                        {
                            picBoxDestination = new PicBoxTile(heroRow, heroCol);
                            IntializeCurrentHeroLocation();

                            //check whether or not the current position was destination
                            //if it was destination, show the destination image on the board again
                            if (CheckDestination(heroRow, heroCol))
                            {
                                SetDestination();
                            }

                            //show the image of hero on the board
                            heroCol--;
                            SetHero();

                            //sow the image of box on the board
                            boxRow = heroRow;
                            boxCol = heroCol - 1;
                            SetBox(picBoxPreviousTile);

                            txtNumbersOfMove.Text = (++totalMove).ToString();
                            txtNumbersOfPush.Text = (++totalPush).ToString();
                        }
                        else if (picBoxPreviousTile.Type == TileType.Wall)
                        {
                            //nothing to happen
                        }
                        else if (picBoxPreviousTile.Type == TileType.Destination)
                        {
                            picBoxDestination = new PicBoxTile(heroRow, heroCol);
                            IntializeCurrentHeroLocation();

                            if (CheckDestination(heroRow, heroCol))
                            {
                                SetDestination();
                            }

                            heroCol--;
                            SetHero();

                            boxRow = heroRow;
                            boxCol = heroCol - 1;
                            SetBoxOnDestination(picBoxPreviousTile);

                            txtNumbersOfMove.Text = (++totalMove).ToString();
                            txtNumbersOfPush.Text = (++totalPush).ToString();
                        }

                        UpdateBoxLocationList();
                        CheckFinish();

                        break;
                    case TileType.Destination:
                        picBoxDestination = new PicBoxTile(heroRow, heroCol);
                        IntializeCurrentHeroLocation();

                        if (CheckDestination(heroRow, heroCol))
                        {
                            SetDestination();
                        }

                        heroCol--;
                        SetHero();

                        txtNumbersOfMove.Text = (++totalMove).ToString();

                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// When click the Up button,
        /// check the above one to move the hero
        /// and move
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (heroPicBoxTile != null)
            {
                PicBoxTile picBoxTile = GetTile(heroRow - 1, heroCol);

                switch (picBoxTile.Type)
                {
                    case TileType.None:
                        picBoxDestination = new PicBoxTile(heroRow, heroCol);
                        IntializeCurrentHeroLocation();

                        if (CheckDestination(heroRow, heroCol))
                        {
                            SetDestination();
                        }

                        heroRow--;
                        SetHero();

                        txtNumbersOfMove.Text = (++totalMove).ToString();

                        break;
                    case TileType.Hero:
                        //never come to here because Hero is only one to be moved by arrow
                        break;
                    case TileType.Wall:
                        //nothing to happen
                        break;
                    case TileType.Box:
                        PicBoxTile picBoxPreviousTile = GetTile(heroRow - 2, heroCol);

                        if (picBoxPreviousTile.Type == TileType.None)
                        {
                            picBoxDestination = new PicBoxTile(heroRow, heroCol);
                            IntializeCurrentHeroLocation();

                            if (CheckDestination(heroRow, heroCol))
                            {
                                SetDestination();
                            }

                            heroRow--;
                            SetHero();

                            boxRow = heroRow - 1;
                            boxCol = heroCol;
                            SetBox(picBoxPreviousTile);

                            txtNumbersOfMove.Text = (++totalMove).ToString();
                            txtNumbersOfPush.Text = (++totalPush).ToString();
                        }
                        else if (picBoxPreviousTile.Type == TileType.Wall)
                        {
                            //nothing to happen
                        }
                        else if (picBoxPreviousTile.Type == TileType.Destination)
                        {
                            picBoxDestination = new PicBoxTile(heroRow, heroCol);
                            IntializeCurrentHeroLocation();

                            if (CheckDestination(heroRow, heroCol))
                            {
                                SetDestination();
                            }

                            heroRow--;
                            SetHero();

                            boxRow = heroRow - 1;
                            boxCol = heroCol;
                            SetBoxOnDestination(picBoxPreviousTile);

                            txtNumbersOfMove.Text = (++totalMove).ToString();
                            txtNumbersOfPush.Text = (++totalPush).ToString();
                        }

                        UpdateBoxLocationList();
                        CheckFinish();

                        break;
                    case TileType.Destination:
                        picBoxDestination = new PicBoxTile(heroRow, heroCol);
                        IntializeCurrentHeroLocation();

                        if (CheckDestination(heroRow, heroCol))
                        {
                            SetDestination();
                        }

                        heroRow--;
                        SetHero();

                        txtNumbersOfMove.Text = (++totalMove).ToString();

                        break;
                    default:
                        break;
                }
            }
        }
               
        /// <summary>
        /// When click the right button,
        /// check the after one to move the hero
        /// and move
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRight_Click(object sender, EventArgs e)
        {
            if (heroPicBoxTile != null)
            {
                PicBoxTile picBoxTile = GetTile(heroRow, heroCol + 1);
                
                switch (picBoxTile.Type)
                {
                    case TileType.None:
                        picBoxDestination = new PicBoxTile(heroRow, heroCol);
                        IntializeCurrentHeroLocation();

                        if (CheckDestination(heroRow, heroCol))
                        {
                            SetDestination();
                        }

                        heroCol++;
                        SetHero();

                        txtNumbersOfMove.Text = (++totalMove).ToString();

                        break;
                    case TileType.Hero:
                        //never come to here because Hero is only one to be moved by arrow
                        break;
                    case TileType.Wall:
                        //nothing to happen
                        break;
                    case TileType.Box:
                        PicBoxTile picBoxPreviousTile = GetTile(heroRow, heroCol + 2);

                        if (picBoxPreviousTile.Type == TileType.None)
                        {
                            picBoxDestination = new PicBoxTile(heroRow, heroCol);
                            IntializeCurrentHeroLocation();

                            if (CheckDestination(heroRow, heroCol))
                            {
                                SetDestination();
                            }

                            heroCol++;
                            SetHero();

                            boxRow = heroRow;
                            boxCol = heroCol + 1;
                            SetBox(picBoxPreviousTile);

                            txtNumbersOfMove.Text = (++totalMove).ToString();
                            txtNumbersOfPush.Text = (++totalPush).ToString();
                        }
                        else if (picBoxPreviousTile.Type == TileType.Wall)
                        {
                            //nothing to happen
                        }
                        else if (picBoxPreviousTile.Type == TileType.Destination)
                        {
                            picBoxDestination = new PicBoxTile(heroRow, heroCol);
                            IntializeCurrentHeroLocation();

                            if (CheckDestination(heroRow, heroCol))
                            {
                                SetDestination();
                            }

                            heroCol++;
                            SetHero();

                            boxRow = heroRow;
                            boxCol = heroCol + 1;
                            SetBoxOnDestination(picBoxPreviousTile);

                            txtNumbersOfMove.Text = (++totalMove).ToString();
                            txtNumbersOfPush.Text = (++totalPush).ToString();
                        }

                        UpdateBoxLocationList();
                        CheckFinish();

                        break;
                    case TileType.Destination:
                        picBoxDestination = new PicBoxTile(heroRow, heroCol);
                        IntializeCurrentHeroLocation();

                        if (CheckDestination(heroRow, heroCol))
                        {
                            SetDestination();
                        }

                        heroCol++;
                        SetHero();

                        txtNumbersOfMove.Text = (++totalMove).ToString();

                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// When click the down button,
        /// check the below one to move the hero
        /// and move/// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (heroPicBoxTile != null)
            {
                PicBoxTile picBoxTile = GetTile(heroRow + 1, heroCol);

                switch (picBoxTile.Type)
                {
                    case TileType.None:
                        picBoxDestination = new PicBoxTile(heroRow, heroCol);
                        IntializeCurrentHeroLocation();

                        if (CheckDestination(heroRow, heroCol))
                        {
                            SetDestination();
                        }

                        heroRow++;
                        SetHero();

                        txtNumbersOfMove.Text = (++totalMove).ToString();

                        break;
                    case TileType.Hero:
                        //never come to here because Hero is only one to be moved by arrow
                        break;
                    case TileType.Wall:
                        //nothing to happen
                        break;
                    case TileType.Box:
                        PicBoxTile picBoxPreviousTile = GetTile(heroRow + 2, heroCol);

                        if (picBoxPreviousTile.Type == TileType.None)
                        {
                            picBoxDestination = new PicBoxTile(heroRow, heroCol);
                            IntializeCurrentHeroLocation();

                            if (CheckDestination(heroRow, heroCol))
                            {
                                SetDestination();
                            }

                            heroRow++;
                            SetHero();

                            boxRow = heroRow + 1;
                            boxCol = heroCol;
                            SetBox(picBoxPreviousTile);

                            txtNumbersOfMove.Text = (++totalMove).ToString();
                            txtNumbersOfPush.Text = (++totalPush).ToString();
                        }
                        else if (picBoxPreviousTile.Type == TileType.Wall)
                        {
                            //nothing to happen
                        }
                        else if (picBoxPreviousTile.Type == TileType.Destination)
                        {
                            IntializeCurrentHeroLocation();

                            picBoxDestination = new PicBoxTile(heroRow, heroCol);

                            if (CheckDestination(heroRow, heroCol))
                            {
                                SetDestination();
                            }
                                                        
                            heroRow++;
                            SetHero();

                            boxRow = heroRow + 1;
                            boxCol = heroCol;
                            SetBoxOnDestination(picBoxPreviousTile);

                            txtNumbersOfMove.Text = (++totalMove).ToString();
                            txtNumbersOfPush.Text = (++totalPush).ToString();
                        }

                        UpdateBoxLocationList();
                        CheckFinish();

                        break;
                    case TileType.Destination:
                        picBoxDestination = new PicBoxTile(heroRow, heroCol);
                        IntializeCurrentHeroLocation();

                        if (CheckDestination(heroRow, heroCol))
                        {
                            SetDestination();
                        }

                        heroRow++;
                        SetHero();

                        txtNumbersOfMove.Text = (++totalMove).ToString();

                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Initialize the current hero's information to none
        /// </summary>
        private void IntializeCurrentHeroLocation()
        {
            currentHeroPostion = new PicBoxTile(heroRow, heroCol);

            currentHeroPostion.Type = TileType.None;
            currentHeroPostion.Image = null;
            pnlGameBoard.Controls.Add(currentHeroPostion);
            currentHeroPostion.BringToFront();
        }

        /// <summary>
        /// Exit the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        /// <summary>
        /// Clear all global variable for new game
        /// </summary>
        private void ClearBoard()
        {
            pnlGameBoard.Controls.Clear();
            txtNumbersOfMove.Text = "";
            txtNumbersOfPush.Text = "";
            board = null;
            heroPicBoxTile = null;
            picBoxDestination = null;
            picBoxBoxTile = null;
            heroRow = 0;
            heroCol = 0;
            boxRow = 0;
            boxCol = 0;
            totalPush = 0;
            totalMove = 0;
            destinationCount = 0;
            boxCount = 0;
            isDestination = false;
            allDestination = null;
            allBox = null;
            match = null;
        }

        /// <summary>
        /// Update the position of the image
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private PicBoxTile CalculatePosition(int row, int col)
        {
            PicBoxTile picBoxTile = new PicBoxTile(row, col);
            picBoxTile.Left = INIT_LEFT + WIDTH * col;
            picBoxTile.Top = INIT_TOP + HEIGHT * row;

            return picBoxTile;
        }

        /// <summary>
        /// Get the information of board with the current row and column
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private PicBoxTile GetTile(int row, int col) => board[row, col];

        /// <summary>
        /// Set the current location to show destination image
        /// </summary>
        private void SetDestination()
        {
            picBoxDestination = CalculatePosition(heroRow, heroCol);
            picBoxDestination.Type = TileType.Destination;
            picBoxDestination.Image = imgLst.Images[4];
            pnlGameBoard.Controls.Add(picBoxDestination);
            board[heroRow, heroCol].Type = TileType.Destination;
            board[heroRow, heroCol].Image = imgLst.Images[4];
            picBoxDestination.BringToFront();
        }

        /// <summary>
        /// Set the current location to show box image
        /// </summary>
        /// <param name="picBoxPreviousTile"></param>
        private void SetBox(PicBoxTile picBoxPreviousTile)
        {
            picBoxBoxTile = picBoxPreviousTile;
            picBoxBoxTile = CalculatePosition(boxRow, boxCol);
            picBoxBoxTile.Type = TileType.Box;
            picBoxBoxTile.Image = imgLst.Images[3];
            pnlGameBoard.Controls.Add(picBoxBoxTile);
            board[boxRow, boxCol].Type = TileType.Box;
            board[boxRow, boxCol].Image = imgLst.Images[3];
            picBoxBoxTile.BringToFront();
        }

        /// <summary>
        /// Set the current location to show box image on the destination
        /// </summary>
        /// <param name="picBoxPreviousTile"></param>
        private void SetBoxOnDestination(PicBoxTile picBoxPreviousTile)
        {
            picBoxBoxTile = picBoxPreviousTile;
            picBoxBoxTile = CalculatePosition(boxRow, boxCol);
            picBoxBoxTile.Type = TileType.Box;
            picBoxBoxTile.Image = imgLst.Images[5];
            pnlGameBoard.Controls.Add(picBoxBoxTile);
            board[boxRow, boxCol].Type = TileType.Box;
            board[boxRow, boxCol].Image = imgLst.Images[3];
            picBoxBoxTile.BringToFront();
        }
        /// <summary>
        /// Set the current location to show hero image
        /// </summary>
        private void SetHero()
        {
            heroPicBoxTile = CalculatePosition(heroRow, heroCol);
            heroPicBoxTile.Type = TileType.Hero;
            heroPicBoxTile.Image = imgLst.Images[1];
            pnlGameBoard.Controls.Add(heroPicBoxTile);
            board[heroRow, heroCol].Type = TileType.None;
            board[heroRow, heroCol].Image = null;
            heroPicBoxTile.BringToFront();
        }

        /// <summary>
        /// Check the current location was destination
        /// </summary>
        /// <param name="heroRow"></param>
        /// <param name="heroCol"></param>
        /// <returns></returns>
        private bool CheckDestination(int heroRow, int heroCol)
        {
            isDestination = false;
            if ((string)board[heroRow, heroCol].Tag == "Destination")
            {
                isDestination = true;
            }
            return isDestination;
        }

        /// <summary>
        /// Check whether or not all values of box and destination's dictionary are the same
        /// When all values are the same, show a message box
        /// </summary>
        private void CheckFinish()
        {
            Dictionary<int, Match> tempBoxes = new Dictionary<int, Match>(allBox);
            //foreach (KeyValuePair<int, Match> box in allBox)
            //{
            //    tempBoxes.Add(box.Key, box.Value);
            //}

            foreach (var destination in allDestination)
            {
                foreach (var box in allBox)
                {
                    if (box.Value.Row == destination.Value.Row
                        && box.Value.Col == destination.Value.Col)
                    {
                        tempBoxes.Remove(box.Key);
                    }
                }
            }

            if (tempBoxes.Count == 0)
            {
                if (MessageBox.Show($"Game end!\n Total Moves: {totalMove}\n Total Pushes: {totalPush}")
                            == DialogResult.OK)
                {
                    ClearBoard();
                }
            }
        }

        /// <summary>
        /// Update the dictionary information of the box that moves right now
        /// </summary>
        private void UpdateBoxLocationList()
        {
            Dictionary<int, Match> tempBoxes = new Dictionary<int, Match>(allBox);
            //foreach (KeyValuePair<int, Match> box in allBox)
            //{
            //    tempBoxes.Add(box.Key, box.Value);
            //}

            allBox.Clear();

            foreach (KeyValuePair<int, Match> box in tempBoxes)
            {
                int key = box.Key;
                Match boxValue = box.Value;
                if (heroRow == boxValue.Row && heroCol == boxValue.Col)
                {
                    match = new Match(boxRow, boxCol);
                    allBox.Add(key, match);
                }
                else
                {
                    allBox.Add(key, boxValue);
                }
            }
        }
        
        /// <summary>
        /// Create new dictionary to hold destination and box's all locations
        /// </summary>
        /// <returns></returns>
        private Dictionary<int, Match> CreateDictionary()
        {
            Dictionary<int, Match> allMatch = new Dictionary<int, Match>();

            return allMatch;
        }

    }


}
