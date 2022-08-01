using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ToyRobotV1
{
    public class Command
    {
        public Simulator Simulation;
        public Table Table = new Table(5, 5);
        public bool Placed;
        public string Message = string.Empty;
        public string ErrorInputs = "The inputs in the file are not correctly formatted.";

        public string Start(string[] commands)
        {
            Simulation = new Simulator(Table);
            foreach (string command in commands)
            {
                if (Placed)
                {
                    ProcessCommand(command);
                }

                if (command.Contains("PLACE"))
                {
                    Placed = true;
                    ProcessCommand(command);
                }

                if (Message == ErrorInputs)
                {
                    break;
                }

                if (Message.Length > 1)
                {
                    Console.WriteLine(Message);
                    Message = "";
                }
            }
            return Message;
        }

        public void ProcessCommand(string command)
        {
            if (!isCommandValid(command))
            {
                Message = ErrorInputs;
                return;
            }


            if (command.Contains("PLACE"))
            {
                string[] coordinates = command.Split(new[] { ',', ' ', }, StringSplitOptions.RemoveEmptyEntries);
                if (coordinates.Length == 4)
                {
                    int east;
                    int north;
                    bool eastTest = Int32.TryParse(coordinates[1], out east);
                    bool northTest = Int32.TryParse(coordinates[2], out north);
                    if (eastTest && northTest)
                    {
                        Simulation.Place(east, north, coordinates[3]);
                    }
                }

                if (Simulation.Robot == null)
                {
                    Message = ErrorInputs;
                }
            }

            if (command.Contains("MOVE") || command.Contains("RIGHT") || command.Contains("LEFT"))
            {
                Simulation.RobotMoves(command.ToLower());
            }

            if (command.Contains("REPORT"))
            {
                Message = Simulation.Report();
                return;
            }
        }

        private bool isCommandValid(string command)
        {
            var commandList = new List<string>() { "PLACE", "MOVE", "RIGHT", "LEFT", "REPORT"};
            return commandList.Any(x => command.Contains(x));
        }
    }
}
