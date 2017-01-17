namespace ChessMaster2017
{
    using ChessMaster2017.Engine;

    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        private readonly Color whiteSquare = Color.Moccasin;
        private readonly Color blackSquare = Color.Sienna;
        private readonly Color highLightSquare = Color.DodgerBlue;
        private readonly Color checkedSquare = Color.Firebrick;

        //private Color oldColor = default(Color);
        private bool[,] highLightBoardSquares;

        private int state;

        private BoardManager gameObject;
        private PictureBoxWithPosition oldControl = null;


        public MainForm()
        {
            this.InitializeComponent();

            this.gameObject = new BoardManager();
            this.highLightBoardSquares = new bool[8, 8];
            this.state = 0;
        }

        private string ParseSquare(int x, int y)
        {
            string square = ((char)(y + 'a')).ToString();

            square += (char)(x + '1');

            return square;
        }

        private void HighlightSquare(string squarePosition)
        {
            foreach (var item in this.Controls)
            {
                if (item is PictureBoxWithPosition)
                {
                    if ((item as PictureBoxWithPosition).Position == squarePosition)
                    {
                        (item as PictureBoxWithPosition).BackColor = highLightSquare;
                    }
                }
            }
        }
        private void HighlightBoard()
        {
            highLightBoardSquares = gameObject.GetHighlightedMoves();

            for (int x = 0; x < highLightBoardSquares.GetLength(0); x++)
            {
                for (int y = 0; y < highLightBoardSquares.GetLength(1); y++)
                {
                    if (highLightBoardSquares[x, y] == true)
                    {
                        HighlightSquare(ParseSquare(x, y));
                    }
                }
            }
        }

        private void ResetBoardSquareColors()
        {
            foreach (var item in this.Controls)
            {
                if (item is PictureBoxWithPosition)
                {
                    if(isBlack((item as PictureBoxWithPosition).Position) == true)
                    {
                        (item as PictureBoxWithPosition).BackColor = blackSquare;
                    }
                    else if(isWhite((item as PictureBoxWithPosition).Position) == true)
                    {
                        (item as PictureBoxWithPosition).BackColor = whiteSquare;
                    }
                    
                }
            }
        }
        private bool isBlack(string position)
        {
            // temp solution
            int y = position[0] - 'a';
            int x = position[1] - '1';

            return (x % 2) == (y % 2);
        }
        private bool isWhite(string position)
        {
            //temp solution
            int y = position[0] - 'a';
            int x = position[1] - '1';

            return (x % 2) != (y % 2);
        }

        private void PlayerSelectSquare(object sender, EventArgs e)
        {
            PictureBoxWithPosition control = (PictureBoxWithPosition)sender;
            string coordinates = control.Position;

            if (state == 0)
            {
                if (gameObject.SelectChessPiece(coordinates) == true)
                {
                    state = 1;
                    oldControl = control;
                    control.BackColor = highLightSquare;
                    HighlightBoard();
                }
            }
            else if (state == 1)
            {
                if (gameObject.MoveChessPiece(coordinates) == true)
                {
                    state = 0;
                    control.Image = oldControl.Image;
                    oldControl.Image = null;
                    if (gameObject.IsWhitePlayerCheckMate() == true)
                    {
                        MessageBox.Show("White is check mate!");
                    }
                    if(gameObject.IsBlackPlayerCheckMate() == true)
                    {
                        MessageBox.Show("Black is check mate!");
                    }
                    //else if (gameObject.IsKingChecked() == true)
                    //{
                    //    //TODO highlinght checked king
                    //    //state = 3;
                    //    MessageBox.Show("Check!");
                    //}

                    gameObject.ChangePlayerTurn();
                    if (gameObject.GetPlayerTurn() == EnumPlayerTurn.WhitePlayer)
                    {
                        WhitePlayerTurn.Checked = true;
                        BlackPlayerTurn.Checked = false;
                    }
                    else
                    {
                        WhitePlayerTurn.Checked = false;
                        BlackPlayerTurn.Checked = true;
                    }


                    ResetBoardSquareColors();
                }
            }
        }

    }
}
