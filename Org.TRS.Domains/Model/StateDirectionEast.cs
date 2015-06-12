using System;
using Org.TRS.Domains.Utilities;

namespace Org.TRS.Domains.Model
{
    /// <summary>
    /// represents current state is facing east
    /// </summary>
    public class StateDirectionEast : State
    {
        /// <summary>
        /// current direction is east
        /// </summary>
        public override Direction Direction
        {
            get { return Direction.East; }
        }

        /// <summary>
        /// robot is in-place
        /// </summary>
        public override bool IsInPlace
        {
            get { return true; }
        }

        public StateDirectionEast(int x, int y, Table table)
            : base(table)
        {
            if (x > table.MaxX || y > table.MaxY)
                throw new ArgumentOutOfRangeException();

            X = x;
            Y = y;
        }

        public StateDirectionEast(State state)
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
            //facing east, so we move along x axis
            if (X >= Table.MaxX)
                throw new ArgumentOutOfRangeException();
            X++;
        }

        /// <summary>
        /// turn the robot to left
        /// </summary>
        public override void TurnLeft()
        {
            //now east, transfer current state to left which is north
            Robot.CurrentState = new StateDirectionNorth(this);
        }

        /// <summary>
        /// turn the robot to right
        /// </summary>
        public override void TurnRight()
        {
            //now east, transfer current state to left which is south
            Robot.CurrentState = new StateDirectionSouth(this);
        }
    }
}
