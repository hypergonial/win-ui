namespace Model.Test;

public class BoardTests
{
    [Fact]
    public void CanMoveTo_ReturnsTrue_WhenMovingToAdjacentGAIA()
    {
        var board = new Board();
        board.Inner[0][0] = Faction.BLACK;
        board.Inner[0][1] = Faction.GAIA;

        var canMoveTo = board.CanMoveTo(Faction.BLACK, new Pos(0, 0), new Pos(0, 1));

        Assert.True(canMoveTo);
    }

    [Fact]
    public void CanMoveTo_ReturnsFalse_WhenMovingToNonAdjacentGAIA()
    {
        var board = new Board();
        board.Inner[0][0] = Faction.BLACK;
        board.Inner[0][2] = Faction.GAIA;

        var canMoveTo = board.CanMoveTo(Faction.BLACK, new Pos(0, 0), new Pos(0, 2));

        Assert.False(canMoveTo);
    }

    [Fact]
    public void CanMoveTo_ReturnsFalse_WhenMovingFromEmptySquare()
    {
        var board = new Board();
        board.Inner[0][1] = Faction.GAIA;

        var canMoveTo = board.CanMoveTo(Faction.BLACK, new Pos(0, 0), new Pos(0, 1));

        Assert.False(canMoveTo);
    }

    [Fact]
    public void Find_ReturnsPositionsOccupiedByFaction()
    {
        var board = new Board();
        board.Inner[0][0] = Faction.BLACK;
        board.Inner[0][1] = Faction.WHITE;
        board.Inner[0][2] = Faction.BLACK;

        var positions = board.Find(Faction.BLACK);

        Assert.Equal(new[] { new Pos(0, 0), new Pos(0, 2) }, positions);
    }

    [Fact]
    public void FindMoveTargets_ReturnsPositionsOccupiedByFactionWithAdjacentGAIA()
    {
        var board = new Board();
        board.Inner[0][0] = Faction.BLACK;
        board.Inner[0][1] = Faction.GAIA;
        board.Inner[0][2] = Faction.BLACK;

        var positions = board.FindMoveTargets(Faction.BLACK);

        Assert.Equal(new[] { new Pos(0, 0), new Pos(0, 2) }, positions);
    }

    [Fact]
    public void FindRemovable_ReturnsCorrectPositions()
    {
        
        var board = new Board();
        board.Place(Faction.BLACK, new Pos(0, 0));
        board.Place(Faction.WHITE, new Pos(0, 1));
        board.Place(Faction.BLACK, new Pos(0, 2));
        board.Place(Faction.WHITE, new Pos(1, 1));
        board.Place(Faction.BLACK, new Pos(2, 0));
        board.Place(Faction.WHITE, new Pos(2, 1));
        var expectedPositions = new[] { new Pos(0, 1), new Pos(1, 1), new Pos(2, 1) };

        
        var actualPositions = board.FindRemovable(Faction.BLACK);

        
        Assert.Equal(expectedPositions, actualPositions);
    }

    [Fact]
    public void FindValidMoves_ReturnsCorrectPositions()
    {
        
        var board = new Board();
        board.Place(Faction.BLACK, new Pos(0, 0));
        board.Place(Faction.WHITE, new Pos(0, 1));
        board.Place(Faction.BLACK, new Pos(0, 2));
        board.Place(Faction.WHITE, new Pos(1, 1));
        board.Place(Faction.BLACK, new Pos(2, 0));
        board.Place(Faction.WHITE, new Pos(2, 1));
        var expectedPositions = new[] { new Pos(1, 0), new Pos(1, 2) };

        
        var actualPositions = board.FindValidMoves(new Pos(1, 1));

        
        foreach (var pos in expectedPositions)
        {
            Assert.Contains(pos, actualPositions);
        }

        Assert.Equal(expectedPositions.Length, actualPositions.Length);
    }

    [Fact]
    public void CanRemove_ReturnsTrueIfPieceCanBeRemoved()
    {
        
        var board = new Board();
        board.Place(Faction.BLACK, new Pos(0, 0));
        board.Place(Faction.WHITE, new Pos(0, 1));
        board.Place(Faction.BLACK, new Pos(0, 2));
        board.Place(Faction.WHITE, new Pos(1, 1));
        board.Place(Faction.BLACK, new Pos(2, 0));
        board.Place(Faction.WHITE, new Pos(2, 1));

        
        var result = board.CanRemove(Faction.BLACK, new Pos(0, 1));

        
        Assert.True(result);
    }

    [Fact]
    public void CanRemoveReturnsTrueWhenAllMills()
    {
        
        var board = new Board();
        board.Place(Faction.BLACK, new Pos(0, 0));
        board.Place(Faction.WHITE, new Pos(0, 1));
        board.Place(Faction.BLACK, new Pos(0, 2));
        board.Place(Faction.WHITE, new Pos(1, 1));
        board.Place(Faction.BLACK, new Pos(2, 0));
        board.Place(Faction.WHITE, new Pos(2, 1));

        
        var result = board.CanRemove(Faction.BLACK, new Pos(1, 1));

        
        Assert.True(result);
    }

    [Fact]
    public void CanRemoveReturnsFalseWhenNotAllMills()
    {
        
        var board = new Board();
        board.Place(Faction.BLACK, new Pos(0, 0));
        board.Place(Faction.WHITE, new Pos(0, 1));
        board.Place(Faction.BLACK, new Pos(0, 2));
        board.Place(Faction.WHITE, new Pos(1, 1));
        board.Place(Faction.BLACK, new Pos(2, 0));
        board.Place(Faction.WHITE, new Pos(2, 1));
        board.Place(Faction.WHITE, new Pos(2, 5));

        
        var result = board.CanRemove(Faction.BLACK, new Pos(1, 1));

        
        Assert.False(result);
    }

    [Fact]
    public void Place_ThrowsExceptionIfPositionIsOccupied()
    {
        
        var board = new Board();
        board.Place(Faction.BLACK, new Pos(0, 0));
        var position = new Pos(0, 0);

        Assert.Throws<InvalidOperationException>(() => board.Place(Faction.WHITE, position));
    }
}
