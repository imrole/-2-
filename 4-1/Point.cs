using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 第四章
{
    public class Point
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Distance(Point pointB)
        {
            return Math.Sqrt((this.X - pointB.X) * (this.X - pointB.X) + (this.Y - pointB.Y) * (this.Y - pointB.Y));
        }
    }
}
