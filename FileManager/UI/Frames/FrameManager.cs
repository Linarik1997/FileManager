using FileManager.UI.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.UI.Frames
{
    class FrameManager
    {
        public readonly int indent = 3;
        public readonly char corner = '+';
        public readonly int treeFrameHeight = 26;
        public readonly int infoFrameHeight = 37;
        public readonly int clHeght = 39;
        public void TreeFrame()
        {
            Point LU = new Point(0, treeFrameHeight - treeFrameHeight, corner);
            Point RU = new Point(Console.WindowWidth - 1, treeFrameHeight - treeFrameHeight, corner);
            Point LD = new Point(0, treeFrameHeight, corner);
            Point RD = new Point(Console.WindowWidth - 1, treeFrameHeight, corner);
            Frame treeFrame = new Frame(LU, RU, LD, RD);
            treeFrame.Draw();
        }
        private void SetCursorTreeFrame()
        {
            Console.SetCursorPosition(indent, 1);
        }
        public void ClearTreeFrame()
        {
            for(int i = 1; i < treeFrameHeight; i++)
            {
                Console.SetCursorPosition(indent, i);
                Console.Write(new string(' ', Console.BufferWidth - (indent + 1)));
            } 
        }
        public void TreeFrameManageContent(string [] content)
        {
            ClearTreeFrame();
            SetCursorTreeFrame();
            for(int i = 0;i<content.Length; i++)
            {
                Console.SetCursorPosition(indent,1+i);
                Console.Write(content[i]);
            }
            SetCursorToCL();
        }
        public void InfoFrame()
        {
            Point LU = new Point(0, treeFrameHeight, corner);
            Point RU = new Point(Console.WindowWidth - 1, infoFrameHeight - infoFrameHeight, corner);
            Point LD = new Point(0, infoFrameHeight, corner);
            Point RD = new Point(Console.WindowWidth - 1, infoFrameHeight, corner);
            Frame infoFrame = new Frame(LU, RU, LD, RD);
            infoFrame.Draw();
        }
        public void clFrame()
        {
            Point LU = new Point(0, infoFrameHeight, corner);
            Point RU = new Point(Console.WindowWidth - 1, clHeght - clHeght, corner);
            Point LD = new Point(0, clHeght, corner);
            Point RD = new Point(Console.WindowWidth - 1, clHeght, corner);
            Frame infoFrame = new Frame(LU, RU, LD, RD);
            Console.SetCursorPosition(1, clHeght - 1);
            Console.Write('>');
            infoFrame.Draw();
        }
        public void SetCursorToCL()
        {
            Console.SetCursorPosition(indent, clHeght - 1);
        }
        public void ClearCL()
        {
            SetCursorToCL();
            Console.Write(new string(' ', Console.BufferWidth - (indent + 1)));
        }

    }
}

