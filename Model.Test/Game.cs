namespace Model.Test;

public class GameTests
{
    [Fact]
    public void Game_InitializesCorrectly()
    {
        // Arrange
        var game = new Game();

        // Assert
        Assert.Equal(Faction.WHITE, game.ActiveFaction);
        Assert.Equal(GameState.PLACEMENT, game.State);
        Assert.NotNull(game.Board);
        Assert.NotNull(game.Black);
        Assert.NotNull(game.White);
    }

    [Fact]
    public void Game_ActivePlayer_ReturnsCorrectPlayer()
    {
        // Arrange
        var game = new Game();

        // Act
        var activePlayer = game.ActivePlayer;

        // Assert
        Assert.Equal(game.White, activePlayer);
    }

    [Fact]
    public void Place_ThrowsException_WhenStateIsNotPlacement()
    {
        // Arrange
        var game = new Game(Faction.BLACK, GameState.MOVEMENT, WinState.NONE, new(), new(), new());
        game.ActivePlayer.StoredPieces = 1;

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => game.Place(new Pos(0, 0)));
    }

    [Fact]
    public void Place_ThrowsException_WhenPositionIsOccupied()
    {
        // Arrange
        var game = new Game(Faction.BLACK, GameState.PLACEMENT, WinState.NONE, new(), new(), new());
        game.Board.Place(Faction.BLACK, new Pos(0, 0));

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => game.Place(new Pos(0, 0)));
    }

    [Fact]
    public void Place_ValidStateAfterMill()
    {
        var game = new Game(Faction.BLACK, GameState.PLACEMENT, WinState.NONE, new(), new(), new());
        game.Black.StoredPieces = 1;
        game.White.StoredPieces = 0;

        game.Board.Place(Faction.WHITE, new Pos(2, 4));
        game.Board.Place(Faction.WHITE, new Pos(2, 5));
        game.Board.Place(Faction.WHITE, new Pos(1, 5));
        game.Board.Place(Faction.BLACK, new Pos(0, 1));
        game.Board.Place(Faction.BLACK, new Pos(0, 2));

        game.Place(new Pos(0, 0));

        Assert.Equal(GameState.REMOVAL, game.State);
        Assert.Equal(Faction.BLACK, game.ActiveFaction);
        Assert.Equal(0, game.Black.StoredPieces);
    }

    [Fact]
    public void Place_ValidStateAfterPlacement()
    {
        var game = new Game(Faction.BLACK, GameState.PLACEMENT, WinState.NONE, new(), new(), new());
        game.Black.StoredPieces = 1;
        game.White.StoredPieces = 0;

        game.Board.Place(Faction.WHITE, new Pos(2, 4));
        game.Board.Place(Faction.WHITE, new Pos(2, 5));
        game.Board.Place(Faction.WHITE, new Pos(1, 5));
        game.Board.Place(Faction.BLACK, new Pos(0, 1));
        game.Board.Place(Faction.BLACK, new Pos(0, 3));

        game.Place(new Pos(0, 0));

        Assert.Equal(GameState.MOVEMENT, game.State);
        Assert.Equal(Faction.WHITE, game.ActiveFaction);
        Assert.Equal(0, game.Black.StoredPieces);
    }

    [Fact]
    public void Place_ThrowsException_WhenActivePlayerHasNoStoredPieces()
    {
        // Arrange
        var game = new Game(Faction.BLACK, GameState.PLACEMENT, WinState.NONE, new(), new(), new());
        game.ActivePlayer.StoredPieces = 0;

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => game.Place(new Pos(0, 0)));
    }

    [Fact]
    public void Move_ThrowsException_WhenStateIsNotMovement()
    {
        // Arrange
        var game = new Game(Faction.BLACK, GameState.PLACEMENT, WinState.NONE, new(), new(), new());

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => game.Move(new Pos(0, 0), new Pos(1, 1)));
    }

    [Fact]
    public void Remove_ThrowsException_WhenStateIsNotRemoval()
    {
        // Arrange
        var game = new Game(Faction.BLACK, GameState.PLACEMENT, WinState.NONE, new(), new(), new());

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => game.Remove(new Pos(0, 0)));
    }

    [Fact]
    public void Remove_ThrowsException_WhenActivePlayerCannotRemove()
    {
        // Arrange
        var game = new Game(Faction.BLACK, GameState.REMOVAL, WinState.NONE, new(), new(), new());
        game.ActivePlayer.CanRemove = false;

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => game.Remove(new Pos(0, 0)));
    }

    [Fact]
    public void Pass_ChangesActiveFaction()
    {
        // Arrange
        var game = new Game();
        var initialFaction = game.ActiveFaction;

        // Act
        game.Pass();

        // Assert
        Assert.NotEqual(initialFaction, game.ActiveFaction);

        game.Pass();

        Assert.Equal(initialFaction, game.ActiveFaction);
    }
}
