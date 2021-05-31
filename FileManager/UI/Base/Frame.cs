using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.UI.Base
{
    class Frame: Figure
    {
        List<Point> Corners;
        List<Figure> Borders;
        int Width = Console.WindowWidth;


        public Frame(Point UpLeft, Point UpRight,Point DownLeft,Point DownRight)
        {
            Corners = new List<Point>();
            Corners.Add(UpLeft);
            Corners.Add(UpRight);
            Corners.Add(DownLeft);
            Corners.Add(DownRight);
            Borders = new List<Figure>();
            HorizozntalLine up = new HorizozntalLine(UpLeft.X + 1, UpRight.X - 1, UpLeft.Y);
            HorizozntalLine down = new HorizozntalLine(DownLeft.X + 1, DownRight.X - 1, DownLeft.Y);
            VerticalLine left = new VerticalLine(UpLeft.Y + 1, DownLeft.Y - 1, UpLeft.X);
            VerticalLine right = new VerticalLine(UpRight.Y + 1, DownRight.Y - 1, UpRight.X);
            Borders.Add(up);
            Borders.Add(down);
            Borders.Add(left);
            Borders.Add(right);
        }
        public void Draw()
        {
            foreach(var corner in Corners)
            {
                corner.Draw();
            }
            foreach(var border in Borders)
            {
                border.Draw();
            }
        }

    }
}
