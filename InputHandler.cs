using System;
using System.Text.RegularExpressions;

namespace ToyRobot
{
    public class InputHandler
    {
        private readonly Robot _robot;
        private readonly Table _table;

        public InputHandler(Robot robot, Table table)
        {
            _robot = robot;
            _table = table;
        }

        private Coordinate Coordinate { get; set; }
        private string Direction { get; set; }

        public void Init()
        {
            Console.WriteLine("Welcome to this ToyRobot Game");
            Console.WriteLine("Commands are;");
            Console.WriteLine("Place: This will place the robot on the table");
            Console.WriteLine("Move: This will move the robot by 1 unit");
            Console.WriteLine("Left: This will move the robots face left");
            Console.WriteLine("Right: This will move the robots face right");
            Console.WriteLine("Report: This will print out the current location of the robot");
            Console.WriteLine("End: This will end the app");
            Console.WriteLine("NOTE - you must start off with a place command");
        }

        public bool CheckInput(string input)
        {
            if (CheckInputCommand(input))
            {
                return CheckPosition();
            }
            return false;
        }

        private void GetCoordinates(string input)
        {
            var newCoordinate = new Coordinate();

            for (int i = 0; i < input.Length; i++)
            {
                if (i == 6)
                {
                    newCoordinate.X = int.Parse(input[i].ToString());
                }
                else if (i == 8)
                {
                    newCoordinate.Y = int.Parse(input[i].ToString());
                }
            }

            Coordinate = newCoordinate;
        }

        private void GetFace(string input)
        {
            var rgx = new Regex("[^,]*$");
            Direction = rgx.Match(input).Value;
        }

        private bool CheckPosition()
        {
            if (CheckDirection() && CheckPlaceCoordinate())
            {
                return true;
            }
            return false;
        }

        private bool CheckPlaceCoordinate()
        {
            if ((Coordinate.X > _table.MaxCoordinateSize || Coordinate.X < 0) ||
                (Coordinate.X > _table.MaxCoordinateSize || Coordinate.X < 0))
            {
                Console.WriteLine("You have provided coordinates that are outside the tables grid");
                return false;
            }
            return true;
        }

        private bool CheckDirection()
        {
            if (!Enum.IsDefined(typeof(Direction), Direction))
            {
                Console.WriteLine($"{Direction} is not a vaild input direction");
                return false;
            }
            return true;
        }

        private bool CheckInputCommand(string input)
        {
            if (input.Contains("PLACE"))
            {
                //METHOD to check the Coordinates
                GetCoordinates(input);
                GetFace(input);
                return true;
            }
            else if (!Enum.IsDefined(typeof(Command), input))
            {
                Console.WriteLine("You have used an invalid command, please try again");
                return false;
            }
            else if (Enum.IsDefined(typeof(Command), input))
            {
                return CheckPlaceHasBeenUsed();
            }
            return false;

        }

        private bool CheckPlaceHasBeenUsed()
        {
            if (Coordinate is null)
            {
                Console.WriteLine("You must use a PLACE command before using any other command");
                return false;
            }
            return true;
        }

        public void HandleCommand(string input)
        {
            if (input.Contains("PLACE"))
            {
                var direction = Direction;
                var coordinate = Coordinate;
                _robot.Place(coordinate, direction);
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
                        _table.Report();
                        break;
                }
            }
        }

    }
}
