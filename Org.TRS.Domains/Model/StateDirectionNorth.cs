using System;
using Org.TRS.Domains.Utilities;

namespace Org.TRS.Domains.Model
{
    /// <summary>
    /// represents current state is facing north
    /// </summary>
    public class StateDirectionNorth : State
    {
        /// <summary>
        /// current direction is north
        /// </summary>
        public override Direction Direction
        {
            get { return Direction.North; }
        }

        /// <summary>
        /// robot is in-place
        /// </summary>
        public override bool IsInPlace
        {
            get { return true; }
        }

        public StateDirectionNorth(int x, int y, Table table)
            : base(table)
        {
            if (x > table.MaxX || y > table.MaxY)
                throw new ArgumentOutOfRangeException();

            X = x;
            Y = y;
        }

        public StateDirectionNorth(State state)
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
            //facing north, so we move along Y axis
            if (Y >= Table.MaxY)
                throw new ArgumentOutOfRangeException();
            Y++;
        }

        /// <summary>
        /// turn the robot to left
        /// </summary>
        public override void TurnLeft()
        {
            //now north, transfer current state to left which is west
            Robot.CurrentState = new StateDirectionWest(this);
        }

        /// <summary>
        /// turn the robot to right
        /// </summary>
        public override void TurnRight()
        {
            //now north, transfer current state to left which is east
            Robot.CurrentState = new StateDirectionEast(this);
        }
    }
}
