using Org.TRS.Domains.Model;
using Org.TRS.Domains.Utilities;

namespace Org.TRS.Domains.Logic
{
    /// <summary>
    /// builder for state
    /// </summary>
    public class StateBuilder
    {
        /// <summary>
        /// construct new state based on command
        /// </summary>
        /// <param name="command">user defined command</param>
        /// <param name="table">table top</param>
        /// <returns>new state</returns>
        public static State Create(Command command, Table table)
        {
            switch (command.Direction)
            {
                case Direction.South:
                    return new StateDirectionSouth(command.X, command.Y, table);
                case Direction.East:
                    return new StateDirectionEast(command.X, command.Y, table);
                case Direction.West:
                    return new StateDirectionWest(command.X, command.Y, table);
                case Direction.North:
                    return new StateDirectionNorth(command.X, command.Y, table);
                default:
                    return null;
            }
        }
    }
}
