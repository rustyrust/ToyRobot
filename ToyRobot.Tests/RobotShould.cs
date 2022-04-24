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
        public void Move_MoveFacingSouth_CoordinateYGoesDownBy1_True()
        {
            //arrange
            var startingCoordinate = new Coordinate()
            {
                X = 0,
                Y = 1
            };

            //act
            _robot.Place(startingCoordinate, Direction.SOUTH);
            _robot.Move();
            var postiion = _robot.GetCurrentPositon();

            //assert
            Assert.AreEqual(postiion.Coordinate.Y, 0);
            Assert.AreEqual(postiion.Coordinate.X, 0);
        }

        [Test]
        public void Move_MoveFacingWest_CoordinateXGoesDownBy1_True()
        {
            //arrange
            var startingCoordinate = new Coordinate()
            {
                X = 1,
                Y = 0
            };

            //act
            _robot.Place(startingCoordinate, Direction.WEST);
            _robot.Move();
            var postiion = _robot.GetCurrentPositon();

            //assert
            Assert.AreEqual(postiion.Coordinate.Y, 0);
            Assert.AreEqual(postiion.Coordinate.X, 0);
        }

        [Test]
        public void Left_ChangeDirectionLeftWhenFacingNorth_ReturnWest_Sucess()
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
        public void Left_ChangeDirectionLeftWhenFacingWest_ReturnSouth_Sucess()
        {
            //arrange
            var startingCoordinate = new Coordinate()
            {
                X = 0,
                Y = 0
            };

            //act
            _robot.Place(startingCoordinate, Direction.WEST);
            _robot.Left();
            var postiion = _robot.GetCurrentPositon();

            //assert
            Assert.AreEqual(postiion.Coordinate.Y, 0);
            Assert.AreEqual(postiion.Coordinate.X, 0);
            Assert.AreEqual(postiion.Direction, "SOUTH");
        }

        [Test]
        public void Left_ChangeDirectionLeftWhenFacingSouth_ReturnEast_Sucess()
        {
            //arrange
            var startingCoordinate = new Coordinate()
            {
                X = 0,
                Y = 0
            };

            //act
            _robot.Place(startingCoordinate, Direction.SOUTH);
            _robot.Left();
            var postiion = _robot.GetCurrentPositon();

            //assert
            Assert.AreEqual(postiion.Coordinate.Y, 0);
            Assert.AreEqual(postiion.Coordinate.X, 0);
            Assert.AreEqual(postiion.Direction, "EAST");
        }

        [Test]
        public void Left_ChangeDirectionLeftWhenFacingEast_ReturnNorth_Sucess()
        {
            //arrange
            var startingCoordinate = new Coordinate()
            {
                X = 0,
                Y = 0
            };

            //act
            _robot.Place(startingCoordinate, Direction.EAST);
            _robot.Left();
            var postiion = _robot.GetCurrentPositon();

            //assert
            Assert.AreEqual(postiion.Coordinate.Y, 0);
            Assert.AreEqual(postiion.Coordinate.X, 0);
            Assert.AreEqual(postiion.Direction, "NORTH");
        }

        [Test]
        public void Right_ChangeDirectionRightWhenFacingNorth_ReturnEast_Sucess()
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

        [Test]
        public void Right_ChangeDirectionRightWhenFacingWest_ReturnNorth_Sucess()
        {
            //arrange
            var startingCoordinate = new Coordinate()
            {
                X = 0,
                Y = 0
            };

            //act
            _robot.Place(startingCoordinate, Direction.WEST);
            _robot.Right();
            var postiion = _robot.GetCurrentPositon();

            //assert
            Assert.AreEqual(postiion.Coordinate.Y, 0);
            Assert.AreEqual(postiion.Coordinate.X, 0);
            Assert.AreEqual(postiion.Direction, "NORTH");
        }

        [Test]
        public void Right_ChangeDirectionRightWhenFacingSouth_ReturnWest_Sucess()
        {
            //arrange
            var startingCoordinate = new Coordinate()
            {
                X = 0,
                Y = 0
            };

            //act
            _robot.Place(startingCoordinate, Direction.SOUTH);
            _robot.Right();
            var postiion = _robot.GetCurrentPositon();

            //assert
            Assert.AreEqual(postiion.Coordinate.Y, 0);
            Assert.AreEqual(postiion.Coordinate.X, 0);
            Assert.AreEqual(postiion.Direction, "WEST");
        }

        [Test]
        public void Right_ChangeDirectionRightWhenFacingEast_ReturnSouth_Sucess()
        {
            //arrange
            var startingCoordinate = new Coordinate()
            {
                X = 0,
                Y = 0
            };

            //act
            _robot.Place(startingCoordinate, Direction.EAST);
            _robot.Right();
            var postiion = _robot.GetCurrentPositon();

            //assert
            Assert.AreEqual(postiion.Coordinate.Y, 0);
            Assert.AreEqual(postiion.Coordinate.X, 0);
            Assert.AreEqual(postiion.Direction, "SOUTH");
        }
    }
}
