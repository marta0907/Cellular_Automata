using System;

namespace Cellular_Automata
{
    public interface Rule
    {
        void NextGeneration(int[,] buffer, int[,] block, int p, bool hasNoise);
    }
    public class Rule_Left : Rule
    {
        public void NextGeneration(int[,] buffer, int[,] block, int p, bool hasNoise)
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
            if (hasNoise)
            {
                Random r = new Random();
                for (int i = 0; i < width; i++)
                {
                    for (int k = 0; k < height; k++)
                    {
                        var probability = r.Next(0, 100000);
                        if (probability < 1)
                        {
                            var num = r.Next(p);
                            Console.WriteLine($"{buffer[i, k]} updated to {num}");
                            buffer[i, k] = num;
                        }
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
    public class Rule_LeftRight : Rule
    {
        public void NextGeneration(int[,] buffer, int[,] block, int p, bool hasNoise)
        {
            int width = block.GetUpperBound(0) + 1;
            int height = block.Length / width;

            for (int i = 0; i < width; i++)
            {
                for (int k = 0; k < height; k++)
                {
                    int a = block[i, k];
                    if (i == 0)
                    {
                        int b = block[width - 1, k];
                        int c = block[i + 1, k];
                        buffer[i, k] = (a + b + c) % p;
                    }
                    else if (i == width - 1)
                    {
                        int b = block[i - 1, k];
                        int c = block[0, k];
                        buffer[i, k] = (a + b + c) % p;
                    }
                    else
                    {
                        int b = block[i - 1, k];
                        int c = block[i + 1, k];
                        buffer[i, k] = (a + b + c) % p;
                    }
                }
            }
            if (hasNoise)
            {
                Random r = new Random();
                for (int i = 0; i < width; i++)
                {
                    for (int k = 0; k < height; k++)
                    {
                        var probability = r.Next(0, 100000);
                        if (probability < 1)
                        {
                            var num = r.Next(p);
                            Console.WriteLine($"{buffer[i, k]} updated to {num}");
                            buffer[i, k] = num;
                        }
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
    public class Rule_LeftAbove : Rule
    {
        public void NextGeneration(int[,] buffer, int[,] block, int p, bool hasNoise)
        {
            int width = block.GetUpperBound(0) + 1;
            int height = block.Length / width;

            for (int i = 0; i < width; i++)
            {
                for (int k = 0; k < height; k++)
                {
                    if (i == 0 && k == 0)
                    {
                        int a = block[i, k];
                        int b = block[width - 1, 0];
                        int c = block[0, height - 1];
                        buffer[i, k] = (a + b + c) % p;
                    }
                    else if (i == 0 && k != 0)
                    {
                        int a = block[i, k];
                        int b = block[width - 1, k];
                        int c = block[i, k - 1];
                        buffer[i, k] = (a + b + c) % p;
                    }
                    else if (i != 0 && k == 0)
                    {
                        int a = block[i, k];
                        int b = block[i, height - 1];
                        int c = block[i - 1, k];
                        buffer[i, k] = (a + b + c) % p;
                    }
                    else
                    {
                        int a = block[i, k];
                        int b = block[i, k - 1];
                        int c = block[i - 1, k];
                        buffer[i, k] = (a + b + c) % p;
                    }
                }
            }
            if (hasNoise)
            {
                Random r = new Random();
                for (int i = 0; i < width; i++)
                {
                    for (int k = 0; k < height; k++)
                    {
                        var probability = r.Next(0, 100000);
                        if (probability < 1)
                        {
                            var num = r.Next(p);
                            Console.WriteLine($"{buffer[i, k]} updated to {num}");
                            buffer[i, k] = num;
                        }
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
    public class Rule_Neumann : Rule
    {
        public void NextGeneration(int[,] buffer, int[,] block, int p, bool hasNoise)
        {
            int width = block.GetUpperBound(0) + 1;
            int height = block.Length / width;

            for (int i = 0; i < width; i++)
            {
                for (int k = 0; k < height; k++)
                {
                    int state = 0;
                    state += block[i, k];

                    if (i == 0 && k == 0)
                    {
                        state += block[width - 1, k];
                        state += block[i, height - 1];
                        state += block[i, k + 1];
                        state += block[i + 1, k];

                        buffer[i, k] = state % p;
                    }
                    else if (i == width - 1 && k == 0)
                    {
                        state += block[i - 1, k];
                        state += block[i, height - 1];
                        state += block[i, k + 1];
                        state += block[0, k];

                        buffer[i, k] = state % p;
                    }
                    else if (i == 0 && k == height - 1)
                    {
                        state += block[width - 1, k];
                        state += block[i, k - 1];
                        state += block[i, 0];
                        state += block[i + 1, k];

                        buffer[i, k] = state % p;
                    }
                    else if (i == width - 1 && k == height - 1)
                    {
                        state += block[i - 1, k];
                        state += block[i, k - 1];
                        state += block[i, 0];
                        state += block[0, k];

                        buffer[i, k] = state % p;
                    }
                    else if (i != 0 && i != width - 1 && k == 0)
                    {
                        state += block[i - 1, k];
                        state += block[i, height - 1];
                        state += block[i, k + 1];
                        state += block[i + 1, k];

                        buffer[i, k] = state % p;
                    }
                    else if (i != 0 && i != width - 1 && k == height - 1)
                    {
                        state += block[i - 1, k];
                        state += block[i, k - 1];
                        state += block[i, 0];
                        state += block[i + 1, k];

                        buffer[i, k] = state % p;
                    }
                    else if (i == 0 && k != height - 1 && k != 0)
                    {
                        state += block[width - 1, k];
                        state += block[i, k - 1];
                        state += block[i, k + 1];
                        state += block[i + 1, k];

                        buffer[i, k] = state % p;
                    }
                    else if (i == width - 1 && k != height - 1 && k != 0)
                    {
                        state += block[i - 1, k];
                        state += block[i, k - 1];
                        state += block[i, k + 1];
                        state += block[0, k];

                        buffer[i, k] = state % p;
                    }
                    else
                    {
                        state += block[i - 1, k];
                        state += block[i, k - 1];
                        state += block[i, k + 1];
                        state += block[i + 1, k];

                        buffer[i, k] = state % p;
                    }
                }
            }
            if (hasNoise)
            {
                Random r = new Random();
                for (int i = 0; i < width; i++)
                {
                    for (int k = 0; k < height; k++)
                    {
                        var probability = r.Next(0, 100000);
                        if (probability < 1)
                        {
                            var num = r.Next(p);
                            Console.WriteLine($"{buffer[i, k]} updated to {num}");
                            buffer[i, k] = num;
                        }
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
    public class Rule_Moore : Rule
    {
        public void NextGeneration(int[,] buffer, int[,] block, int p, bool hasNoise)
        {
            int width = block.GetUpperBound(0) + 1;
            int height = block.Length / width;

            for (int i = 0; i < width; i++)
            {
                for (int k = 0; k < height; k++)
                {
                    int state = 0;
                    state += block[i, k];

                    if (i == 0 && k == 0)
                    {
                        state += block[width - 1, height - 1];
                        state += block[width - 1, k];
                        state += block[width - 1, k + 1];
                        state += block[i, height - 1];
                        state += block[i, k + 1];
                        state += block[i + 1, height - 1];
                        state += block[i + 1, k];
                        state += block[i + 1, k + 1];

                        buffer[i, k] = state % p;
                    }
                    else if (i == width - 1 && k == 0)
                    {
                        state += block[i - 1, height - 1];
                        state += block[i - 1, k];
                        state += block[i - 1, k + 1];
                        state += block[i, height - 1];
                        state += block[i, k + 1];
                        state += block[0, height - 1];
                        state += block[0, k];
                        state += block[0, k + 1];
                        buffer[i, k] = state % p;
                    }
                    else if (i == 0 && k == height - 1)
                    {
                        state += block[width - 1, k - 1];
                        state += block[width - 1, k];
                        state += block[width - 1, 0];
                        state += block[i, k - 1];
                        state += block[i, 0];
                        state += block[i + 1, k - 1];
                        state += block[i + 1, k];
                        state += block[i + 1, 0];
                        buffer[i, k] = state % p;
                    }
                    else if (i == width - 1 && k == height - 1)
                    {
                        state += block[i - 1, k - 1];
                        state += block[i - 1, k];
                        state += block[i - 1, 0];
                        state += block[i, k - 1];
                        state += block[i, 0];
                        state += block[0, k - 1];
                        state += block[0, k];
                        state += block[0, 0];
                        buffer[i, k] = state % p;
                    }
                    else if (i != 0 && i != width - 1 && k == 0)
                    {
                        state += block[i - 1, height - 1];
                        state += block[i - 1, k];
                        state += block[i - 1, k + 1];
                        state += block[i, height - 1];
                        state += block[i, k + 1];
                        state += block[i + 1, height - 1];
                        state += block[i + 1, k];
                        state += block[i + 1, k + 1];

                        buffer[i, k] = state % p;
                    }
                    else if (i != 0 && i != width - 1 && k == height - 1)
                    {
                        state += block[i - 1, k - 1];
                        state += block[i - 1, k];
                        state += block[i - 1, 0];
                        state += block[i, k - 1];
                        state += block[i, 0];
                        state += block[i + 1, k - 1];
                        state += block[i + 1, k];
                        state += block[i + 1, 0];

                        buffer[i, k] = state % p;
                    }
                    else if (i == 0 && k != height - 1 && k != 0)
                    {
                        state += block[width - 1, k - 1];
                        state += block[width - 1, k];
                        state += block[width - 1, k + 1];
                        state += block[i, k - 1];
                        state += block[i, k + 1];
                        state += block[i + 1, k - 1];
                        state += block[i + 1, k];
                        state += block[i + 1, k + 1];

                        buffer[i, k] = state % p;
                    }
                    else if (i == width - 1 && k != height - 1 && k != 0)
                    {
                        state += block[i - 1, k - 1];
                        state += block[i - 1, k];
                        state += block[i - 1, k + 1];
                        state += block[i, k - 1];
                        state += block[i, k + 1];
                        state += block[0, k - 1];
                        state += block[0, k];
                        state += block[0, k + 1];

                        buffer[i, k] = state % p;
                    }
                    else
                    {
                        state += block[i - 1, k - 1];
                        state += block[i - 1, k];
                        state += block[i - 1, k + 1];
                        state += block[i, k - 1];
                        state += block[i, k + 1];
                        state += block[i + 1, k - 1];
                        state += block[i + 1, k];
                        state += block[i + 1, k + 1];

                        buffer[i, k] = state % p;
                    }
                }
            }
            if (hasNoise)
            {
                Random r = new Random();
                for (int i = 0; i < width; i++)
                {
                    for (int k = 0; k < height; k++)
                    {
                        var probability = r.Next(0, 100000);
                        if (probability < 1)
                        {
                            var num = r.Next(p);
                            Console.WriteLine($"{buffer[i, k]} updated to {num}");
                            buffer[i, k] = num;
                        }
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