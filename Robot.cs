namespace ToyRobot
{
    public class Robot
    {
        private Coordinate Coordinate { get; set; }
        private string Direction { get; set; }

        public Position GetCurrentPositon()
        {
            return new Position(Coordinate, Direction);
        }

        public void Move()
        {
            switch (Direction)
            {
                case "North":
                    Coordinate.Y += 1;
                    break;
                case "South":
                    Coordinate.Y -= 1;
                    break;
                case "West":
                    Coordinate.X -= 1;
                    break;
                case "East":
                    Coordinate.X += 1;
                    break;
            }
        }

        public void Left()
        {
            switch (Direction.ToLower())
            {
                case "north":
                    Direction = "West";
                    break;
                case "west":
                    Direction = "South";
                    break;
                case "south":
                    Direction = "East";
                    break;
                case "east":
                    Direction = "North";
                    break;
            }
        }

        public void Right()
        {
            switch (Direction.ToLower())
            {
                case "north":
                    Direction = "East";
                    break;
                case "west":
                    Direction = "North";
                    break;
                case "south":
                    Direction = "West";
                    break;
                case "east":
                    Direction = "South";
                    break;
            }
        }

        public void Place(Coordinate startingCoordinate, string direction)
        {
            Coordinate = startingCoordinate;
            Direction = direction;
        }
    }
}
