namespace Model.Test;

public class PlayerTests
{
    [Fact]
    public void StoredPieces_SetToNegative_ThrowsArgumentOutOfRangeException()
    {
        var player = new Player();

        Assert.Throws<ArgumentOutOfRangeException>(() => player.StoredPieces = -1);
    }

    [Fact]
    public void CanRemove_DefaultsToFalse()
    {
        var player = new Player();

        Assert.False(player.CanRemove);
    }

    [Fact]
    public void ToString_ReturnsExpectedString()
    {
        var player = new Player { StoredPieces = 5, CanRemove = true };

        Assert.Equal("StoredPieces: 5, CanRemove: True", player.ToString());
    }
}