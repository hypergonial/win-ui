using System.Windows.Input;
using Model;

namespace MAUIView.ViewModel;

/// <summary>
/// Represents the state of a tile on the board.
/// </summary>
public enum TileState
{
    EMPTY,
    EMPTY_SEL,
    WHITE,
    WHITE_SEL,
    BLACK,
    BLACK_SEL
}

public delegate void TileUpdateEventHandler(Tile tile);

/// <summary>
/// Represents a single tile on the mill board.
/// </summary>
public sealed class Tile : Base
{
    public Tile(TileState state, Pos pos)
    {
        this.state = state;
        this.pos = pos;
    }

    private readonly Pos pos;

    private TileState state;

    /// <summary>
    /// The state of the tile
    /// </summary>
    public TileState State
    {
        get => state;
        set
        {
            state = value;
            OnPropertyChanged();

            Asset = state switch
            {
                TileState.EMPTY => "empty.png",
                TileState.EMPTY_SEL => "empty_sel.png",
                TileState.WHITE => "white.png",
                TileState.WHITE_SEL => "white_sel.png",
                TileState.BLACK => "black.png",
                TileState.BLACK_SEL => "black_sel.png",
                _ => throw new NotImplementedException(),
            };
        }
    }

    private string _asset = "empty.png";

    public string Asset
    {
        get => _asset;
        private set { _asset = value; OnPropertyChanged(); }
    }

    /// <summary>
    /// The position of the tile on the board
    /// </summary>
    public Pos Pos { get => pos; }

    /// <summary>
    /// An event dispatched by the tile when it is clicked.
    /// </summary>
    public event TileUpdateEventHandler? TileUpdate;

    private DelegateCommand? _tileUpdateCommand;
    /// <summary>
    /// The command to be executed by the view when the tile is clicked.
    /// </summary>
    public ICommand TileUpdateCommand => _tileUpdateCommand ??= new DelegateCommand(OnTileUpdateCommand, IsSelected);

    /// <summary>
    /// Checks if the tile is selected.
    /// </summary>
    /// <returns></returns>
    private bool IsSelected(object? _)
    {
        return State switch
        {
            TileState.EMPTY_SEL or TileState.WHITE_SEL or TileState.BLACK_SEL => true,
            _ => false,
        };
    }

    /// <summary>
    /// Dispatches the TileUpdate event.
    /// </summary>
    private void OnTileUpdateCommand(object? _)
    {
        if (!IsSelected(_))
            return;

        TileUpdate?.Invoke(this);
    }

    /// <summary>
    /// Select the tile on the board.
    /// This allows it to be clicked by the user, and highlights it.
    /// </summary>
    public void SelectTile()
    {
        // Change state to selected
        State = State switch
        {
            TileState.EMPTY => TileState.EMPTY_SEL,
            TileState.WHITE => TileState.WHITE_SEL,
            TileState.BLACK => TileState.BLACK_SEL,
            _ => State,
        };
    }

    /// <summary>
    /// Deselect the tile on the board.
    /// This prevents it from being clicked by the user.
    /// </summary>
    public void DeselectTile()
    {
        State = State switch
        {
            TileState.EMPTY_SEL => TileState.EMPTY,
            TileState.WHITE_SEL => TileState.WHITE,
            TileState.BLACK_SEL => TileState.BLACK,
            _ => State,
        };
    }
}
