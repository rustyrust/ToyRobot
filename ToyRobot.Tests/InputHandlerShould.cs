using NUnit.Framework;
using ToyRobot.Domain;

namespace ToyRobot.Tests
{
    [TestFixture]
    public class InputHandlerShould
    {
        private Robot _robot;
        private Table _table;
        private InputHandler _inputHandler;

        [SetUp]
        public void SetUp()
        {
            _robot = new Robot();
            _table = new Table(_robot);
            _inputHandler = new InputHandler(_robot, _table);
        }

        [Test]
        public void CheckInput_PlaceCommandCorrect_CheckSuccess()
        {
            var result = _inputHandler.CheckInput("PLACE 0,0,NORTH");

            Assert.AreEqual(result, true);
        }

        [Test]
        public void CheckInput_PlaceCommandBadDirection_CheckFails()
        {
            var result = _inputHandler.CheckInput("PLACE 0,0,foo");

            Assert.AreEqual(result, false);
        }

        [Test]
        public void CheckInput_PlaceCommandXaxisGreaterThanGrid_CheckFails()
        {
            var result = _inputHandler.CheckInput("PLACE 20,0,NORTH");

            Assert.AreEqual(result, false);
        }

        [Test]
        public void CheckInput_PlaceCommandXaxisLessThanGrid_CheckFails()
        {
            var result = _inputHandler.CheckInput("PLACE 0.4,0,NORTH");

            Assert.AreEqual(result, false);
        }

        [Test]
        public void CheckInput_PlaceCommandYaxisGreaterThanGrid_CheckFails()
        {
            var result = _inputHandler.CheckInput("PLACE 0,20,NORTH");

            Assert.AreEqual(result, false);
        }

        [Test]
        public void CheckInput_PlaceCommandYaxisLessThanGrid_CheckFails()
        {
            var result = _inputHandler.CheckInput("PLACE 0,0.4,NORTH");

            Assert.AreEqual(result, false);
        }

        [Test]
        public void CheckInput_PlaceCommandNotComplete_CheckFails()
        {
            var result = _inputHandler.CheckInput("PLACE");

            Assert.AreEqual(result, false);
        }

        [Test]
        public void CheckInput_CommandBeforePlaceCommand_CheckFails()
        {
            var result = _inputHandler.CheckInput("LEFT");

            Assert.AreEqual(result, false);
        }

        [Test]
        public void CheckInput_PlaceCommandLowerCase_CheckFails()
        {
            var result = _inputHandler.CheckInput("place 0,0,NORTH");

            Assert.AreEqual(result, false);
        }

        [Test]
        public void CheckInput_PlaceCommandLowerCaseDirection_CheckFails()
        {
            var result = _inputHandler.CheckInput("PLACE 0,0,north");

            Assert.AreEqual(result, false);
        }

        [Test]
        public void CheckInput_CommandNotCorrect_CheckFails()
        {
            _inputHandler.CheckInput("PLACE 0,0,NORTH");
            var result = _inputHandler.CheckInput("foo");

            Assert.AreEqual(result, false);
        }

        [Test]
        public void CheckInput_PlaceThenMove_CheckSuccess()
        {
            _inputHandler.CheckInput("PLACE 0,0,NORTH");
            var result = _inputHandler.CheckInput("MOVE");

            Assert.AreEqual(result, true);
        }
    }
}
