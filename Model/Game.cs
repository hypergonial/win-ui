using System.Text.Json.Serialization;

namespace Model;

/// <summary>
/// Represents the state of a game session.
/// </summary>
public enum GameState
{
    /// <summary>
    /// The game is in the placement phase.
    /// </summary>
    PLACEMENT,
    /// <summary>
    /// The game is in the movement phase.
    /// </summary>
    MOVEMENT,
    /// <summary>
    /// The game is in the removal phase.
    /// </summary>
    REMOVAL,
    /// <summary>
    /// The game is over.
    /// </summary>
    OVER
}

/// <summary>
/// Represents the winner of a game.
/// </summary>
public enum WinState
{
    /// <summary>
    /// No winner has been decided yet.
    /// </summary>
    NONE,
    /// <summary>
    /// The black player has won.
    /// </summary>
    BLACK,
    /// <summary>
    /// The white player has won.
    /// </summary>
    WHITE,
    /// <summary>
    /// The game is a draw.
    /// </summary>
    DRAW
}

public delegate void GameUpdateDelegate();

public sealed class Game
{
    public event GameUpdateDelegate? GameUpdate;

    /// <summary>
    /// The game board.
    /// </summary>
    public Board Board { get; private set; }

    /// <summary>
    /// The faction whose turn it is.
    /// </summary>
    public Faction ActiveFaction { get; private set; }

    /// <summary>
    /// The current state of the game.
    /// </summary>
    public GameState State { get; private set; }

    public WinState WinState { get; private set; }

    /// <summary>
    /// The player playing as black.
    /// </summary>
    public Player Black { get; private set; }

    /// <summary>
    /// The player playing as white.
    /// </summary>
    public Player White { get; private set; }

    /// <summary>
    /// The player whose turn it is.
    /// </summary>
    /// <param name="fact"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    [JsonIgnore]
    public Player ActivePlayer => ActiveFaction switch
    {
        Faction.BLACK => Black,
        Faction.WHITE => White,
        _ => throw new ArgumentOutOfRangeException(nameof(ActiveFaction), "Faction must be either black or white.")
    };

    public Game()
    {
        ActiveFaction = Faction.WHITE;
        State = GameState.PLACEMENT;
        Board = new();
        Black = new();
        White = new();
    }

    [JsonConstructor]
    public Game(Faction activeFaction, GameState state, WinState winState, Board board, Player black, Player white)
    {
        ActiveFaction = activeFaction;
        State = state;
        WinState = winState;
        Board = board;
        Black = black;
        White = white;
    }

    /// <summary>
    /// Set currently active player to be the winner.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    private void SetCurrentToWinner()
    {
        WinState = ActiveFaction switch
        {
            Faction.BLACK => WinState.BLACK,
            Faction.WHITE => WinState.WHITE,
            _ => throw new ArgumentOutOfRangeException(nameof(ActiveFaction), "Faction must be either black or white.")
        };
    }

    /// <summary>
    /// Changes the game state to the next state.
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    private void UpdateGameState()
    {
        if (State == GameState.OVER)
        {
            return;
        }

        if (ActivePlayer.CanRemove)
        {
            State = GameState.REMOVAL;
        }
        else if (ActivePlayer.StoredPieces > 0)
        {
            State = GameState.PLACEMENT;
        }
        else
        {
            // If the active player is boxed in, the game is over.
            if (Board.FindMoveTargets(ActiveFaction).Length == 0)
            {
                State = GameState.OVER;
                SetCurrentToWinner();
            }
            else
            {
                // Note: Tallying is only done on removals.
                State = GameState.MOVEMENT;
            }
            
        }
        GameUpdate?.Invoke();
    }

    /// <summary>
    /// Places a piece for the active player at the given position.
    /// </summary>
    /// <param name="pos"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public void Place(Pos pos)
    {
        if (State != GameState.PLACEMENT || ActivePlayer.StoredPieces <= 0)
        {
            throw new InvalidOperationException("Cannot place a piece at this time.");
        }

        ActivePlayer.CanRemove = Board.Place(ActiveFaction, pos);
        ActivePlayer.StoredPieces -= 1;
        if (!ActivePlayer.CanRemove)
        {
            ActiveFaction = ActiveFaction.Opposite();
        }
        UpdateGameState();
    }

    /// <summary>
    /// Moves a piece from 'from' to 'to' for the active player.
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public void Move(Pos from, Pos to)
    {
        if (State != GameState.MOVEMENT)
        {
            throw new InvalidOperationException("Cannot move a piece at this time.");
        }

        ActivePlayer.CanRemove = Board.Move(ActiveFaction, from, to);

        if (!ActivePlayer.CanRemove)
        {
            ActiveFaction = ActiveFaction.Opposite();
        }
        UpdateGameState();
    }

    /// <summary>
    /// Removes a piece from the given position for the opponent of the active player.
    /// </summary>
    /// <param name="pos"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public void Remove(Pos pos)
    {
        if (State != GameState.REMOVAL || !ActivePlayer.CanRemove)
        {
            throw new InvalidOperationException("Cannot remove a piece at this time.");
        }

        Board.Remove(ActiveFaction, pos);
        ActivePlayer.CanRemove = false;

        if (ActivePlayer.StoredPieces <= 0 && Board.Tally(ActiveFaction.Opposite()) < 3)
        {
            State = GameState.OVER;
            SetCurrentToWinner();
            GameUpdate?.Invoke();
            return;
        }

        ActiveFaction = ActiveFaction.Opposite();
        UpdateGameState();
    }

    /// <summary>
    /// Hand over control to the other player without making an action.
    /// </summary>
    public void Pass()
    {
        ActiveFaction = ActiveFaction.Opposite();
        UpdateGameState();
    }

    public override string ToString()
    {
        return $"ActiveFaction: {ActiveFaction}, State: {State}, WinState: {WinState}, Black: {Black}, White: {White}\nBoard:\n{Board}";
    }
}
