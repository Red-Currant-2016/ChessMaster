using ChessMaster2017.Engine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessMaster2017
{

    public partial class MainForm : Form
    {
        bool[,] Board = new bool[8, 8];
        bool Action = false;
        BoardManager testBoard = new BoardManager();
        PictureBox oldControl = null;
        Color oldColor = default(Color);
        public MainForm()
        {
            InitializeComponent();


            /*e5.Image = Properties.Resources.black_pawn;
            e7.Image = null;
            b2.Image = e5.Image;*/
        }


        private void Selector(object sender, EventArgs e)
        {
            PictureBox control = (PictureBox)sender;
            string cordinates = control.Name;
            bool isSelected = false;
            int y = cordinates[0] - 'a';
            int x = cordinates[1] - '1';
            if (!Action)
            {
                isSelected = testBoard.SelectChessPiece(x, y);
            }


            PictureBox secondControl = (PictureBox)sender;
            if (isSelected)
            {
                control = (PictureBox)sender;
            }
            else
            {
                secondControl = (PictureBox)sender;
            }


            if (!Action)
            {

                /*Control control = (Control)sender;
                MessageBox.Show(control.Name);*/


                if (isSelected)
                {
                    Action = true;
                    oldControl = (PictureBox)sender;
                    oldColor = oldControl.BackColor;
                    oldControl.BackColor = Color.Aqua;
                    HightLight();
                }
            }
            else
            {
                if (testBoard.isValidMove(x, y))
                {
                    testBoard.MoveChessPiece(x, y);
                    EnumColor turn = testBoard.GetPlayerTurn();
                    if (turn == EnumColor.White)
                    {
                        WhitePlayerTurn.Checked = true;
                        BlackPlayerTurn.Checked = false;
                    }
                    else
                    {
                        BlackPlayerTurn.Checked = true;
                        WhitePlayerTurn.Checked = false;
                    }
                    //control.Image = null;
                    Image newFigure = null;
                    newFigure = oldControl.Image;
                    testBoard.selectedChessPiece = null;
                    oldControl.Image = null;
                    oldControl.BackColor = oldColor;
                    secondControl.Image = newFigure;
                    Action = false;
                    ReturnBoardToNormal();
                }
                else
                {
                    testBoard.selectedChessPiece = null;
                    oldControl.BackColor = oldColor;
                    Action = false;
                    ReturnBoardToNormal();
                }
            }
        }

        private void ReturnBoardToNormal()
        {
            int count = 0;
            bool flag = false;
            foreach (Control ctr in this.Controls)
            {
                if (ctr is PictureBox)
                {
                    if (count % 2 == 0)
                    {
                        ((PictureBox)ctr).BackColor = Color.Moccasin;
                    }
                    else
                    {
                        ((PictureBox)ctr).BackColor = Color.Sienna;
                    }
                    count++;
                    if (count % 9 == 0 && flag)
                    {
                        count = 0;
                        flag = false;
                    }
                    else if ((count) % 8 == 0 && !flag)
                    {
                        count = 1;
                        flag = true;
                    }

                }
            }
        }

        private void HightLight()
        {
            bool[,] highlightChessPieceMoves = new bool[8, 8];
            highlightChessPieceMoves = testBoard.GetHighlightedMoves();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (highlightChessPieceMoves[i, j])
                    {
                        StringBuilder controlName = new StringBuilder();
                        controlName.Append((char)(j + 'a'));
                        controlName.Append((char)(i + '1'));
                        foreach (Control ctr in this.Controls)
                        {
                            if (ctr.Name == controlName.ToString())
                            {
                                ((PictureBox)ctr).BackColor = Color.SkyBlue;
                            }
                        }
                    }
                }
            }
        }


    }
}
