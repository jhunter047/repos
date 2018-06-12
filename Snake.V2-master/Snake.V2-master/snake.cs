using System.Collections.Generic;
using System.Linq;
using System.Drawing;


//snake class
namespace Snake.V2
{
    class snake
    {
        //Declars the varibles
        public Rectangle[] snakeRec;
        private SolidBrush brush;
        private int x, y, width, height; 

        //Creates the snake
        public snake()
        {
            snakeRec = new Rectangle[3];
            brush = new SolidBrush(Color.Blue);

            x = 20;
            y = 0;
            width = 10;
            height = 10; 

            for (int i =0; i < snakeRec.Length; i++)
            {
                snakeRec[i] = new Rectangle(x, y, width, height);
                x -= 10;
            }
        }

        //Draws the snake to the screen
        public void drawsnake(Graphics paper)
        {
        foreach(Rectangle rec in snakeRec)
        {
            paper.FillRectangle(brush, rec); 
        }
            
        }

        //Updates the snake length
        public void drawSnake()
        {
            for (int i = snakeRec.Length - 1; i > 0; i--)
            {
                snakeRec[i] = snakeRec[i - 1];
            }
        }

        //Updates the snake length on moving down
        public void moveDown()
        {
            drawSnake();
            snakeRec[0].Y += 10;
        }

        //Updates the snake length on moving up 
        public void moveUp()
        {
            drawSnake();
            snakeRec[0].Y -= 10;
        }

        //Updates the snake length on moving right
        public void moveRight()
        {
            drawSnake();
            snakeRec[0].X += 10;
        }

        //Updates the snake length o moving left
        public void moveLeft()
        {
            drawSnake();
            snakeRec[0].X -= 10;
        }

        //Grows the snake by 1
        public void growSnake()
        {
            List<Rectangle> rec = snakeRec.ToList();
            rec.Add(new Rectangle(snakeRec[snakeRec.Length - 1].X, snakeRec[snakeRec.Length - 1].Y, width, height));
            snakeRec = rec.ToArray();
        }

    }
}
