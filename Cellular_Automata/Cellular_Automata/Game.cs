﻿namespace Cellular_Automata
{
    public class Game
    {
        int[,] buffer, block, initial;
        int size, p;
        int width = 5 , height = 5;
        Random random;
        private const int Rows = 700;
        private const int Columns = 700;


        public Game(int size, int p)
        {
            this.size = size;
            this.p = p ;
            buffer = new int[Rows,Columns];
            block = new int[Rows,Columns];
            initial = new int[width,height];
            random = new Random();
            InitBlocks();
        }
        public void InitBlocks()
        {
            for (int i = 0; i < Rows; i++)
            {
                for(int j = 0; j < Columns; j++)
                {
                    if (i < width && j < height)
                    {
                        block[i, j] = random.Next(p);
                        initial[i, j] = block[i, j];
                    }
                    else
                    {
                        block[i, j] = 0;
                    }
                }
            }
           
        }

        public bool UpdateBlocks(Rule rule)
        {
            rule.NextGeneation(buffer, block, p);
            return EqualGenerations();
        }

        public Bitmap Draw(Bitmap bitmap)
        {
            Graphics g = Graphics.FromImage(bitmap);
            for (int i = 0; i < Rows; i++)
            {
                for (int k = 0; k < Columns; k++)
                {
                    double alpha = Math.Round((Double)255 * block[i, k] / (p - 1));
                    SolidBrush brush = new SolidBrush(Color.FromArgb(255 - (int)alpha, (int)alpha,255 - (int)alpha));
                    g.FillRectangle(brush, i * size, k * size, size, size);
                }
            }
            g.Dispose();
            return bitmap;  
        }

        bool EqualGenerations()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (initial[i, j] != block[i, j]) 
                        return false;
                }
            }
            return true;
        }
    }
}
