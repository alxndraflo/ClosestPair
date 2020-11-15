using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestPair
{
    class ClosestPair
    {
        //Data
        private List<Point> pointsList = new List<Point>();

        //Constructor
        public ClosestPair(List<Point> pointsIn)
        {
            pointsList = pointsIn;
        }

        //Public Methods

        //Public method to drive algorithm
        public Pair GetClosestPair()
        {
            List<Point> ptsSortedX = new List<Point>();
            List<Point> ptsSortedY = new List<Point>();
            
            //Sort points by x-coord
            ptsSortedX = pointsList;
            ptsSortedX.Sort((pt1, pt2) => pt1.getX().CompareTo(pt2.getX()));

            //Sort points by y-coord
            ptsSortedY = pointsList;
            ptsSortedY.Sort((pt1, pt2) => pt1.getY().CompareTo(pt2.getY()));

            //Find closest pair of points
            Pair closestPair = FindClosestPair(ptsSortedX, ptsSortedY);

            return closestPair;
        }

        //Private Methods

        //Method to compute the closest pair of points in a set of points
        private Pair FindClosestPair(List<Point> sortedByX, List<Point> sortedByY)
        {
            Pair closestPair;

            //if less than 2 points, then return null -- Base Case 1
            if (sortedByX.Count < 2)
            {
                return null;
                
            }
            //if only 2 points in list, return the points -- Base Case 2
            if (sortedByX.Count == 2)
            {
                //closestPair = new Pair(sortedByX[0], sortedByX[1]);
                return new Pair(sortedByX[0], sortedByX[1]);
            }

            //split points list into lhs and rhs - sorted by X-COORD
            var lhsPtsX = sortedByX.Take(sortedByX.Count / 2).ToList();
            var rhsPtsX = sortedByX.Skip(sortedByX.Count / 2).ToList();

            //get middle point - (actually a double bc using x value)
            var mid = lhsPtsX.Last().getX();

            //split points into lhs and rhs - sorted by Y-COORD
            var lhsPtsY = sortedByY.Where(pt => pt.getX() <= mid).ToList();
            var rhsPtsY = sortedByY.Where(pt => pt.getX() > mid).ToList();

            //recurse over lhs and rhs to find closest pair
            var lhsPair = FindClosestPair(lhsPtsX, lhsPtsY);
            var rhsPair = FindClosestPair(rhsPtsX, rhsPtsY);

            //Get closest pair from lhs and rhs
            if (rhsPair == null)
            {
                closestPair = lhsPair;
            }
            else if (lhsPair == null)
            {
                closestPair = rhsPair;
            }
            else
            {
                //compute closest pair out of lhs and rhs
                if (lhsPair.GetDistance() < rhsPair.GetDistance())
                {
                    closestPair = lhsPair;
                }
                else
                {
                    closestPair = rhsPair;
                }
            }

            //Now check outside middle section to verify edge cases
            closestPair = CheckEdgeCases(sortedByY, mid, closestPair);

            return closestPair;
        }

        //Method to check for edge cases in the closest pair algorithm
        private Pair CheckEdgeCases(List<Point> sortedByY, double mid, Pair closestPair)
        {
            //find points within minimum distance of mid line
            var ptsInMiddle = sortedByY.Where(pt => Math.Abs(mid - pt.getX()) <= closestPair.GetDistance());

            //check points sorted by y-coord
            for (int i = 0; i < sortedByY.Count - 1; i++)
            {
                for (int j = i + 1; j < i + 8 && j < sortedByY.Count; j++)
                {
                    //check if pair is closer than the min
                    if (sortedByY[i].GetDistance(sortedByY[j]) < closestPair.GetDistance())
                    {
                        closestPair = new Pair(sortedByY[i], sortedByY[j]);
                    }
                }
            }

            return closestPair;
        }
    }
}
