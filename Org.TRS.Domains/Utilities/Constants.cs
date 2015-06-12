namespace Org.TRS.Domains.Utilities
{
    /// <summary>
    /// represents the directions
    /// </summary>
    public enum Direction
    {
        None,
        South,
        East,
        West,
        North
    }

    /// <summary>
    /// represents the types of command
    /// </summary>
    public enum CommandType
    {
        None,
        Place,
        Move,
        Left,
        Right,
        Report
    }
}
