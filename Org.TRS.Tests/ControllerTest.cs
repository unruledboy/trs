using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Org.TRS.Domains.Logic;
using Org.TRS.Domains.Model;
using Org.TRS.Domains.Utilities;

namespace Org.TRS.Tests
{
    [TestClass]
    public class ControllerTest
    {
        [TestMethod]
        public void ControllerReportNothing()
        {
            var controller = CreateController();
            var expected = string.Empty;
            var actual = controller.Accept("REPORT");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ControllerPlaceNorth()
        {
            var expected = "0,0,NORTH";
            var actual = Run(CreateController(), new [] 
                { 
                    "PLACE 0,0,NORTH",
                    "REPORT"
                });
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ControllerPlaceSouth()
        {
            var expected = "1,0,SOUTH";
            var actual = Run(CreateController(), new [] 
                { 
                    "PLACE 1,0,SOUTH",
                    "REPORT"
                });
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ControllerPlaceEast()
        {
            var expected = "1,2,EAST";
            var actual = Run(CreateController(), new [] 
                { 
                    "PLACE 1,2,EAST",
                    "REPORT"
                });
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ControllerPlaceWest()
        {
            var expected = "3,4,WEST";
            var actual = Run(CreateController(), new [] 
                { 
                    "PLACE 3,4,WEST",
                    "REPORT"
                });
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ControllerExample1Move()
        {
            var expected = "0,1,NORTH";
            var actual = Run(CreateController(), new [] 
                { 
                    "PLACE 0,0,NORTH",
                    "MOVE",
                    "REPORT"
                });
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ControllerExample2TurnLeft()
        {
            var expected = "0,0,WEST";
            var actual = Run(CreateController(), new [] 
                { 
                    "PLACE 0,0,NORTH",
                    "LEFT",
                    "REPORT"
                });
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ControllerExample3MoveAndTurnLeft()
        {
            var expected = "3,3,NORTH";
            var actual = Run(CreateController(), new [] 
                { 
                    "PLACE 1,2,EAST",
                    "MOVE",
                    "MOVE",
                    "LEFT",
                    "MOVE",
                    "REPORT"
                });
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ControllerInvalidMove()
        {
            try
            {
                Run(CreateController(), new [] 
                { 
                    "PLACE 0,0,NORTH",
                    "MOVE",
                    "MOVE",
                    "MOVE",
                    "MOVE",
                    "MOVE",
                    "REPORT"
                });
                Assert.Fail("should be invalid move");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(ArgumentOutOfRangeException), ex.GetType());
            }
        }

        [TestMethod]
        public void ControllerInvalidCommand()
        {
            try
            {
                Run(CreateController(), new [] 
                { 
                    "hello, world"
                });
                Assert.Fail("should be invalid command");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(ArgumentException), ex.GetType());
            }
        }

        [TestMethod]
        public void ControllerInvalidCommandParameters()
        {
            try
            {
                Run(CreateController(), new []
                { 
                    "PLACE ,NORTH"
                });
                Assert.Fail("should be invalid command");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(ArgumentException), ex.GetType());
            }
        }

        private string Run(Controller controller, IEnumerable<string> commands)
        {
            var result = string.Empty;
            commands.ForEach(c =>
            {
                result = controller.Accept(c);
            });
            return result;
        }

        private Controller CreateController()
        {
            var state = new StateDefault(new Table());
            var robot = new Robot(state);
            return new Controller(robot);
        }
    }
}
