using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.UI.Base
{
    class VerticalLine:Figure
    {

        private char SymY = '|';

        public enum Orientation
        {
            Left,
            Right
        }
        public VerticalLine(int yUp, int yDown, int x)
        {
            pList = new List<Point>();
            for (int y = yUp; y <= yDown; y++)
            {
                Point p = new Point(x, y, SymY);
                pList.Add(p);
            }
        }
        public override void Draw()
        {
            base.Draw();
        }
    }
}

