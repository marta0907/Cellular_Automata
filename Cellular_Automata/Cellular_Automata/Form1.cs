using Cellular_Automata;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace Cellular_Automata
{
    public partial class Form1 : Form
    {
        private readonly int size = 20;
        private readonly int p = 5;
        private readonly int width = 50; 
        private readonly int height = 50;
        private bool isSelfReplication = false;
        private int iterations = 0;
        Rule rule;
        Bitmap bitmap;
        Game game;
        public Form1()
        {
            InitializeComponent();
            game = new Game(size, p, width, height);
            bitmap = new Bitmap(width*size, height*size);
            rule = new Rule_Moore();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (!isSelfReplication)
            {
                pictureBox1.Image = game.Draw(bitmap);
                iterations++;
                this.Text = $"{iterations} iterations";
            }
            isSelfReplication = game.UpdateBlocks(rule);
            if (isSelfReplication)
            {
                this.Text = $"self-replication on {iterations + 1} generation";
            }
            //bitmap.Save($"C:\\Tests\\test_6b_11\\{message}.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}