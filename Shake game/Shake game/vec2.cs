using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shake_game
{
    class vec2
    {
        public int x;
        public int y;

        public vec2(int x, int y) { this.x = x; this.y = y; }
        public vec2(vec2 v) { this.x = v.x; this.y = v.y; }
        public vec2(int other) : this(other, other) { }
        public vec2() : this(0, 0) { }

        public static vec2 operator *(vec2 a, int b) { return new vec2(a.x * b, a.y * b); }
        public static vec2 operator +(vec2 a, vec2 b) { return new   vec2(a.x + b.x, a.y + b.y); }
        public static vec2 operator +(vec2 a, int b) { return new vec2(a.x + b, a.y + b); }
        public static vec2 operator -(vec2 a, int b) { return new vec2(a.x - b, a.y - b); }
        public static vec2 operator -(vec2 a, vec2 b) { return new   vec2(a.x - b.x, a.y - b.y); }

        public override string ToString()
        {
            return $"x = {x}; y = {y}";
        }
    }
}
