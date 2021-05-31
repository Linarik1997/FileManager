using System;

namespace FileManager.UI.Base
{
    class Point
    {
        public  int X;
        public  int Y;
        public  char Symbol;

        public Point()
        {

        }
        public Point(int x, int y, char symbol)
        {
            Symbol = symbol;
            X = x;
            Y = y;
        }
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
        }
    }
}
