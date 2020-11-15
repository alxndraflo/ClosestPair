using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestPair
{
    class Point
    {
        //Data
        private double x;
        private double y;

        //Constructor
        public Point(float xIn, float yIn)
        {
            this.x = xIn;
            this.y = yIn;
        }

        //Getters

        public double getX()
        {
            return x;
        }

        public double getY()
        {
            return y;
        }

        //Public Methods

        public double GetDistance(Point p)
        {
            double distance = Math.Sqrt((p.x - x) * (p.x - x) + (p.y - y) * (p.y - y));

            return distance;
        }

        //String format method
        public override string ToString()
        {
            return string.Format($"({x}, {y})");
        }
    }
}
