using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.UI.Base
{
    class HorizozntalLine:Figure
    {
        private char SymX = '—';
        public HorizozntalLine(int xLeft, int xRight, int y)
        {
            pList = new List<Point>();
            for (int x = xLeft; x <= xRight; x++)
            {
                Point p = new Point(x, y, SymX);
                pList.Add(p);
            }
        }
        public override void Draw()
        {
            base.Draw();
        }
    }
}
