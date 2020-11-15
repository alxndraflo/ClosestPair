using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestPair
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Point> pointsList = new List<Point>();

            //Create list for filenames
            List<string> filenames = new List<string>();
            filenames.Add("10points.txt");
            filenames.Add("100points.txt");
            filenames.Add("1000points.txt");

            bool stop = true;

            try
            {
                char[] delimiters = { ' ', '\n' };

                foreach (var file in filenames)
                {
                    Console.WriteLine($"{file} test file:\n");

                    string input;
                    string[] fileText;

                    //Read from file corresponding to user input
                    using (StreamReader reader = new StreamReader(file))
                    {
                        while ((input = reader.ReadLine()) != null)
                        {
                            fileText = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                            //Create new point
                            Point point = new Point(float.Parse(fileText[0]), float.Parse(fileText[1]));

                            pointsList.Add(point);
                        }
                    }

                    //Create closest pair object
                    ClosestPair closestPair = new ClosestPair(pointsList);

                    //Get closest pair
                    Pair cP = closestPair.GetClosestPair();

                    //Print closest pair output (pair coords, distance)
                    Console.WriteLine("The minimum distance is:");
                    Console.WriteLine($"{cP.GetDistance()} : {cP.GetP1()} <---> {cP.GetP2()}\n\n");

                    //Clear points list
                    pointsList.Clear();
                }

                //Read line in console so program doesn't close automatically
                Console.ReadLine();

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                Console.WriteLine($"Stack Trace: {e.StackTrace}");
            }
}
    }
}
