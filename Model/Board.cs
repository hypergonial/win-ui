using System.Text;
using System.Text.Json.Serialization;

namespace Model;


/// <summary>
/// References a single position on the board.
/// </summary>
public readonly struct Pos : IEquatable<Pos>
{
    /// <summary>
    /// The square the index is in.
    /// The outer square is 0, the middle square is 1, and the Inner square is 2.
    /// </summary>
    public readonly int square;
    /// <summary>
    /// The index in the square.
    /// Indexing starts from the top left with 0 and goes clockwise until 7.
    /// </summary>
    public readonly int index;

    public Pos(int square, int index)
    {
        if (square < 0 || square > 2)
            throw new ArgumentOutOfRangeException(nameof(square), "Square must be between 0 and 2");

        if (index < 0 || index > 7)
            throw new ArgumentOutOfRangeException(nameof(index), "Index must be between 0 and 7");

        this.square = square;
        this.index = index;
    }

    public static bool operator ==(Pos a, Pos b)
    {
        return a.square == b.square && a.index == b.index;
    }

    public static bool operator !=(Pos a, Pos b)
    {
        return !(a == b);
    }

    public readonly override bool Equals(object? obj)
    {
        return obj is Pos pos && this == pos;
    }

    bool IEquatable<Pos>.Equals(Pos other)
    {
        return this == other;
    }

    public readonly override int GetHashCode()
    {
        return HashCode.Combine(square, index);
    }

    public override string ToString()
    {
        return $"Pos({square}, {index})";
    }
}

/// <summary>
/// Represents the game board.
/// </summary>
public sealed class Board
{

    public Square[] Inner { get; private set; }

    public Board()
    {
        Inner = new Square[3];

        for (int i = 0; i < 3; i++)
        {
            Inner[i] = new Square();
        }
    }

    [JsonConstructor]
    public Board(Square[] inner)
    {
        Inner = inner;
    }

    public Faction this[Pos pos]
    {
        get => Inner[pos.square][pos.index];
    }

