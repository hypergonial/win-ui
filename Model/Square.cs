using System.Text.Json.Serialization;

namespace Model;


/// <summary>
/// Methods for Faction.
/// </summary>
public static class FactionExtensions
{
    public static Faction Opposite(this Faction faction)
    {
        return faction switch
        {
            Faction.BLACK => Faction.WHITE,
            Faction.WHITE => Faction.BLACK,
            _ => Faction.GAIA
        };
    }
}

/// <summary>
/// Represents the state of a single position on the board.
/// </summary>
public enum Faction
{
    /// <summary>
    /// The position is empty.
    /// </summary>
    GAIA,
    /// <summary>
    /// The position is occupied by a black piece.
    /// </summary>
    BLACK,
    /// <summary>
    /// The position is occupied by a white piece.
    /// </summary>
    WHITE
}



/// <summary>
/// Represents a single square of the board.
/// </summary>
public struct Square : IEquatable<Square>
{
    public Faction[] Inner { get; private set; }

    public Square()
    {
        Inner = new Faction[8];

        for (int i = 0; i < 8; i++)
        {
            Inner[i] = Faction.GAIA;
        }
    }

    [JsonConstructor]
    public Square(Faction[] inner)
    {
        Inner = inner;
    }

    public readonly Faction this[int i]
    {
        get
        {
            return Inner[i];
        }
        set
        {
            Inner[i] = value;
        }
    }

    /// <summary>
    /// Checks if the square has a mill for the given faction at the given position.
    /// This does not check for mills that are between squares.
    /// </summary>
    /// <param name="fact"></param>
    /// <returns></returns>
    internal readonly bool HasMill(Faction fact, int pos)
    {
        int prev = pos == 0 ? 7 : pos - 1;
        int next = pos == 7 ? 0 : pos + 1;

        // If it is a corner
        if (pos % 2 == 0)
        {
            return HasMill(fact, prev) || HasMill(fact, next);
        }
        else
        {
            return Inner[pos] == fact && Inner[next] == fact && Inner[prev] == fact;
        }
    }

    public override readonly bool Equals(object? obj)
    {
        return obj is Square square && Equals(square);
    }

    public readonly bool Equals(Square other)
    {
        return EqualityComparer<Faction[]>.Default.Equals(Inner, other.Inner);
    }

    public override readonly int GetHashCode()
    {
        return HashCode.Combine(Inner);
    }

    public static bool operator ==(Square left, Square right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Square left, Square right)
    {
        return !(left == right);
    }

    public override readonly string? ToString()
    {
        return '[' + string.Join(", ", Inner) + ']';
    }
}
