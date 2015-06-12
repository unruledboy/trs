namespace Org.TRS.Domains.Model
{
    /// <summary>
    /// represents the table top
    /// </summary>
    public class Table
    {
        public int MinX { get; private set; }
        public int MaxX { get; private set; }
        public int MinY { get; private set; }
        public int MaxY { get; private set; }

        public Table(int minX = 0, int maxX = 4, int minY = 0, int maxY = 4)
        {
            MinX = minX;
            MaxX = maxX;
            MinY = minY;
            MaxY = maxY;
        }
    }
}
