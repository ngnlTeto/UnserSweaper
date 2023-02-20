namespace MinesweaperAPI.Model
{
    public struct Coords
    {
        public Coords(ushort x, ushort y)
        {
            X = x;
            Y = y;
        }

        public ushort X { get; }
        public ushort Y { get; }

        public override string ToString() => $"({X}, {Y})";
    }
}
