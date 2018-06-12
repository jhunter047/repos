using System;
using System.Drawing;
using System.Windows.Forms;


/// <summary>
/// Classic Snake game in C# version 2 
/// by Joe Hunter
/// https://github.com/jhunter047
/// </summary>


//main 
namespace Snake.V2
{
    public partial class SnakeV2 : Form
    {

        //Declar varibles 
        Graphics paper;
        snake snake = new snake();
        Random randFood = new Random();
        Food food;

        //Varible for directions 
        bool left = false;
        bool right = true;
        bool up = false;
        bool down = false;

        //Varible for score
        int score = 0;

        //on load spawn a random food
        public SnakeV2()
        {
            InitializeComponent();
            food = new Food(randFood);
        }

        //on form load 
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Draw the graphics to the screen
        private void SnakeV2_Paint(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;
            food.drawFood(paper);
            snake.drawsnake(paper); 


           
        }


        /// <summary>
        /// Controls of the game
        /// </summary>
        private void SnakeV2_KeyDown(object sender, KeyEventArgs e)
        {
            //when the space bar is pressed, start the game
            if(e.KeyData == Keys.Space)
            {
                timer1.Enabled = true;
                Press_Space.Text = "";
                down = false;
                up = false;
                right = true;
                left = false;
            }

            //when the down key is pressed, change the direction to down 
            if(e.KeyData == Keys.Down && up == false)
            {
                down = true;
                up = false;
                right = false;
                left = false; 
            }

            //when the up key is pressed, change the direction to up 
            if (e.KeyData == Keys.Up && down == false)
            {
                down = false;
                up = true;
                right = false;
                left = false;
            }

            //when the right down key is pressed, change the direction to right 
            if (e.KeyData == Keys.Right && left == false)
            {
                down = false;
                up = false;
                right = true;
                left = false;
            }

            //when the up left key is pressed, change the direction to left
            if (e.KeyData == Keys.Left && right == false)
            {
                down = false;
                up = false;
                right = false;
                left = true;
            }
        }

        //On timer start 
        private void timer1_Tick(object sender, EventArgs e)
        {
            //convert the score to a string to display 
            SnakeScorelbl.Text = Convert.ToString(score);

            //If statments which control the movements of the snake
            if (down) { snake.moveDown(); }
            if (up) { snake.moveUp(); }
            if (right) { snake.moveRight(); }
            if (left) { snake.moveLeft(); }

            //collision for the snake with the food
            for (int i = 0; i < snake.snakeRec.Length; i++)
            {
                if (snake.snakeRec[i].IntersectsWith(food.foodRec))
                {
                    //On collision increase the score by 10, grow the snake by 1 and spawn a new food at a random locatio 
                    score += 10;
                    snake.growSnake();
                    food.foodLocation(randFood);
                }
            }

            //Make sure that collision is on 
            Collison();
            this.Invalidate(); 
        }

        //Collision calculation with itself
        public void Collison()
        {
            for (int i = 1; i < snake.snakeRec.Length; i++)
            {
                if (snake.snakeRec[0].IntersectsWith(snake.snakeRec[i]))
                {
                    restart();
                }
            }

            //Collision calculation with the boarder
            if (snake.snakeRec[0].X < 0 || snake.snakeRec[0].X > 290)
            {
                restart();
            }

            //Collision calculation with the boarder
            if (snake.snakeRec[0].Y < 0 || snake.snakeRec[0].Y > 290)
            {
                restart();
            }
        }

        //Restarts the game, prompts the user to press the space bar key again and resets the score to 0.
        public void restart()
        {
            timer1.Enabled = false;
            MessageBox.Show("Game Over!");
            SnakeScorelbl.Text = "0";
            score = 0;
            Press_Space.Text = "Press Space to Play";
            snake = new snake();
        }
    }
}
