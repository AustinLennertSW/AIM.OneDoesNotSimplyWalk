using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIM.OneDoesNotSimplyWalk
{
    public static class Program
    {

        
        /// <summary>
        /// Set of nodes to be evaluated
        /// </summary>
        private static List<Node> open;
        /// <summary>
        /// Set of nodes already evaluated
        /// </summary>
        private static List<Node> closed;

        public static int Main()
        {
            // TODO Ensure this is false when turning in
            bool testing = false;
            bool getDesmosPlottingString = true;
            Map.ConvertMapToNodes(testing);
            Map.WriteMapDetails();


            // Top left, 0,0
            Vector2I startPos = new Vector2I(0, 0);
            // Bottom right, 79,79 for production and 4,4 for test maps
            Vector2I endPos = new Vector2I(Map.map.GetLength(0)-1, Map.map.GetLength(1)-1);

            // Create sets to keep track of nodes
            open = new List<Node>();
            closed = new List<Node>();
            Node startNode = Map.map[startPos.X, startPos.Y];
            startNode.gScore = startNode.distance;
            open.Add(startNode);
            
            // Loop through A* Algorithm to find best path
            while (open.Count > 0)
            {
                // Node to evaluate
                Node current = open.OrderBy(x => x.fScore).ToArray()[0];
                if (current.pos.Equals(endPos))  // Found target node
                {
                    Console.WriteLine("Found path");
                    Console.WriteLine("Path Taken from end to start:");
                    Console.WriteLine($"    (row,col)   -   Node #");

                    Node n = current;
                    int c = 1;
                    while (n != null)
                    {

                        Console.WriteLine($"    {n.pos}   -   {c++}");
                        n = n.parent;
                    }

                    Console.WriteLine($"\nDistance Traveled: {current.gScore} rods");

                    if (getDesmosPlottingString)
                    {
                        Console.WriteLine("\n\n\nDesmos plotting string. Enter the following string into Desmos graphing calculator to visualise the path, just remove the last comma");
                        Console.WriteLine(current.GetDesmosPlottingString());
                    }

                    Console.WriteLine("Press enter to exit...");
                    Console.ReadLine();
                    return 0;
                }

                open.Remove(current);
                closed.Add(current);
                // Go through neighbors
                foreach (Node neighbor in Map.GetNeighbors(current))
                {
                    // Don't handle neighbor if already closed it
                    if (closed.Contains(neighbor)) continue;
                    float tentativeGScore = current.gScore + neighbor.distance;
                    // If this node is a better path nor neighbor, update neighbor
                    if (tentativeGScore < neighbor.gScore)
                    {
                        neighbor.parent = current;
                        neighbor.gScore = tentativeGScore;
                        if (!open.Contains(neighbor))
                        {
                            open.Add(neighbor);
                        }
                    }
                }
            }

            Console.WriteLine("No path found.\nPress enter to exit...");
            Console.ReadLine();
            return 1;
        }
    }
}
