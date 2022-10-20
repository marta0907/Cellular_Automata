namespace Cellular_Automata
{
    public partial class Form1 : Form
    {
        private readonly int size = 2;
        private readonly int p = 2;
        Rule rule;
        Bitmap bitmap;
        Game game;
        public Form1()
        {
            InitializeComponent();
            game = new Game(size, p);
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            rule = new Rule_Neumann();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.Image = game.Draw(bitmap);
            game.UpdateBlocks(rule);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}