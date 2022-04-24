using System;
using ToyRobot.Domain;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            var robot = new Robot();
            var table = new Table(robot);
            var inputHandler = new InputHandler(robot, table);
            inputHandler.Init();

            var endApp = false;
            while (!endApp)
            {
                var input = Console.ReadLine();
                if (input.Equals("END", StringComparison.OrdinalIgnoreCase))
                {
                    endApp = true;
                }
                else
                {
                    if (inputHandler.CheckInput(input))
                    {
                        inputHandler.HandleCommand(input);
                    }

                }
            }
        }
    }
}
