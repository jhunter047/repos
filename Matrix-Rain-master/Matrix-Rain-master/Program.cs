using System;


namespace Matrix
{
    class Program
    {
        static int counter;
        static Random randomPosition = new Random();

        static int flowSpeed = 100;
        static int fastFlow = flowSpeed + 30;
        static int textFlow = fastFlow + 50;



        static ConsoleColor baseColor = ConsoleColor.DarkGreen;
        static ConsoleColor greenColor = ConsoleColor.Green;
        static ConsoleColor fadedColor = ConsoleColor.White;

        static string endText = "";

        static char Asciicharacters
        {
            get
            {
                int t = randomPosition.Next(10);

                if (t <= 4) return (char)('a' + randomPosition.Next(27));
                else if (t <= 4) return (char)('a' + randomPosition.Next(27));
                else if (t <= 6) return (char)('A' + randomPosition.Next(27));
                else return (char)(randomPosition.Next(32, 255));


            }
        }

        static void Main()
        {
            Console.ForegroundColor = baseColor;
            Console.WindowLeft = Console.WindowTop = 0;
            Console.WindowHeight = Console.BufferHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.BufferWidth = Console.LargestWindowWidth;
            Console.SetWindowPosition(0, 0);
            Console.CursorVisible = false;

            int width, height;
            int[] y;
            initialize(out width, out height, out y);

            while (true)
            {
                counter++;
                columnupdate(width, height, y);
                if (counter > (3 * flowSpeed))
                    counter = 0;
            }
        }

        public static int yPositionFields(int yPosition, int height)
        {
            if (yPosition < 0) return yPosition + height;
            else if (yPosition < height) return yPosition;
            else return 0;
        }

        private static void initialize(out int width, out int height, out int[] y)
        {
            height = Console.WindowHeight;
            width = Console.WindowWidth - 1;
            y = new int[width];
            Console.Clear();

            for (int x = 0; x < width; ++x) { y[x] = randomPosition.Next(height); }
        }

        private static void columnupdate(int width, int height, int[] y)
        {
            int x;
            if (counter < flowSpeed)
            {
                for (x = 0; x < width; ++x)
                {
                    if (x % 10 == 1) Console.ForegroundColor = fadedColor;
                    else Console.ForegroundColor = baseColor;

                    Console.SetCursorPosition(x, y[x]);
                    Console.Write(Asciicharacters);

                    if (x % 10 == 9) Console.ForegroundColor = fadedColor;
                    else Console.ForegroundColor = baseColor;

                    int temp = y[x] - 2;
                    Console.SetCursorPosition(x, yPositionFields(temp, height));
                    Console.Write(Asciicharacters);

                    int temp1 = y[x] - 20;
                    Console.SetCursorPosition(x, yPositionFields(temp1, height));
                    Console.Write(' ');
                    y[x] = yPositionFields(y[x] + 1, height);
                }
            }

            else if (counter > flowSpeed && counter < fastFlow)
            {
                for (x = 0; x < width; ++x)
                {
                    Console.SetCursorPosition(x, y[x]);
                    if (x % 10 == 9) Console.ForegroundColor = fadedColor;
                    else Console.ForegroundColor = baseColor;

                    Console.Write(Asciicharacters);

                    y[x] = yPositionFields(y[x] + 1, height);
                }
            }

            else if (counter > fastFlow)
            {
                for (x = 0; x < width; ++x)
                {
                    Console.SetCursorPosition(x, y[x]);
                    Console.Write(' ');

                    int temp1 = y[x] - 20;
                    Console.SetCursorPosition(x, yPositionFields(temp1, height));
                    Console.Write(' ');

                    if (counter > fastFlow && counter < textFlow)
                    {
                        if (x % 10 == 9) Console.ForegroundColor = fadedColor;
                        else Console.ForegroundColor = baseColor;

                        int temp = y[x] - 2;
                        Console.SetCursorPosition(x, yPositionFields(temp, height));
                        Console.Write(Asciicharacters);
                    }
                    Console.SetCursorPosition(width / 2, height / 2);
                    Console.Write(endText);
                    y[x] = yPositionFields(y[x] + 1, height);
                }
            }
        }
    }
}
