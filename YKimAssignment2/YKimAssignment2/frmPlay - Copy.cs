using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YKimAssignment2
{
    public partial class frmPlay : Form
    {
        int heroRow = 0;
        int heroCol = 0;
        PicBoxTile[,] board;
        int totalPush = 0;
        int totalMove = 0;
        int totalDestination = 0;


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
                        lstNumFromFile.Add(int.Parse(reader.ReadLine()));
                    }
                }

                DrawBoard(lstNumFromFile);
            }
            else 
            {
                MessageBox.Show("No file to open");
            }
        }

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

            board = new PicBoxTile[rowsCount, colsCount];

            for (int row = 0; row < rowsCount; row++)
            {
                for (int column = 0; column < colsCount; column++)
                {
                    PicBoxTile picBoxTile = new PicBoxTile(row, column);

                    activeType = (TileType)lstNumFromFile.ElementAt(3 * (positionOfType + 1) - 1);
                    positionOfType++;

                    switch (activeType)
                    {
                        case TileType.None:
                            picBoxTile.Image = null;
                            picBoxTile.Type = TileType.None;
                            //board[row, column].Type = 
                            break;
                        case TileType.Hero:
                            picBoxTile.Image = imgLst.Images[1];
                            heroRow = row;
                            heroCol = column;
                            picBoxTile.Type = TileType.Hero;
                            break;
                        case TileType.Wall:
                            picBoxTile.Image = imgLst.Images[2];
                            picBoxTile.Type = TileType.Wall;
                            break;
                        case TileType.Box:
                            picBoxTile.Image = imgLst.Images[3];
                            picBoxTile.Type = TileType.Box;
                            break;
                        case TileType.Destination:
                            picBoxTile.Image = imgLst.Images[4];
                            picBoxTile.Type = TileType.Destination;
                            totalDestination++;
                            break;
                        default:
                            break;
                    }
                    board[row, column] = picBoxTile;
                    pnlGameBoard.Controls.Add(board[row, column]);
                }
            }

            
        }

        private PicBoxTile GetTile(int row, int col) => board[row, col];

        private void btnUp_Click(object sender, EventArgs e)
        {
            PicBoxTile picBoxTile = GetTile(heroRow - 1, heroCol);

            switch (picBoxTile.Type)
            {
                case TileType.None:
                    board[heroRow, heroCol].Image = null;
                    board[heroRow, heroCol].Type = TileType.None;
                    pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                    heroRow--;
                    board[heroRow, heroCol].Image = imgLst.Images[1]; ;
                    board[heroRow, heroCol].Type = TileType.Hero;
                    pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                    txtNumbersOfMove.Text = (++totalMove).ToString();
                    break;
                case TileType.Hero:
                    //never come to here because Hero is only one to be moved by arrow
                    break;
                case TileType.Wall:
                    //nothing to happen
                    break;
                case TileType.Box:
                    picBoxTile = GetTile(heroRow - 2, heroCol);
                    if (picBoxTile.Type == TileType.None )
                    {
                        board[heroRow, heroCol].Image = null;
                        board[heroRow, heroCol].Type = TileType.None;
                        pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                        heroRow--;
                        board[heroRow, heroCol].Image = imgLst.Images[1];
                        board[heroRow, heroCol].Type = TileType.Hero;
                        pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                        board[heroRow - 1, heroCol].Image = imgLst.Images[3]; ;
                        board[heroRow - 1, heroCol].Type = TileType.Box;
                        pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                        txtNumbersOfMove.Text = (++totalMove).ToString();
                        txtNumbersOfPush.Text = (++totalPush).ToString();
                    }
                    else if (picBoxTile.Type == TileType.Wall)
                    {
                        //nothing to happen
                    }
                    else if (picBoxTile.Type == TileType.Destination)
                    {
                        //hero should be the box's position
                        board[heroRow, heroCol].Image = null;
                        board[heroRow, heroCol].Type = TileType.None;
                        pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                        //box should be the position of Destination
                        heroRow--;
                        board[heroRow, heroCol].Image = imgLst.Images[1];
                        board[heroRow, heroCol].Type = TileType.Hero;
                        pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                        //Destinateion disappears
                        board[heroRow - 1, heroCol].Image = imgLst.Images[3]; ;
                        board[heroRow - 1, heroCol].Type = TileType.Box;
                        pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                        txtNumbersOfMove.Text = (++totalMove).ToString();
                        txtNumbersOfPush.Text = (++totalPush).ToString();
                        totalDestination--;
                    }
                    break;
                case TileType.Destination:
                    board[heroRow, heroCol].Image = null;
                    board[heroRow, heroCol].Type = TileType.None;
                    pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                    heroRow--;
                    board[heroRow, heroCol].Image = imgLst.Images[1];
                    board[heroRow, heroCol].Type = TileType.Hero;
                    pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                    txtNumbersOfMove.Text = (++totalMove).ToString();
                    txtNumbersOfPush.Text = (++totalPush).ToString();

                    break;
                default:
                    break;
            }

            ClearBoard();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            PicBoxTile picBoxTile = GetTile(heroRow, heroCol - 1);

            switch (picBoxTile.Type)
            {
                case TileType.None:
                    board[heroRow, heroCol].Image = null;
                    board[heroRow, heroCol].Type = TileType.None;
                    pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                    heroCol--;
                    board[heroRow, heroCol].Image = imgLst.Images[1]; ;
                    board[heroRow, heroCol].Type = TileType.Hero;
                    pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                    txtNumbersOfMove.Text = (++totalMove).ToString();
                    break;
                case TileType.Hero:
                    //never come to here because Hero is only one to be moved by arrow
                    break;
                case TileType.Wall:
                    //nothing to happen
                    break;
                case TileType.Box:
                    picBoxTile = GetTile(heroRow, heroCol - 2);
                    if (picBoxTile.Type == TileType.None)
                    {
                        board[heroRow, heroCol].Image = null;
                        board[heroRow, heroCol].Type = TileType.None;
                        pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                        heroCol--;
                        board[heroRow, heroCol].Image = imgLst.Images[1];
                        board[heroRow, heroCol].Type = TileType.Hero;
                        pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                        //heroCol--;
                        board[heroRow, heroCol - 1].Image = imgLst.Images[3];
                        board[heroRow, heroCol - 1].Type = TileType.Box;
                        pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                        txtNumbersOfMove.Text = (++totalMove).ToString();
                        txtNumbersOfPush.Text = (++totalPush).ToString();
                    }
                    else if (picBoxTile.Type == TileType.Wall)
                    {
                        //nothing to happen
                    }
                    else if (picBoxTile.Type == TileType.Destination)
                    {
                        //hero should be the box's position
                        board[heroRow, heroCol].Image = null;
                        board[heroRow, heroCol].Type = TileType.None;
                        pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                        //box should be the position of Destination
                        heroCol--;
                        board[heroRow, heroCol].Image = imgLst.Images[1];
                        board[heroRow, heroCol].Type = TileType.Hero;
                        pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                        //Destinateion disappears
                        //heroCol--;
                        board[heroRow, heroCol - 1].Image = imgLst.Images[3];
                        board[heroRow, heroCol - 1].Type = TileType.Box;
                        pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                        txtNumbersOfMove.Text = (++totalMove).ToString();
                        txtNumbersOfPush.Text = (++totalPush).ToString();
                        totalDestination--;
                    }
                    break;
                case TileType.Destination:
                    board[heroRow, heroCol].Image = null;
                    board[heroRow, heroCol].Type = TileType.None;
                    pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                    heroCol--;
                    board[heroRow, heroCol].Image = imgLst.Images[1];
                    board[heroRow, heroCol].Type = TileType.Hero;
                    pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                    txtNumbersOfMove.Text = (++totalMove).ToString();
                    txtNumbersOfPush.Text = (++totalPush).ToString();

                    break;
                default:
                    break;
            }

            ClearBoard();
        }

        private void ClearBoard()
        {
            if (totalDestination == 0)
            {
                if (MessageBox.Show($"Game end!\n Total Moves: {totalMove}\n Total Pushes: {totalPush}") == DialogResult.OK)
                {
                    pnlGameBoard.Controls.Clear();
                    txtNumbersOfMove.Text = "";
                    txtNumbersOfPush.Text = "";
                    heroRow = 0;
                    heroCol = 0;
                    totalPush = 0;
                    totalMove = 0;
                    totalDestination = 0;

                }
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            PicBoxTile picBoxTile = GetTile(heroRow, heroCol + 1);

            switch (picBoxTile.Type)
            {
                case TileType.None:
                    board[heroRow, heroCol].Image = null;
                    board[heroRow, heroCol].Type = TileType.None;
                    pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                    heroCol++;
                    board[heroRow, heroCol].Image = imgLst.Images[1]; ;
                    board[heroRow, heroCol].Type = TileType.Hero;
                    pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                    txtNumbersOfMove.Text = (++totalMove).ToString();
                    break;
                case TileType.Hero:
                    //never come to here because Hero is only one to be moved by arrow
                    break;
                case TileType.Wall:
                    //nothing to happen
                    break;
                case TileType.Box:
                    picBoxTile = GetTile(heroRow, heroCol + 2);
                    if (picBoxTile.Type == TileType.None)
                    {
                        board[heroRow, heroCol].Image = null;
                        board[heroRow, heroCol].Type = TileType.None;
                        pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                        heroCol++;
                        board[heroRow, heroCol].Image = imgLst.Images[1];
                        board[heroRow, heroCol].Type = TileType.Hero;
                        pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                        //heroCol--;
                        board[heroRow, heroCol + 1].Image = imgLst.Images[3];
                        board[heroRow, heroCol + 1].Type = TileType.Box;
                        pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                        txtNumbersOfMove.Text = (++totalMove).ToString();
                    }
                    else if (picBoxTile.Type == TileType.Wall)
                    {
                        //nothing to happen
                    }
                    else if (picBoxTile.Type == TileType.Destination)
                    {
                        //hero should be the box's position
                        board[heroRow, heroCol].Image = null;
                        board[heroRow, heroCol].Type = TileType.None;
                        pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                        //box should be the position of Destination
                        heroCol++;
                        board[heroRow, heroCol].Image = imgLst.Images[1];
                        board[heroRow, heroCol].Type = TileType.Hero;
                        pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                        //Destinateion disappears
                        //heroCol--;
                        board[heroRow, heroCol + 1].Image = imgLst.Images[3];
                        board[heroRow, heroCol + 1].Type = TileType.Box;
                        pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                        txtNumbersOfMove.Text = (++totalMove).ToString();
                        txtNumbersOfPush.Text = (++totalPush).ToString();
                        totalDestination--;
                    }
                    break;
                case TileType.Destination:
                    board[heroRow, heroCol].Image = null;
                    board[heroRow, heroCol].Type = TileType.None;
                    pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                    heroCol++;
                    board[heroRow, heroCol].Image = imgLst.Images[1];
                    board[heroRow, heroCol].Type = TileType.Hero;
                    pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                    txtNumbersOfMove.Text = (++totalMove).ToString();
                    txtNumbersOfPush.Text = (++totalPush).ToString();

                    break;
                default:
                    break;
            }

            ClearBoard();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            PicBoxTile picBoxTile = GetTile(heroRow + 1, heroCol);

            switch (picBoxTile.Type)
            {
                case TileType.None:
                    board[heroRow, heroCol].Image = null;
                    board[heroRow, heroCol].Type = TileType.None;
                    pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                    heroRow++;
                    board[heroRow, heroCol].Image = imgLst.Images[1]; ;
                    board[heroRow, heroCol].Type = TileType.Hero;
                    pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                    txtNumbersOfMove.Text = (++totalMove).ToString();
                    break;
                case TileType.Hero:
                    //never come to here because Hero is only one to be moved by arrow
                    break;
                case TileType.Wall:
                    //nothing to happen
                    break;
                case TileType.Box:
                    picBoxTile = GetTile(heroRow + 2, heroCol);
                    if (picBoxTile.Type == TileType.None)
                    {
                        board[heroRow, heroCol].Image = null;
                        board[heroRow, heroCol].Type = TileType.None;
                        pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                        heroRow++;
                        board[heroRow, heroCol].Image = imgLst.Images[1];
                        board[heroRow, heroCol].Type = TileType.Hero;
                        pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                        //heroCol--;
                        board[heroRow + 1, heroCol].Image = imgLst.Images[3];
                        board[heroRow + 1, heroCol].Type = TileType.Box;
                        pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                        txtNumbersOfMove.Text = (++totalMove).ToString();
                        txtNumbersOfPush.Text = (++totalPush).ToString();
                    }
                    else if (picBoxTile.Type == TileType.Wall)
                    {
                        //nothing to happen
                    }
                    else if (picBoxTile.Type == TileType.Destination)
                    {
                        //hero should be the box's position
                        board[heroRow, heroCol].Image = null;
                        board[heroRow, heroCol].Type = TileType.None;
                        pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                        //box should be the position of Destination
                        heroRow++;
                        board[heroRow, heroCol].Image = imgLst.Images[1];
                        board[heroRow, heroCol].Type = TileType.Hero;
                        pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                        //Destinateion disappears
                        //heroCol--;
                        board[heroRow + 1, heroCol].Image = imgLst.Images[3];
                        board[heroRow + 1, heroCol].Type = TileType.Box;
                        pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                        txtNumbersOfMove.Text = (++totalMove).ToString();
                        txtNumbersOfPush.Text = (++totalPush).ToString();
                        totalDestination--;
                    }
                    break;
                case TileType.Destination:
                    board[heroRow, heroCol].Image = null;
                    board[heroRow, heroCol].Type = TileType.None;
                    pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                    heroRow++;
                    board[heroRow, heroCol].Image = imgLst.Images[1];
                    board[heroRow, heroCol].Type = TileType.Hero;
                    pnlGameBoard.Controls.Add(board[heroRow, heroCol]);

                    txtNumbersOfMove.Text = (++totalMove).ToString();
                    txtNumbersOfPush.Text = (++totalPush).ToString();

                    break;
                default:
                    break;
            }

            ClearBoard();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// set the tile the chosen image of the toolbox when one point of the board is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void Tile_Click(object sender, EventArgs e)
        //{
        //    Tile tile = (Tile)sender;
        //    tile.Type = activeType;

        //    switch (activeType)
        //    {
        //        case TileType.None:
        //            tile.Image = null;
        //            break;
        //        case TileType.Hero:
        //            tile.Image = imgLst.Images[1];
        //            break;
        //        case TileType.Wall:
        //            tile.Image = imgLst.Images[2];
        //            break;
        //        case TileType.Box:
        //            tile.Image = imgLst.Images[3];
        //            break;
        //        case TileType.Destination:
        //            tile.Image = imgLst.Images[4];
        //            break;
        //        default:
        //            break;
        //    }
        //}
    }
}
