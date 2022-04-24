using ToyRobot.Models;

namespace ToyRobot.Domain
{
    public class Robot
    {
        private Coordinate Coordinate { get; set; }
        private Direction Direction { get; set; }

        public Position GetCurrentPositon()
        {
            return new Position(Coordinate, Direction.ToString());
        }

        public void Move()
        {
            switch (Direction)
            {
                case Direction.NORTH:
                    Coordinate.Y += 1;
                    break;
                case Direction.SOUTH:
                    Coordinate.Y -= 1;
                    break;
                case Direction.WEST:
                    Coordinate.X -= 1;
                    break;
                case Direction.EAST:
                    Coordinate.X += 1;
                    break;
            }
        }

        public void Left()
        {
            switch (Direction)
            {
                case Direction.NORTH:
                    Direction = Direction.WEST;
                    break;
                case Direction.WEST:
                    Direction = Direction.SOUTH;
                    break;
                case Direction.SOUTH:
                    Direction = Direction.EAST;
                    break;
                case Direction.EAST:
                    Direction = Direction.NORTH;
                    break;
            }
        }

        public void Right()
        {
            switch (Direction)
            {
                case Direction.NORTH:
                    Direction = Direction.EAST;
                    break;
                case Direction.WEST:
                    Direction = Direction.NORTH;
                    break;
                case Direction.SOUTH:
                    Direction = Direction.WEST;
                    break;
                case Direction.EAST:
                    Direction = Direction.SOUTH;
                    break;
            }
        }

        public void Place(Coordinate startingCoordinate, Direction direction)
        {
            Coordinate = startingCoordinate;
            Direction = direction;
        }
    }
}
