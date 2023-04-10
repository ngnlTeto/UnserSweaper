using MinesweaperAPI.Model;

namespace MinesweaperAPI.Logic
{
    public class GameCreateLogic
    {
        public static Cell[,] GetTable(int horizontalLength, int vertcalLength)
        {
            Random rnd = new Random();

            // return table
            Cell[,] table = new Cell[horizontalLength, vertcalLength];

            // fill table
            for (int x = 0; x < horizontalLength; x++)
            {
                for (int y = 0; y < vertcalLength; y++)
                {
                    table[x, y] = new Cell(
                        new Coords(Convert.ToUInt16(x),
                        Convert.ToUInt16(y)), CellTypeEnum.None
                    );
                }
            }


            // general information
            int cellCount = horizontalLength * vertcalLength;
            int ratio = rnd.Next(15, 21);
            int bombCount = cellCount / ratio;

            // generate bombspots
            List<Coords> bombSpots = new List<Coords>();
            for (int i = 0; i < bombCount; i++)
            {
                Coords possibleSpot;
                do
                {
                    possibleSpot = new(
                        Convert.ToUInt16(rnd.Next(horizontalLength)),
                        Convert.ToUInt16(rnd.Next(vertcalLength))
                    );
                } while (bombSpots.Contains(possibleSpot));
                bombSpots.Add(possibleSpot);
            }

            // place bombs on table
            foreach (var bombSpot in bombSpots)
            {
                table[bombSpot.X, bombSpot.Y] = new Cell(bombSpot, CellTypeEnum.Bomb);

                for (int x = bombSpot.X - 1; x <= bombSpot.X + 1; x++)
                {
                    for (int y = bombSpot.Y - 1; y <= bombSpot.Y + 1; y++)
                    {
                        // checks i and j for validity
                        if (x < 0 ||
                            y < 0 ||
                            x > table.GetLength(0) ||
                            y > table.GetLength(1)
                        )
                        {
                            table[x, y] = countBombnearCellUp(table[x, y]);
                        }
                    }
                }
            }

            return table;
        }

        private static Cell countBombnearCellUp(Cell cell)
        {
            if (cell.Type is not CellTypeEnum.Bomb or CellTypeEnum.MineNear8)
            {
                int cellTypeNumber = (int)cell.Type;
                cell.Type = (CellTypeEnum)(cellTypeNumber + 1);
            }
            return cell;
        }
    }
}
