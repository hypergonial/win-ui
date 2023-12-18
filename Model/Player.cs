namespace Model;

public class Player
{

    private int storedPieces;

    /// <summary>
    /// If not 0, the player has to place this many pieces before moving.
    /// </summary>
    public int StoredPieces
    {
        get => storedPieces;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(StoredPieces), "cannot be negative.");
            }
            storedPieces = value;
        }
    }
    /// <summary>
    /// If true, the player should be forced to remove a piece.
    /// </summary>
    public bool CanRemove { get; set; }

    public Player()
    {
        StoredPieces = 9;
        CanRemove = false;
    }

    public override string ToString()
    {
        return $"StoredPieces: {StoredPieces}, CanRemove: {CanRemove}";
    }
}
