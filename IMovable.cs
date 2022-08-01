using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotV1
{
    public interface IMovable
    {
        void Move();
        void TurnLeft();
        void TurnRight();
    }
}
