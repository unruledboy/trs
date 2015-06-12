using Org.TRS.Domains.Utilities;

namespace Org.TRS.Domains.Model
{
    /// <summary>
    /// base state for all directions
    /// </summary>
    public abstract class State
    {
        public Table Table { get; private set; }

        public abstract Direction Direction { get; }

        public int X { get; set; }

        public int Y { get; set; }

        public abstract bool IsInPlace { get; }

        public Robot Robot { get; set; }

        public State(Table table)
        {
            Table = table;
        }

        public abstract void Move();

        public abstract void TurnLeft();

        public abstract void TurnRight();

        public string Report()
        {
            return IsInPlace ? string.Format("{0},{1},{2}", X, Y, Direction.ToString().ToUpperInvariant()) : string.Empty;
        }
    }
}
