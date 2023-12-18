using System.Globalization;
using System.Windows.Data;
using System.Windows.Input;
using Model;

namespace WPFView.ViewModel;

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
    private TileState _state;

    /// <summary>
    /// The state of the tile
    /// </summary>
    public TileState State {
        get => _state;
        set {
            _state = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// The position of the tile on the board
    /// </summary>
    public Pos Pos { get; }

    /// <summary>
    /// An event dispatched by the tile when it is clicked.
    /// </summary>
    public event TileUpdateEventHandler? TileUpdate;

    private DelegateCommand? _tileUpdateCommand;
    /// <summary>
    /// The command to be executed by the view when the tile is clicked.
    /// </summary>
    public ICommand TileUpdateCommand
    {
        get => _tileUpdateCommand ??= new DelegateCommand(OnTileUpdateCommand, IsSelected);
    }

    public Tile(TileState state, Pos pos) : base()
    {
        State = state;
        Pos = pos;
    }

    /// <summary>
    /// Checks if the tile is selected.
    /// </summary>
    /// <param name="Tile"></param>
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
    /// <param name="Tile"></param>
    private void OnTileUpdateCommand(object? _)
    {
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


public class TileStateToImageConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var state = (TileState)value;
        return state switch
        {
            TileState.EMPTY => "/Assets/empty.png",
            TileState.EMPTY_SEL => "/Assets/empty_sel.png",
            TileState.WHITE => "/Assets/white.png",
            TileState.WHITE_SEL => "/Assets/white_sel.png",
            TileState.BLACK => "/Assets/black.png",
            TileState.BLACK_SEL => "/Assets/black_sel.png",
            _ => throw new NotImplementedException(),
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var image = (string)value;

        return image switch
        {
            "/Assets/empty.png" => TileState.EMPTY,
            "/Assets/empty_sel.png" => TileState.EMPTY_SEL,
            "/Assets/white.png" => TileState.WHITE,
            "/Assets/white_sel.png" => TileState.WHITE_SEL,
            "/Assets/black.png" => TileState.BLACK,
            "/Assets/black_sel.png" => TileState.BLACK_SEL,
            _ => throw new NotImplementedException(),
        };
    }
}
