using System;
using Org.TRS.Domains.Model;
using Org.TRS.Domains.Utilities;

namespace Org.TRS.Domains.Logic
{
    /// <summary>
    /// main controller for the toy robot
    /// </summary>
    public class Controller
    {
        private Robot _robot;

        public Controller(Robot robot)
        {
            _robot = robot;
        }

        /// <summary>
        /// accept and run user defined command
        /// </summary>
        /// <param name="commandText">raw command text</param>
        /// <returns>
        /// if it is report, returns current state, otherwise, empty
        /// if it is invalid command, exception will throw
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public string Accept(string commandText)
        {
            var result = string.Empty;
            var parser = new CommandParser(commandText);
            var command = parser.Parse();
            if (command.IsValid)
                result = Run(command);
            else
                throw new ArgumentException();
            return result;
        }

        /// <summary>
        /// run user defined command
        /// </summary>
        /// <param name="command">parsed valid comand</param>
        /// <returns>
        /// if it is report, returns current state, otherwise, empty
        /// if it is invalid command, exception will throw
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        private string Run(Command command)
        {
            var result = string.Empty;
            switch (command.CommandType)
            {
                case CommandType.Place:
                    //each place command will re-initiate a new robot
                    _robot = new Robot(StateBuilder.Create(command, _robot != null ? _robot.CurrentState.Table : new Table()));
                    break;
                case CommandType.Move:
                    _robot.Move();
                    break;
                case CommandType.Left:
                    _robot.TurnLeft();
                    break;
                case CommandType.Right:
                    _robot.TurnRight();
                    break;
                case CommandType.Report:
                    result = _robot.Report();
                    break;
            }
            return result;
        }
    }
}
