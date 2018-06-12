using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food
    {
        public Rectangle piece;
        private int x;
        private int y;
        private int Width = 10;
        private readonly int Height = 10;

        public Food (Random rand)
        {
            generate(rand);
            piece = new Rectangle(x, y, Width, Height);
        }

        public void Draw (Graphics graphics)
        {
            piece.X = x;
            piece.Y = y;
            graphics.FillRectangle(Brushes.Brown, piece);
        }

        public void generate(Random rand)
        {
            x = rand.Next(0, 30 * 10);
            y = rand.Next(0, 20 * 10); 
        }
    }
}
