using Cellular_Automata;
using System.Net.Http.Headers;

namespace Cellular_Automata
{
    public partial class Form1 : Form
    {
        private readonly int size = 100;
        private readonly int p = 11;
        private readonly int width = 5; 
        private readonly int height = 5;
        Rule rule;
        Bitmap bitmap;
        Game game;
        public Form1()
        {
            InitializeComponent();
            game = new Game(size, p, width, height);
            bitmap = new Bitmap(width*size, height*size);
            rule = new Rule6b();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.Image = game.Draw(bitmap);
            string message = "";
            game.UpdateBlocks(rule,ref message);
            bitmap.Save($"C:\\Tests\\test_6b_11\\{message}.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            if (message != "")this.Text = message;
            Thread.Sleep(100);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}