using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestPair
{
    class Pair
    {
        //Data
        private Point p1;
        private Point p2;
        private double distance;

        //Constructor
        public Pair(Point p1In, Point p2In)
        {
            this.p1 = p1In;
            this.p2 = p2In;
            this.distance = p1.GetDistance(p2);
        }

        //Getters
        public Point GetP1()
        {
            return this.p1;
        }

        public Point GetP2()
        {
            return this.p2;
        }

        public double GetDistance()
        {
            return this.distance;
        }
    }
}
