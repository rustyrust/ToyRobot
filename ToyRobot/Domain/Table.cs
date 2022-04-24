using System;

namespace ToyRobot.Domain
{
    public class Table
    {
        private readonly Robot _robot;

        public Table(Robot robot)
        {
            _robot = robot;
        }

        public int MaxCoordinateSize => 5;
        public int MinCoordinateSize => 0;

        public void Report()
        {
            var currentPosition = _robot.GetCurrentPositon();
            Console.WriteLine($"Output: {currentPosition.Coordinate.X}, {currentPosition.Coordinate.Y}, {currentPosition.Direction}");
        }
    }
}
