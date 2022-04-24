using NUnit.Framework;
using ToyRobot.Domain;
using ToyRobot.Models;

namespace ToyRobot.Tests
{
    [TestFixture]
    public class RobotShould
    {
        private Robot _robot;

        [SetUp]
        public void SetUp()
        {
            _robot = new Robot();
        }

        [Test]
        public void Move_MoveFacingEast_CoordinateXGoesUpBy1_True()
        {
            //arrange
            var startingCoordinate = new Coordinate()
            {
                X = 0,
                Y = 0
            };

            //act
            _robot.Place(startingCoordinate, Direction.EAST);
            _robot.Move();
            var postiion = _robot.GetCurrentPositon();

            //assert
            Assert.AreEqual(postiion.Coordinate.X, 1);
            Assert.AreEqual(postiion.Coordinate.Y, 0);
        }

        [Test]
        public void Move_MoveFacingNorth_CoordinateYGoesUpBy1_True()
        {
            //arrange
            var startingCoordinate = new Coordinate()
            {
                X = 0,
                Y = 0
            };

            //act
            _robot.Place(startingCoordinate, Direction.NORTH);
            _robot.Move();
            var postiion = _robot.GetCurrentPositon();

            //assert
            Assert.AreEqual(postiion.Coordinate.Y, 1);
            Assert.AreEqual(postiion.Coordinate.X, 0);
        }

        [Test]
        public void Left_MovementDoesNotChangeButDirectionDoes_True()
        {
            //arrange
            var startingCoordinate = new Coordinate()
            {
                X = 0,
                Y = 0
            };

            //act
            _robot.Place(startingCoordinate, Direction.NORTH);
            _robot.Left();
            var postiion = _robot.GetCurrentPositon();

            //assert
            Assert.AreEqual(postiion.Coordinate.Y, 0);
            Assert.AreEqual(postiion.Coordinate.X, 0);
            Assert.AreEqual(postiion.Direction, "WEST");
        }

        [Test]
        public void Right_MovementDoesNotChangeButDirectionDoes_True()
        {
            //arrange
            var startingCoordinate = new Coordinate()
            {
                X = 0,
                Y = 0
            };

            //act
            _robot.Place(startingCoordinate, Direction.NORTH);
            _robot.Right();
            var postiion = _robot.GetCurrentPositon();

            //assert
            Assert.AreEqual(postiion.Coordinate.Y, 0);
            Assert.AreEqual(postiion.Coordinate.X, 0);
            Assert.AreEqual(postiion.Direction, "EAST");
        }
    }
}
