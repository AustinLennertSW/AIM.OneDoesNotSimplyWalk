using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AIM.OneDoesNotSimplyWalk
{
    /// <summary>
    /// A 2 dimensional integral vector
    /// </summary>
    public class Vector2I
    {

        private int _x;

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        private int _y;

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }


        public Vector2I()
        {

        }

        public Vector2I(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (this == obj) return true;
            if (typeof(Vector2I) != obj.GetType()) return false;
            Vector2I other = (Vector2I)obj;
            if (other.X == this.X && other.Y == this.Y) return true;
            return base.Equals(obj);
        }

        /// <summary>
        /// Subtracts the Vector by another provided vector
        /// </summary>
        /// <param name="other">Vector to subtract by</param>
        /// <returns>This vector - other vector</returns>
        public Vector2I Minus(Vector2I other)
        {
            return new Vector2I(X - other.X, Y - other.Y);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
