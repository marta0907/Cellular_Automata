using Cellular_Automata;
using System.Net.Http.Headers;

namespace Cellular_Automata
{
    public partial class Form1 : Form
    {
        private readonly int size = 50;
        private readonly int p = 11;
        private readonly int width = 5; 
        private readonly int height = 1;
        Rule rule;
        Bitmap bitmap;
        Game game;
        public Form1()
        {
            InitializeComponent();
            game = new Game(size, p, width, height);
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            rule = new Rule5b();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.Image = game.Draw(bitmap);
            //bitmap.Save("test1.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            string message = "";
            game.UpdateBlocks(rule,ref message);
            if(message != "")this.Text = message;
            Thread.Sleep(100);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}