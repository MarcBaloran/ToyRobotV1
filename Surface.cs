using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotV1
{
    public abstract class Surface
    {
        public abstract int Width { get; set; }
        public abstract int Length { get; set; }
        public virtual bool IsValidLocation(int east, int north)
        {
            return east >= 0 && east < Width && north >= 0 && north < Length;
        }
    }
}
