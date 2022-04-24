namespace ToyRobot.Models
{
    public class Position
    {
        public Position(Coordinate coordinate, string direction)
        {
            Coordinate = coordinate;
            Direction = direction;
        }

        public Coordinate Coordinate { get; set; }
        public string Direction { get; set; }
    }
}
