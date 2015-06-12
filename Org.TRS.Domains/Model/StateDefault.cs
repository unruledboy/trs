using Org.TRS.Domains.Utilities;

namespace Org.TRS.Domains.Model
{
    /// <summary>
    /// initial state without any direction before toy robot is in place
    /// </summary>
    public class StateDefault : State
    {
        public override Direction Direction
        {
            get { return Direction.None; }
        }

        public override bool IsInPlace
        {
            get { return false; }
        }

        public StateDefault(Table table)
            : base(table)
        {
        }

        public override void Move()
        {
        }

        public override void TurnLeft()
        {
        }

        public override void TurnRight()
        {
        }
    }
}
