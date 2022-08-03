using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_work
{
    public abstract class AbstractCircle //abstract circle with fullness, x, y and color
    {
        public bool F { set; get; }
        public int X { set; get; }
        public int Y { set; get; }
        public abstract Color CircleColor();
    }
    public class RedCircle : AbstractCircle
    {
        public RedCircle(bool f, int x, int y)
        {
            this.F = f;
            this.X = x;
            this.Y = y;
        }
        public override Color CircleColor()
        {
            return Color.Red;
        }

    }
    public class BlueCircle : AbstractCircle
    {
        public BlueCircle(bool f, int x, int y)
        {
            this.F = f;
            this.X = x;
            this.Y = y;
        }
        public override Color CircleColor()
        {
            return Color.Blue;
        }
    }
}
