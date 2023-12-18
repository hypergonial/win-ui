namespace Model.Test;

public class SquareTests {
    [Fact]
    public void Square_DefaultConstructor_InitializesInnerArray()
    {
        var square = new Square();

        Assert.Equal(Faction.GAIA, square[0]);
        Assert.Equal(Faction.GAIA, square[1]);
        Assert.Equal(Faction.GAIA, square[2]);
        Assert.Equal(Faction.GAIA, square[3]);
        Assert.Equal(Faction.GAIA, square[4]);
        Assert.Equal(Faction.GAIA, square[5]);
        Assert.Equal(Faction.GAIA, square[6]);
        Assert.Equal(Faction.GAIA, square[7]);
    }

}