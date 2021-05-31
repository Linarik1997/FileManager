using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.UI.Base
{
    class Figure
    {
        protected List<Point> pList { get; set; }
        public virtual void Draw()
        {
            foreach(var p in pList)
            {
                p.Draw();
            }
        }

    }
}
