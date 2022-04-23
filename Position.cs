namespace ToyRobot
{
    public class Position
    {
        public Position(Coordinate coordinate, string direction)
        {
            Coordinate = coordinate;
            Direction = direction;
        }

        public Coordinate Coordinate { get; }
        public string Direction { get; }
    }
}
