using Model;

namespace View;

public sealed partial class BoardForm : Form
{
    private readonly Tile[] tiles;
    internal Game game;
    private Pos? movOrigin;
    public BoardForm()
    {
        InitializeComponent();
        Tile[] tiles = {
            tile00, tile01, tile02, tile03, tile04, tile05, tile06, tile07,
            tile10, tile11, tile12, tile13, tile14, tile15, tile16, tile17,
            tile20, tile21, tile22, tile23, tile24, tile25, tile26, tile27
        };
        this.tiles = tiles;
        foreach (Tile tile in tiles)
        {
            tile.TileUpdate += TileInput;
        }
        game = new();
        game.GameUpdate += RefreshBoard;
        RefreshBoard();
    }

    /// <summary>
    /// Replaces the current game model with the provided one
    /// </summary>
    /// <param name="game"></param>
    public void ReplaceModel(Game newGame)
    {
        game.GameUpdate -= RefreshBoard;
        game = newGame;
        newGame.GameUpdate += RefreshBoard;
        RefreshBoard();
    }

    /// <summary>
    /// Returns a string containing the current state of the game model
    /// </summary>
    /// <returns></returns>
    public string GetLabel()
    {
        string str = $"Current Player: {game.ActiveFaction}\nStored Pieces: {game.ActivePlayer.StoredPieces}\nPlaced Pieces: {game.Board.Find(game.ActiveFaction).Length}\nGame State: {game.State}";
        if (game.State == GameState.OVER)
        {
            str += $"\nWinner: {game.WinState}";
        }
        return str;
    }

    /// <summary>
    /// Refreshes the board to reflect the current state of the game model
    /// </summary>
    public void RefreshBoard()
    {
        currentPlayerIndicator.State = game.ActiveFaction == Faction.BLACK ? TileState.BLACK : TileState.WHITE;
        currentPlayerInfo.Text = GetLabel();
        Pos[] sel;

        switch (game.State)
        {
            case GameState.PLACEMENT:
                sel = game.Board.Find(Faction.GAIA);
                break;
            case GameState.MOVEMENT:
                if (movOrigin != null)
                {
                    sel = game.Board.FindValidMoves(movOrigin.Value);
                }
                else
                {
                    sel = game.Board.FindMoveTargets(game.ActiveFaction);
                }
                break;
            case GameState.REMOVAL:
                sel = game.Board.FindRemovable(game.ActiveFaction);
                break;
            default:
                sel = Array.Empty<Pos>();
                break;
        }

        foreach (Tile tile in tiles)
        {
            Faction fact = game.Board[tile.Pos];
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

        if (game.WinState != WinState.NONE)
        {
            MessageBox.Show($"Game over! {game.WinState} wins!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    /// <summary>
    /// Helper function to execute a move
    /// </summary>
    /// <param name="pos"></param>
    private void HandleMove(Pos pos)
    {
        if (movOrigin != null)
        {
            var mov = movOrigin.Value;
            movOrigin = null;
            game.Move(mov, pos);
        }
        else
        {
            movOrigin = pos;
            RefreshBoard();
        }
    }

    /// <summary>
    /// Called when a tile is clicked anywhere on the board
    /// </summary>
    /// <param name="tile"></param>
    private void TileInput(Tile tile)
    {
        try
        {
            switch (game.State)
            {
                case GameState.PLACEMENT:
                    game.Place(tile.Pos);
                    break;
                case GameState.MOVEMENT:
                    HandleMove(tile.Pos);
                    break;
                case GameState.REMOVAL:
                    game.Remove(tile.Pos);
                    break;
            };
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    /// <summary>
    /// Called when the Quit option is selected from the menu
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Quit(object sender, EventArgs e)
    {
        Application.Exit();
    }

    /// <summary>
    /// Called when the About option is selected from the menu
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void About(object sender, EventArgs e)
    {
        AboutForm about = new()
        {
            parent = this
        };
        about.ShowDialog();
    }

    /// <summary>
    /// Called when the File > New option is selected from the menu
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void NewGame(object sender, EventArgs e)
    {
        if (game.State == GameState.OVER)
        {
            game = new();
            game.GameUpdate += RefreshBoard;
            RefreshBoard();
        }
        else
        {
            DialogResult result = MessageBox.Show("Are you sure you want to start a new game?\nAny unsaved progress will be lost.", "New Game", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                ReplaceModel(new());
        }
    }

    /// <summary>
    /// Handle movement cancellation on escape key press
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="keyData"></param>
    /// <returns></returns>
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == Keys.Escape && movOrigin != null)
        {
            movOrigin = null;
            RefreshBoard();
            return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }

    /// <summary>
    /// Called when the Pass button is pressed to skip a round
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Pass(object sender, EventArgs e)
    {
        movOrigin = null;
        game.Pass();
    }

    private void SaveGame(object sender, EventArgs e)
    {
        SaveDialog saveDialog = new()
        {
            parent = this
        };
        saveDialog.ShowDialog();
    }

    private void LoadGame(object sender, EventArgs e)
    {
        LoadDialog loadDialog = new()
        {
            parent = this
        };
        try
        {
            loadDialog.ShowDialog();
        } // The form may close before the dialog is shown, causing an ObjectDisposedException
        catch (ObjectDisposedException) { }

    }
}
