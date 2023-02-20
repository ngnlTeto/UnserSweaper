namespace MinesweaperAPI.Model
{
    public class GameTable
    {
        public Guid Id { get; }
        public Cell[,] Table { get; private set; }
        public ushort SizeTable { get; }

        public GameTable(ushort sizeTable)
        {
            Id = Guid.NewGuid();
            SizeTable = sizeTable;
            Table = new Cell[sizeTable, sizeTable];
        }
    }
}
