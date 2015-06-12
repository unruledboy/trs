using System;

namespace Org.TRS.Domains.Model
{
    /// <summary>
    /// represents the toy robot
    /// </summary>
    public class Robot
    {
        /// <summary>
        /// current state
        /// </summary>
        public State CurrentState { get; set; }

        public Robot(State state)
        {
            CurrentState = state;
            CurrentState.Robot = this;
        }

        /// <summary>
        /// move the toy robot forward
        /// </summary>
        public void Move()
        {
            CurrentState.Move();
        }

        /// <summary>
        /// turn the toy robot to left
        /// </summary>
        public void TurnLeft()
        {
            CurrentState.TurnLeft();
        }

        /// <summary>
        /// turn the toy robot to right
        /// </summary>
        public void TurnRight()
        {
            CurrentState.TurnRight();
        }

        /// <summary>
        /// provide the current location and facing of the toy robot
        /// </summary>
        /// <returns></returns>
        public string Report()
        {
            return CurrentState.Report();
        }
    }
}
