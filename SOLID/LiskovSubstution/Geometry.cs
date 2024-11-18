using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstution
{
    public class Geometry
    {
        public static IArea GetRectangle(int unitLength1, int? unitLength2 = null)
        {
            ////
            if (unitLength2.HasValue)
            {
                return new Rectangle() { Width = unitLength1, Height = unitLength2.Value };
            }
            return new Square() { EdgeLength = unitLength1 };
        }
    }

    public interface IArea
    {
        int GetArea();
    }
    public class Rectangle : IArea
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public int GetArea() => Width * Height;
    }

    public class Square : IArea//:Rectangle
    {
        //public override int Width { get => base.Width; set{ base.Width = value; base.Height = value; } }
        //public override int Height { get => base.Width; set { base.Width = value; base.Height = value; } }
        public int EdgeLength { get; set; }
        public int GetArea() => EdgeLength * EdgeLength;
    }
}
