namespace Cellular_Automata
{
    public partial class Form1 : Form
    { 
        Rule rule;
        Bitmap bitmap;
        Game game;
        public Form1()
        {
            InitializeComponent();
            game = new Game();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            rule = new Rule_Neumann();
        }

        public Form1(Rule rule)
        {
            InitializeComponent();
            game = new Game();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            this.rule = rule;
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