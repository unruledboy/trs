using Org.TRS.Domains.Utilities;

namespace Org.TRS.Domains.Model
{
    /// <summary>
    /// user defined command
    /// </summary>
    public class Command
    {
        /// <summary>
        /// type of command
        /// </summary>
        public CommandType CommandType { get; set; }

        /// <summary>
        /// location in x axis
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// location in y axis
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// indicates if the command is valid or not
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// facing
        /// </summary>
        public Direction Direction { get; set; }
    }
}
