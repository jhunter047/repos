using System;
using System.Drawing;


namespace Snake.V2
{
    //Food Class
    public class Food
    {
        //Declares the varibles 
        private int x, y, width, height; 
        private SolidBrush brush;
        public Rectangle foodRec;

        //Gets a random location for the food in the play area 
        public Food(Random randFood)
        {
            x = randFood.Next(0, 2) * 10;
            y = randFood.Next(0, 29) * 10;

            //sets the color of the food to black
            brush = new SolidBrush(Color.Black);
            width = 10;
            height = 10;
            foodRec = new Rectangle(x, y, width, height);
        }

        //Gets the random location for the food
        public void foodLocation(Random randFood)
        {
            x = randFood.Next(0, 2) * 10;
            y = randFood.Next(0, 29) * 10;
        }

        //Draws the food on the screen
        public void drawFood(Graphics paper)
        {
            foodRec.X = x;
            foodRec.Y = y;

            paper.FillRectangle(brush, foodRec);
        }
    }
}
