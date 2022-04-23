﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ToyRobot
{
    public class InputHandler
    {
        private bool PlaceCommandUsed { get; set; }

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
            CheckCommand(input);
            return true;
        }

        private void CheckCoordinate(string input)
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

        private void CheckCommand(string input)
        {
            if(!Enum.IsDefined(typeof(Commands), input))
            {
                Console.WriteLine("You have used an invalid command, please try again");
            }
        }

        private void CheckPlaceHasBeenUsed(string input)
        {
            //if (input.Contains(Commands.PLACE))
            //{

            //}
        }


    }
}