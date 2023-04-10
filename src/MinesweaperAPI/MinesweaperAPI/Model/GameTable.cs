using MinesweaperAPI.Logic;

namespace MinesweaperAPI.Model
{
    public class GameTable
    {
        public Guid Id { get; }
        public Cell[,] Table { get; private set; }
        public ushort SizeTable { get => (ushort)Table.Length; }

        public GameTable(ushort tableSize)
        {
            Id = Guid.NewGuid();
            Table = GameCreateLogic.GetTable(tableSize, tableSize);
        }
    }
}
