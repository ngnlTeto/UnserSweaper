namespace MinesweaperAPI.Model
{
    public class Cell
    {
        public Cell(Coords coords, CellTypeEnum type)
        {
            Coords = coords;
            Type = type;
            IsKnown = false;
        }

        public  Coords Coords { get; }
        public CellTypeEnum Type { get; set; }
        public bool IsKnown { get; private set; }

        public void PublishCell()
        {
            IsKnown = true;
        }
    }
}
