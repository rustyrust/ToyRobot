using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ToyRobot
{
    public class Table
    {
        private readonly Robot _robot;

        public Table(Robot robot)
        {
            _robot = robot;
        }

        //public Coordinates SufaceSize => new Coordinates() { X = 5, Y = 5};
        public int MaxCoordinateSize => 5;
        public int MinCoordinateSize => 0;

        public void Report()
        {
            var currentPosition = _robot.GetCurrentPositon();
            Console.WriteLine($"Output: {currentPosition.Coordinate.X}, {currentPosition.Coordinate.Y}, {currentPosition.Direction}");
        }

        //NOTE i feel like this should be in InputHander Class
        public void HandleCommand(string input)
        {
            if (input.Contains("PLACE"))
            {
                var face = GetFace(input.ToString());
                var coordinate = GetCoordinates(input.ToString());
                _robot.Place(coordinate, face);
            }
            else
            {
                var command = (Command)Enum.Parse(typeof(Command), input);
                switch (command)
                {
                    case Command.RIGHT:
                        _robot.Right();
                        break;
                    case Command.LEFT:
                        _robot.Left();
                        break;
                    case Command.MOVE:
                        _robot.Move();
                        break;
                    case Command.REPORT:
                        Report();
                        break;
                }
            }
        }

        //NOTE i feel like this should be in InputHander Class
        private Coordinate GetCoordinates(string input)
        {
            var coordinate = new Coordinate();

            for (int i = 0; i < input.Length; i++)
            {
                if (i == 6)
                {
                    coordinate.X = int.Parse(input[i].ToString());
                }
                else if (i == 8)
                {
                    coordinate.Y = int.Parse(input[i].ToString());
                }
            }
            return coordinate;
        }

        //NOTE i feel like this should be in InputHander Class
        private string GetFace(string input)
        {
            var rgx = new Regex("[^,]*$");
            return rgx.Match(input).Value;
        }
    }
}
