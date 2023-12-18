namespace Model.Test;

using Persistence;

public class SerdeTests {
    [Fact]
    public void Serialize_Empty_ReturnsValidJson() {
        Game game = new();

        string json = Serde.Serialize(game);

        Assert.NotEmpty(json);
        Assert.Equal("{\"Board\":{\"Inner\":[{\"Inner\":[0,0,0,0,0,0,0,0]},{\"Inner\":[0,0,0,0,0,0,0,0]},{\"Inner\":[0,0,0,0,0,0,0,0]}]},\"ActiveFaction\":2,\"State\":0,\"WinState\":0,\"Black\":{\"StoredPieces\":9,\"CanRemove\":false},\"White\":{\"StoredPieces\":9,\"CanRemove\":false}}", json);
    }

    [Fact]
    public void Deserialize_Empty_ReturnsValidGame()
    {
        string json = "{\"Board\":{\"Inner\":[{\"Inner\":[0,0,0,0,0,0,0,0]},{\"Inner\":[0,0,0,0,0,0,0,0]},{\"Inner\":[0,0,0,0,0,0,0,0]}]},\"ActiveFaction\":2,\"State\":0,\"WinState\":0,\"Black\":{\"StoredPieces\":9,\"CanRemove\":false},\"White\":{\"StoredPieces\":9,\"CanRemove\":false}}";

        Game? game = Serde.Deserialize(json);

        Assert.NotNull(game);
        Assert.Equal(Faction.WHITE, game.ActiveFaction);
        Assert.Equal(GameState.PLACEMENT, game.State);
        Assert.Equal(WinState.NONE, game.WinState);
        Assert.Equal(9, game.Black.StoredPieces);
        Assert.Equal(9, game.White.StoredPieces);
        Assert.False(game.Black.CanRemove);
        Assert.False(game.White.CanRemove);
        Assert.NotNull(game.Board);
        Assert.NotNull(game.Board.Inner);
        Assert.Equal(3, game.Board.Inner.Count());
        Assert.NotNull(game.Board.Inner[0].Inner);
        Assert.Equal(8, game.Board.Inner[0].Inner.Count());
        Assert.Equal(Faction.GAIA, game.Board.Inner[0].Inner[0]);
    }

    [Fact]
    public void Serialize_State_ReturnsValidJson()
    {
        Board board = new(
            new Square[]{ 
                new Square(new Faction[] { Faction.WHITE, Faction.BLACK, Faction.BLACK, Faction.GAIA, Faction.BLACK, Faction.WHITE, Faction.WHITE, Faction.WHITE }),
                new Square(new Faction[] { Faction.GAIA, Faction.BLACK, Faction.GAIA, Faction.WHITE, Faction.GAIA, Faction.BLACK, Faction.BLACK, Faction.WHITE }),
                new Square(new Faction[] { Faction.GAIA, Faction.BLACK, Faction.GAIA, Faction.GAIA, Faction.WHITE, Faction.GAIA, Faction.GAIA, Faction.WHITE })
            }
        );
        Player player = new()
        {
            StoredPieces = 0,
            CanRemove = false
        };

        Game game = new(Faction.BLACK, GameState.MOVEMENT, WinState.NONE, board, player, player);

        string json = Serde.Serialize(game);

        Assert.Equal("{\"Board\":{\"Inner\":[{\"Inner\":[2,1,1,0,1,2,2,2]},{\"Inner\":[0,1,0,2,0,1,1,2]},{\"Inner\":[0,1,0,0,2,0,0,2]}]},\"ActiveFaction\":1,\"State\":1,\"WinState\":0,\"Black\":{\"StoredPieces\":0,\"CanRemove\":false},\"White\":{\"StoredPieces\":0,\"CanRemove\":false}}", json);
    }

    [Fact]
    public void Deserialize_State_ReturnsValidGame()
    {
        string json = "{\"Board\":{\"Inner\":[{\"Inner\":[2,1,1,0,1,2,2,2]},{\"Inner\":[0,1,0,2,0,1,1,2]},{\"Inner\":[0,1,0,0,2,0,0,2]}]},\"ActiveFaction\":1,\"State\":1,\"WinState\":0,\"Black\":{\"StoredPieces\":0,\"CanRemove\":false},\"White\":{\"StoredPieces\":0,\"CanRemove\":false}}";

        Game? game = Serde.Deserialize(json);

        Assert.NotNull(game);
        Assert.Equal(Faction.BLACK, game.ActiveFaction);
        Assert.Equal(GameState.MOVEMENT, game.State);
        Assert.Equal(WinState.NONE, game.WinState);
        Assert.Equal(0, game.Black.StoredPieces);
        Assert.Equal(0, game.White.StoredPieces);
        Assert.False(game.Black.CanRemove);
        Assert.False(game.White.CanRemove);
        Assert.NotNull(game.Board);
        Assert.NotNull(game.Board.Inner);
        Assert.Equal(3, game.Board.Inner.Count());
        Assert.NotNull(game.Board.Inner[0].Inner);
        Assert.Equal(8, game.Board.Inner[0].Inner.Count());
        Assert.Equal(Faction.WHITE, game.Board.Inner[0].Inner[0]);
    }
}
