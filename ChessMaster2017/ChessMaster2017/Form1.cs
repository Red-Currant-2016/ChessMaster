using ChessMaster2017.BackEnd;
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
        bool Action = false;
        Board testBoard = new Board();
        public MainForm()
        {
            InitializeComponent();
                       
            
            /*e5.Image = Properties.Resources.black_pawn;
            e7.Image = null;
            b2.Image = e5.Image;*/
        }
        PictureBox oldControl = null;

        private void Selector(object sender, EventArgs e)
        {
            
            if (!Action)
            {
                oldControl = (PictureBox)sender;
            }
            PictureBox control = (PictureBox)sender;
            string cordinates = control.Name;
            int y = cordinates[0] - 'a';
            int x = cordinates[1] - '1';
            bool isSelected = testBoard.SelectChessPiece(x, y);
            
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
                }
                //control.BackColor = Color.Aqua;
            }
            else
            {
                testBoard.MoveSelectedChessPiece(x, y);
                //control.Image = null;
                Image newFigure = null;
                newFigure = oldControl.Image;
                testBoard.selectedChessPiece = null;
                oldControl.Image = null;
                secondControl.Image = newFigure;
                Action = false;
            }
        }
        
    }
}
