namespace ToyRobotV1
{
    public class Simulator
    {
        public Robot Robot;
        public Surface Surface { get; set; }

        public Simulator(Surface surface)
        {
            Surface = surface;
        }

        public void Place(int east, int north, string direction)
        {
            if (Surface.IsValidLocation(east, north))
            {
                Robot = new Robot
                {
                    direction = direction.ToLower(),
                    east = east,
                    north = north
                };
            }
        }

        public void RobotMoves(string movement)
        {
            switch (movement)
            {
                case "move":
                    if (Surface.IsValidLocation(Robot.east + 1, Robot.north + 1)
                        || Surface.IsValidLocation(Robot.east - 1, Robot.north - 1))
                    {
                        Robot.Move();
                    }
                    break;
                case "right":
                    Robot.TurnRight();

                    break;
                case "left":
                    Robot.TurnLeft();
                    break;
            }
        }

        public string Report()
        {
            return Robot.Report();
        }
    }
}
