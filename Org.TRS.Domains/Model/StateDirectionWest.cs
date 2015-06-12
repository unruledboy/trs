using System;
using Org.TRS.Domains.Utilities;

namespace Org.TRS.Domains.Model
{
    /// <summary>
    /// represents current state is facing west
    /// </summary>
    public class StateDirectionWest : State
    {
        /// <summary>
        /// current direction is west
        /// </summary>
        public override Direction Direction
        {
            get { return Direction.West; }
        }

        /// <summary>
        /// robot is in-place
        /// </summary>
        public override bool IsInPlace
        {
            get { return true; }
        }

        public StateDirectionWest(int x, int y, Table table)
            : base(table)
        {
            if (x > table.MaxX || y > table.MaxY)
                throw new ArgumentOutOfRangeException();

            X = x;
            Y = y;
        }

        public StateDirectionWest(State state)
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
            //facing west, so we move along x axis
            if (X <= Table.MinX)
                throw new ArgumentOutOfRangeException();
            X--;
        }

        /// <summary>
        /// turn the robot to left
        /// </summary>
        public override void TurnLeft()
        {
            //now west, transfer current state to left which is south
            Robot.CurrentState = new StateDirectionSouth(this);
        }

        /// <summary>
        /// turn the robot to right
        /// </summary>
        public override void TurnRight()
        {
            //now west, transfer current state to left which is north
            Robot.CurrentState = new StateDirectionNorth(this);
        }
    }
}