    /// <summary>
    /// Returns all positions on the board.
    /// Used by procedures to check for specific conditions.
    /// </summary>
    /// <returns></returns>
    public static Pos[] AllPos
    {
        get
        {
            Pos[] ret = new Pos[24];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    ret[i * 8 + j] = new Pos(i, j);
                }
            }
            return ret;
        }
    }

    /// <summary>
    /// Find all adjacent positions to 'pos'.
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    internal static Pos[] FindAdjacent(Pos pos)
    {
        Pos next = new(pos.square, pos.index == 7 ? 0 : pos.index + 1);
        Pos prev = new(pos.square, pos.index == 0 ? 7 : pos.index - 1);

        if (pos.index % 2 == 0)
        {
            return new Pos[] { next, prev };
        }
        List<Pos> list = new(4)
        {
            next,
            prev
        };

        // If it is not the outer square
        if (pos.square != 0)
        {
            list.Add(new(pos.square - 1, pos.index));
        }
        // If it is not the Inner square
        if (pos.square != 2)
        {
            list.Add(new(pos.square + 1, pos.index));
        }

        return list.ToArray();
    }

    /// <summary>
    /// Determines if a piece can be moved from 'from' to 'to'.
    /// </summary>
    /// <param name="state"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns>bool</returns>
    public bool CanMoveTo(Faction state, Pos from, Pos to)
    {
        return this[to] == Faction.GAIA && this[from] == state && FindAdjacent(from).Contains(to);
    }

    /// <summary>
    /// Find all positions that are occupied by 'fact'.
    /// </summary>
    /// <param name="fact"></param>
    /// <returns></returns>
    public Pos[] Find(Faction fact)
    {
        return AllPos.Where(p => this[p] == fact).ToArray();
    }

    /// <summary>
    /// Find all positions that are occupied by 'fact' and have an adjacent GAIA.
    /// </summary>
    /// <param name="fact"></param>
    /// <returns></returns>
    public Pos[] FindMoveTargets(Faction fact)
    {
        return AllPos.Where(p => this[p] == fact && FindAdjacent(p).Any(p => this[p] == Faction.GAIA)).ToArray();
    }

    /// <summary>
    /// Find all positions that can be removed by 'fact'.
    /// </summary>
    /// <param name="fact"></param>
    /// <returns></returns>
    public Pos[] FindRemovable(Faction fact)
    {
        return AllPos.Where(p => CanRemove(fact, p)).ToArray();
    }

    /// <summary>
    /// Find all valid moves for a piece at 'from'.
    /// </summary>
    /// <param name="from"></param>
    /// <returns></returns>
    public Pos[] FindValidMoves(Pos from)
    {
        return FindAdjacent(from).Where(p => this[p] == Faction.GAIA).ToArray();
    }

    /// <summary>
    /// Determines if a piece can be removed from 'from'.
    /// </summary>
    /// <param name="fact"></param>
    /// <param name="from"></param>
    /// <returns></returns>
    public bool CanRemove(Faction fact, Pos from)
    {
        if (AllMills(fact.Opposite()))
        {
            return this[from] == fact.Opposite();
        }

        return this[from] == fact.Opposite() && !HasMill(fact.Opposite(), from);
    }

    /// <summary>
    /// Tries to place a piece of 'fact' at 'to'.
    /// </summary>
    /// <param name="fact"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    public bool Place(Faction fact, Pos to)
    {
        if (this[to] != Faction.GAIA)
        {
            throw new InvalidOperationException("Cannot place a piece at this position.");
        }

        Inner[to.square][to.index] = fact;

        return HasMill(fact, to);
    }

    /// <summary>
    /// Determines if a faction only has mills on the board.
    /// </summary>
    /// <param name="fact"></param>
    /// <returns></returns>
    private bool AllMills(Faction fact)
    {
        return AllPos.Where(p => this[p] == fact).All(p => HasMill(fact, p));
    }

    /// <summary>
    /// Tries to remove a piece of 'fact''s opponent 'from' position.
    /// </summary>
    /// <param name="fact"></param>
    /// <param name="from"></param>
    /// <returns></returns>
    internal void Remove(Faction fact, Pos from)
    {
        if (!CanRemove(fact, from))
        {
            throw new InvalidOperationException("Cannot remove a piece at this position.");
        }

        Inner[from.square][from.index] = Faction.GAIA;
    }

    /// <summary>
    /// Moves a piece from 'from' to 'to' if it is valid.
    /// Returns Ok(bool) if the move was successful, with the bool being true if a mill was formed.
    /// Returns Err(string) if the move was invalid, with the string being the reason.
    /// </summary>
    /// <param name="state"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns>Result<bool, string></returns>
    internal bool Move(Faction state, Pos from, Pos to)
    {

        if (!CanMoveTo(state, from, to))
        {
            throw new InvalidOperationException("Cannot move a piece to this position.");
        }

        Inner[from.square][from.index] = Faction.GAIA;
        Inner[to.square][to.index] = state;

        return HasMill(state, to);
    }

    /// <summary>
    /// Determines if a given faction has a mill in 'pos'.
    /// </summary>
    /// <param name="fact"></param>
    /// <returns>bool</returns>
    private bool HasMill(Faction fact, Pos pos)
    {
        if (Inner[pos.square].HasMill(fact, pos.index))
        {
            return true;
        }

        // If it is not a corner
        if (pos.index % 2 == 1)
        {
            return Inner[0][pos.index] == fact && Inner[1][pos.index] == fact && Inner[2][pos.index] == fact;
        }

        return false;
    }

    /// <summary>
    /// Tally the number of pieces a faction has on the board.
    /// </summary>
    /// <param name="fact"></param>
    /// <returns></returns>
    internal int Tally(Faction fact)
    {
        return AllPos.Where(pos => this[pos] == fact).Count();
    }

    public override string ToString()
    {
        StringBuilder sb = new();

        for (int i = 0; i < 3; i++)
        {
            sb.Append(Inner[i].ToString());
            sb.Append('\n');
        }

        return sb.ToString();
    }
}