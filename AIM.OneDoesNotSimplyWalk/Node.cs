using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIM.OneDoesNotSimplyWalk
{
    public class Node
    {
        public Node()
        {

        }
        /// <summary>
        /// Creates a node at position x,y with a given distance from all nearby nodes
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="distance"></param>
        public Node(int x, int y, int distance)
        {
            pos = new Vector2I(x, y);
            this.distance = distance;
            gScore = float.PositiveInfinity;
        }

        /// <summary>
        /// The node preceding this one in the cheapest path
        /// </summary>
        public Node? parent { get; set; } = null;
        public Vector2I pos { get; set; }
        /// <summary>
        /// Distance between all surrounding nodes
        /// </summary>
        public int distance { get; set; }
        /// <summary>
        /// Currently known cost of cheapest path from start to here
        /// </summary>
        public float gScore { get; set; }
        /// <summary>
        /// Estimated cost of cheapest possible path from here to end
        /// </summary>
        public float hScore {
            get
            {
                Vector2I d = new Vector2I(Map.cols, Map.rows).Minus(pos);
                return d.X + d.Y;
            }
        }
        /// <summary>
        /// Total estimated cost from start to end through this node
        /// </summary>
        public float fScore
        {
            get
            {
                return gScore + hScore;
            }
        }


        public string GetDesmosPlottingString(StringBuilder? sb = null)
        {
            if (sb == null) sb = new StringBuilder();
            sb.Append($"({pos.X},{pos.Y}),");
            parent?.GetDesmosPlottingString(sb);
            return sb.ToString();
        }
    }
}
