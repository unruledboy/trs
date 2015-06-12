using System;
using Org.TRS.Domains.Utilities;

namespace Org.TRS.Domains.Model
{
    /// <summary>
    /// represents current state is facing south
    /// </summary>
    public class StateDirectionSouth : State
    {
        /// <summary>
        /// current direction is south
        /// </summary>
        public override Direction Direction
        {
            get { return Direction.South; }
        }

        /// <summary>
        /// robot is in-place
        /// </summary>
        public override bool IsInPlace
        {
            get { return true; }
        }

        public StateDirectionSouth(int x, int y, Table table)
            : base(table)
        {
            if (x > table.MaxX || y > table.MaxY)
                throw new ArgumentOutOfRangeException();

            X = x;
            Y = y;
        }

        public StateDirectionSouth(State state)
            : base(state.Table)
        {
            X = state.X;
            Y = state.Y;
        }

        /// <summary>
        /// move the robot
        /// </summary>
        public override void Move()
        {
            //facing south, so we move along y axis
            if (Y <= Table.MinY)
                throw new ArgumentOutOfRangeException();
            Y--;
        }

        /// <summary>
        /// turn the robot to left
        /// </summary>
        public override void TurnLeft()
        {
            //now south, transfer current state to left which is east
            Robot.CurrentState = new StateDirectionEast(this);
        }

        /// <summary>
        /// turn the robot to right
        /// </summary>
        public override void TurnRight()
        {
            //now south, transfer current state to left which is west
            Robot.CurrentState = new StateDirectionWest(this);
        }
    }
}
