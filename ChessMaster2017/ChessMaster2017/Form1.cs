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
        public MainForm()
        {
            InitializeComponent();
                       
            Board testBoard = new Board();
            e5.Image = Properties.Resources.black_pawn;
            e7.Image = null;
            b2.Image = e5.Image;
        }

        private void Selector(object sender, EventArgs e)
        {
            /*Control control = (Control)sender;
            MessageBox.Show(control.Name);*/

        }
    }
}
