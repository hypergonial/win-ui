using Model;
using Persistence;
using System.Diagnostics;
using System.Windows.Input;

namespace MAUIView.ViewModel;

public sealed class Board : Base
{
    private Game _game;
    private Pos? _movOrigin;
    private bool _isRefreshing = false;

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

    public ICommand NewCommand => _newCommand ??= new DelegateCommand(NewGame);

    private DelegateCommand? _saveCommand;

    public ICommand SaveCommand
    {
        get => _saveCommand ??= new DelegateCommand(_ => _ = SaveGame());
    }

    private DelegateCommand? _loadCommand;

    public ICommand LoadCommand
    {
        get => _loadCommand ??= new DelegateCommand(_ => _ = LoadGame());
    }

    private DelegateCommand? _passCommand;

    public ICommand PassCommand
    {
        get => _passCommand ??= new DelegateCommand(Pass);
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
    /// Saves the current game to a file
    /// </summary>
    public async Task SaveGame()
    {
        Page? mainPage = Application.Current?.MainPage;

        if (mainPage == null)
        {
            return;
        }

        string saveName = await mainPage.DisplayPromptAsync("Save Game", "Enter a name for the save file", "Save", "Cancel", "Save File Name");
        if (saveName == null)
        {
            return;
        }

        string[] saves = Serde.GetSaves();

        if (saveName == "")
        {
            await mainPage.DisplayAlert("Save Game", "Save file name cannot be empty", "OK");
            return;
        }

        if (saves.Contains(saveName))
        {
            if (!await mainPage.DisplayAlert("Save Game", "Save file already exists. Overwrite?", "Yes", "No"))
            {
                return;
            }
        }

        try
        {
            Serde.Save(_game, saveName);
        }
        catch (Exception e)
        {
            await mainPage.DisplayAlert("Save Game", $"Error saving game: {e.Message}", "OK");
            return;
        }
        

        await mainPage.DisplayAlert("Save Game", "Game saved successfully", "OK");

    }

    /// <summary>
    /// Loads a game from a save file
    /// </summary>
    public async Task LoadGame()
    {
        Page? mainPage = Application.Current?.MainPage;

        if (mainPage == null)
        {
            return;
        }

        string[] games = Serde.GetSaves();

        string name = await mainPage.DisplayActionSheet("Load Game", "Cancel", null, buttons : games);

        if (name == "Cancel")
        {
            return;
        }

        try
        {
            Game game = Serde.Load(name)!;
            ReplaceModel(game);
        }
        catch (Exception e)
        {
            await mainPage.DisplayAlert("Load Game", $"Error loading game: {e.Message}", "OK");
            return;
        }

        await mainPage.DisplayAlert("Load Game", "Game loaded successfully", "OK");
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
    /// <param name="newGame"></param>
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
        if (_isRefreshing)
        {
            return;
        }
        _isRefreshing = true;

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
        _isRefreshing = false;
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
    /// Should be called when the Pass button is pressed to skip a round
    /// </summary>
    private void Pass(object? _)
    {
        _movOrigin = null;
        _game.Pass();
    }

    /// <summary>
    /// Called when the File > New option is selected from the menu
    /// </summary>
    private void NewGame(object? _)
    {
        if (_game.State == GameState.OVER)
        {
            ReplaceModel(new());
        }
        else
        {
            ReplaceModel(new());
        }
    }
}
