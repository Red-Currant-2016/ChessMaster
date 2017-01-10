﻿using ChessMaster2017.BackEnd;
using System;
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
                }
                //control.BackColor = Color.Aqua;
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
                }
                else
                {
                    testBoard.selectedChessPiece = null;
                    oldControl.BackColor = oldColor;
                    Action = false;
                }
            }
        }


    }
}
