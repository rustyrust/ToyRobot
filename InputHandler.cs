using System;
using System.Text.RegularExpressions;

namespace ToyRobot
{
    public class InputHandler
    {
        private bool PlaceCommandUsed { get; set; }

        private Position Position { get; set; }

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
            GetCoordinates(input);
            GetFace(input);
            return CheckCommand(input);
        }

        private void GetCoordinates(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (i == 6)
                {
                    Position.Coordinate.X = int.Parse(input[i].ToString());
                }
                else if (i == 8)
                {
                    Position.Coordinate.Y = int.Parse(input[i].ToString());
                }
            }
        }

        private void GetFace(string input)
        {
            var rgx = new Regex("[^,]*$");
            Position.Direction = rgx.Match(input).Value;
        }

        private void CheckPlaceCoordinate(string input)
        {
            //if ()
            //{
            //    Console.WriteLine("You have provided coordinates that are outside the tables grid");
            //}
            //else
            //{
            //    Console.WriteLine("The coordinates provided are inVaild");
            //}
        }

        private bool CheckCommand(string input)
        {
            if (input.Contains("PLACE"))
            {
                PlaceCommandUsed = true;
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
            if (!PlaceCommandUsed)
            {
                Console.WriteLine("You must use a PLACE command before using any other command");
                return false;
            }
            return true;
        }

        private bool CheckFace(string input)
        {
            var rgx = new Regex("[^,]*$");
            return rgx.Match(input).Success;
        }

    }
}
