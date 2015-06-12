using System;
using Org.TRS.Domains.Model;
using Org.TRS.Domains.Utilities;

namespace Org.TRS.Domains.Logic
{
    /// <summary>
    /// parser for command and parameters
    /// </summary>
    public class CommandParser
    {
        private string _command;


        public CommandParser(string command)
        {
            _command = command;
        }

        /// <summary>
        /// parse command
        /// </summary>
        /// <returns>command type and parameters</returns>
        public Command Parse()
        {
            var result = new Command();
            CommandType commandType;
            _command = _command.Trim();
            var parts = _command.Split(' ');

            if (Enum.TryParse(parts[0], true, out commandType))
            {
                result.CommandType = commandType;
                switch (result.CommandType)
                {
                    case CommandType.Place:
                        //expecting 3 comma separated parameters: x,y,facing
                        if (parts.Length == 2)
                        {
                            var parameters = parts[1].Split(',');
                            if (parameters.Length == 3)
                            {
                                int x, y;
                                Direction direction;
                                if (int.TryParse(parameters[0], out x)
                                    && int.TryParse(parameters[1], out y)
                                    && Enum.TryParse(parameters[2], true, out direction))
                                {
                                    result.X = x;
                                    result.Y = y;
                                    result.Direction = direction;
                                    result.IsValid = true;
                                }
                            }
                        }
                        break;
                    default:
                        result.IsValid = true;
                        break;
                }
            }

            return result;
        }
    }
}