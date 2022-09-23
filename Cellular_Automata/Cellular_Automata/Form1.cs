using Cellular_Automata;
using System.Drawing.Imaging;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace Cellular_Automata
{
    public partial class Form1 : Form
    {
        private readonly int size = 10;
        private readonly int p = 11;
        private readonly int width =10; 
        private readonly int height = 1;
        private bool isSelfReplication = false;
        private int iterations = 0;
        Rule rule;
        Bitmap bitmap;
        Game game;
        public Form1()
        {
            InitializeComponent();
            game = new Game(size, p, width, height);
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            rule = new Rule_Left();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.Image = game.Draw(bitmap);
            iterations++;
            this.Text = $"{iterations} iterations";
            isSelfReplication = game.UpdateBlocks(rule);
            if (isSelfReplication)
            {
                this.Text = $"self-replication on {iterations + 1} generation";
                bitmap.Save($"C:\\tests\\test_5a_{p}\\{iterations}{Guid.NewGuid().ToString()}.jpg", ImageFormat.Jpeg);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}