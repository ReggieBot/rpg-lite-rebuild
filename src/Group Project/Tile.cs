using Group_Project;

/// <summary>
/// represents a single cell in the 7x7 tile grid
/// each tile has a position, type, and tracks whether its interaction has been completed
/// </summary>
public class Tile
{
    // the row position in the 7x7 grid (0-6)
    public int Row { get; set; }
    // the column position in the 7x7 grid (0-6)
    public int Column { get; set; }
    // determines what happens when this tile is clicked
    public TileType Type { get; set; }
    // whether this tile can currently be clicked by the player
    public bool IsInteractable { get; set; }
    // whether the tile's event has already occurred
    public bool InteractionFinished { get; set; }
    // name of the entity on this tile, used to look up the object from the map's lists
    public string EntityName { get; set; }
    // path to the image displayed on this tile in the grid
    public string ImagePath { get; set; }
    // for arrow tiles: the section index this arrow leads to. -1 means next map
    public string DestinationSectionId { get; set; }

    /// <summary>
    /// creates a new tile at the specified grid position
    /// </summary>
    public Tile(int row, int column, TileType type)
    {
        Row = row; Column = column; Type = type;
        IsInteractable = type != TileType.Empty;
        InteractionFinished = false;
        DestinationSectionId = null;
    }

    /// <summary>
    /// called by MainForm when this tile is clicked
    /// returns Empty if non-interactable or already completed
    /// </summary>
    public TileType LoadInteraction()
    {
        if (!IsInteractable || InteractionFinished) return TileType.Empty;
        return Type;
    }

    /// <summary>
    /// marks the tile's interaction as complete
    /// only applies to enemies, bosses, and items
    /// </summary>
    public void CompleteInteraction()
    {
        if (Type == TileType.Enemy || Type == TileType.Boss || Type == TileType.Item)
        {
            InteractionFinished = true; IsInteractable = false;
        }
    }
}
