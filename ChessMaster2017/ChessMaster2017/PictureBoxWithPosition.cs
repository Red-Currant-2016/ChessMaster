namespace ChessMaster2017
{
    using System.Windows.Forms;
    /// <summary>
    /// Picture Box that can hold it's position on the chess board. 
    /// </summary>
    public class PictureBoxWithPosition : PictureBox
    {
        public string Position { get; set; }
    }
}
