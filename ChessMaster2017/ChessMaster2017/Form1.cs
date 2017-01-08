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

        private void Selector(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            PictureBox control = (PictureBox)sender;
            string cordinates = control.Name;
            x = cordinates[0] - 'a';
            y = cordinates[1] - '1';
            if (!Action)
            {

                /*Control control = (Control)sender;
                MessageBox.Show(control.Name);*/
                 
                bool isSelected = testBoard.SelectChessPiece(x, y);
                if (isSelected)
                {
                    Action = true; ;
                }
                //control.BackColor = Color.Aqua;
            }
            else
            {
                testBoard.MoveSelectedChessPiece(x, y);
                Action = false;
            }
        }
    }
}
