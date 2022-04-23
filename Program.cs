using System;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            var robot = new Robot();
            var table = new Table(robot);
            var inputHandler = new InputHandler();
            inputHandler.Init();

            var endApp = false;
            while (!endApp)
            {
                var input = Console.ReadLine();
                if (input.Equals("end", StringComparison.OrdinalIgnoreCase))
                {
                    endApp = true;
                }
                else
                {
                    //check the input that being passed then if all good you may continue to run the code
                    if (inputHandler.CheckInput(input))
                    {
                        table.HandleCommand(input);
                    }

                }
            }


            //exit command to close the console application
        }
    }
}
