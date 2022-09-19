namespace Cellular_Automata
{
    public partial class Form1 : Form
    {
        int size = 5;
        int p = 11;
        int[] buffer;
        int[] block;
        Random random;
        Bitmap bitmap;
        public Form1()
        {
            InitializeComponent();
            random = new Random();
            InitBlocks();
        }

        void InitBlocks()
        {
            buffer = new int[size];
            block = new int[size];
            for(int i = 0; i < size; i++)
            {
                block[i] = random.Next(p);
            }
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        void UpdateBlocks()
        {
            for(int i = 0; i < size; i++)
            {
                if (i == 0)
                {
                    int a = block[i];
                    int b = block[size - 1];
                    buffer[i]= (a + b)%p;
                }
                else
                {
                    int a = block[i -1];
                    int b = block[i];
                    buffer[i] = (a + b) % p;
                }
            }

            for (int i = 0; i < size; i++)
            {
                block[i] = buffer[i];
            }
        }

        void MainLoop()
        {
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int w = 60;
            Graphics g = Graphics.FromImage(bitmap);
            
            for(int i = 0; i < size; i++)
            {
                double alpha =Math.Round((Double)255* block[i]/(p-1));
                SolidBrush brush = new SolidBrush(Color.FromArgb((int)alpha, (int)alpha, (int)alpha));
                g.FillRectangle(brush, i * w, 1, w, w);
            }
            pictureBox1.Image = bitmap;
            g.Dispose();
            Thread.Sleep(1000);
            UpdateBlocks();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MainLoop();
        }
    }
}