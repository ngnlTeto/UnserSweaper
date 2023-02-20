using MinesweaperAPI.Model;

namespace MinesweaperAPI.Logic
{
    public class GameCreateLogic
    {
        public Cell[,] FillTable(Cell[,] table)
        {
            Random rnd = new Random();

            int iLength = table.GetLength(0);
            int jLength = table.GetLength(1);

            int cellCount = iLength * jLength;
            int ratio = rnd.Next(15, 21);
            int bombCount = cellCount / ratio;
        }
    }
}
