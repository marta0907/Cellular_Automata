using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular_Automata
{
    public interface Rule
    {
        void NextGeneation(int[,] buffer, int[,] block, int p);
    }

    public class Rule5a : Rule
    {
        void Rule.NextGeneation(int[,] buffer, int[,] block, int p)
        {
            int width = block.GetUpperBound(0) + 1; 
            int height = block.Length / width;

            for (int i = 0; i < width; i++)
            {
                for (int k = 0; k < height; k++)
                {
                    if (i == 0)
                    {
                        int a = block[i, k];
                        int b = block[width - 1, k];
                        buffer[i, k] = (a + b) % p;
                    }
                    else
                    {
                        int a = block[i - 1, k];
                        int b = block[i, k];
                        buffer[i, k] = (a + b) % p;
                    }
                }
            }

            for (int i = 0; i < width; i++)
            {
                for (int k = 0; k < height; k++)
                {
                    block[i, k] = buffer[i, k];
                }
            }
        }
    }

    public class Rule5b : Rule
    {
        public void NextGeneation(int[,] buffer, int[,] block, int p)
        {
            int width = block.GetUpperBound(0) + 1;
            int height = block.Length / width;

            for (int i = 0; i < width; i++)
            {
                for (int k = 0; k < height; k++)
                {
                    if (i == 0)
                    {
                        int a = block[i, k];
                        int b = block[width - 1, k];
                        int c = block[i + 1, k];
                        buffer[i, k] = (a + b + c) % p;
                    }
                    else if (i == width - 1)
                    {
                        int a = block[i, k];
                        int b = block[i - 1, k];
                        int c = block[0, k];
                        buffer[i, k] = (a + b + c) % p;
                    }
                    else
                    {
                        int a = block[i - 1, k];
                        int b = block[i, k];
                        int c = block[i + 1, k];
                        buffer[i, k] = (a + b) % p;
                    }
                }
            }

            for (int i = 0; i < width; i++)
            {
                for (int k = 0; k < height; k++)
                {
                    block[i, k] = buffer[i, k];
                }
            }
        }
    }


}
