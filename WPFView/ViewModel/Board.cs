using Model;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace WPFView.ViewModel;

public sealed class Board : Base
{
    private Game _game;
    private Pos? _movOrigin;
    public Tile[] Tiles { get; }

    private string _gameInfo = "";
    public string GameInfo
    {
        get => _gameInfo; set
        {
            _gameInfo = value;
            OnPropertyChanged();
        }
    }

    private DelegateCommand? _newCommand;

    public ICommand NewCommand
    {
        get => _newCommand ??= new DelegateCommand(NewGame);
    }

    private DelegateCommand? _quitCommand;

    public ICommand QuitCommand
    {
        get => _quitCommand ??= new DelegateCommand(QuitGame);
    }

    private DelegateCommand? _saveCommand;

    public ICommand SaveCommand
    {
        get => _saveCommand ??= new DelegateCommand(_ => new View.SaveDialogV2(_game).ShowDialog());
    }

    private DelegateCommand? _loadCommand;

    public ICommand LoadCommand
    {
        get => _loadCommand ??= new DelegateCommand(_ => new View.LoadDialogV2(this).ShowDialog());
    }


    public Board()
    {
        _game = new Game();
        _game.GameUpdate += RefreshBoard;

        Tiles = new Tile[24];

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Tile tile = new(TileState.EMPTY, new Pos(i, j));
                tile.TileUpdate += OnTileUpdate;
                Tiles[i * 8 + j] = tile;
            }
        }

        RefreshBoard();
    }

    /// <summary>
    /// Returns a string containing the current state of the game model
    /// </summary>
    /// <returns></returns>
    public void RefreshGameInfo()
    {
        string str = $"Current Player: {_game.ActiveFaction}\nStored Pieces: {_game.ActivePlayer.StoredPieces}\nPlaced Pieces: {_game.Board.Find(_game.ActiveFaction).Length}\nGame State: {_game.State}";
        if (_game.State == GameState.OVER)
        {
            str += $"\nWinner: {_game.WinState}";
        }
        GameInfo = str;
    }

    /// <summary>
    /// Replaces the current game model with the provided one
    /// </summary>
    /// <param name="game"></param>
    public void ReplaceModel(Game newGame)
    {
        _game.GameUpdate -= RefreshBoard;
        _game = newGame;
        newGame.GameUpdate += RefreshBoard;
        RefreshBoard();
    }

    /// <summary>
    /// Refreshes the board to reflect the current state of the game model
    /// </summary>
    public void RefreshBoard()
    {
        Pos[] sel;

        switch (_game.State)
        {
            case GameState.PLACEMENT:
                sel = _game.Board.Find(Faction.GAIA);
                break;
            case GameState.MOVEMENT:
                if (_movOrigin != null)
                {
                    sel = _game.Board.FindValidMoves(_movOrigin.Value);
                }
                else
                {
                    sel = _game.Board.FindMoveTargets(_game.ActiveFaction);
                }
                break;
            case GameState.REMOVAL:
                sel = _game.Board.FindRemovable(_game.ActiveFaction);
                break;
            default:
                sel = Array.Empty<Pos>();
                break;
        }

        foreach (Tile tile in Tiles)
        {
            Faction fact = _game.Board[tile.Pos];
            tile.State = fact switch
            {
                Faction.BLACK => TileState.BLACK,
                Faction.WHITE => TileState.WHITE,
                _ => TileState.EMPTY
            };

            if (sel.Contains(tile.Pos))
            {
                tile.SelectTile();
            }
            else
            {
                tile.DeselectTile();
            }
        }

        RefreshGameInfo();

        if (_game.WinState != WinState.NONE)
        {
            MessageBox.Show($"Game over! {_game.WinState} wins!", "Game Over");
        }
    }

    /// <summary>
    /// Helper function to execute a move
    /// </summary>
    /// <param name="pos"></param>
    private void HandleMove(Pos pos)
    {
        if (_movOrigin != null)
        {
            var mov = _movOrigin.Value;
            _movOrigin = null;
            _game.Move(mov, pos);
        }
        else
        {
            _movOrigin = pos;
            RefreshBoard();
        }
    }

    /// <summary>
    /// Called when a tile is clicked.
    /// </summary>
    /// <param name="tile"></param>
    private void OnTileUpdate(Tile tile)
    {
        try
        {
            switch (_game.State)
            {
                case GameState.PLACEMENT:
                    _game.Place(tile.Pos);
                    break;
                case GameState.MOVEMENT:
                    HandleMove(tile.Pos);
                    break;
                case GameState.REMOVAL:
                    _game.Remove(tile.Pos);
                    break;
            }
        }
        catch (InvalidOperationException e)
        {
            Debug.WriteLine(e.Message);
        }
    }

    /// <summary>
    /// Should be called when a key is pressed.
    /// Cancels a move if the escape key is pressed.
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="keyData"></param>
    /// <returns></returns>
    public void ProcessKeyInput(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Escape && _movOrigin != null)
        {
            _movOrigin = null;
            RefreshBoard();
            e.Handled = true;
        }
    }

    /// <summary>
    /// Should be called when the Pass button is pressed to skip a round
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Pass(object sender, EventArgs e)
    {
        _movOrigin = null;
        _game.Pass();
    }

    /// <summary>
    /// Called when the File > New option is selected from the menu
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void NewGame(object? _)
    {
        if (_game.State == GameState.OVER)
        {
            ReplaceModel(new());
        }
        else
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to start a new game?\nAny unsaved progress will be lost.", "New Game", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
                ReplaceModel(new());
        }
    }

    private void QuitGame(object? _)
    {
        MessageBoxResult result = MessageBox.Show("Are you sure you want to quit?\nAny unsaved progress will be lost.", "Quit", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        if (result == MessageBoxResult.Yes)
            Application.Current.Shutdown();
    }
}
