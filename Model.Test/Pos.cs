namespace Model.Test;

public class PosTests
{
    [Fact]
    public void Constructor_ThrowsArgumentOutOfRangeException_WhenSquareIsLessThanZero()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Pos(-1, 0));
    }

    [Fact]
    public void Constructor_ThrowsArgumentOutOfRangeException_WhenSquareIsGreaterThanTwo()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Pos(3, 0));
    }

    [Fact]
    public void Constructor_ThrowsArgumentOutOfRangeException_WhenIndexIsLessThanZero()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Pos(0, -1));
    }

    [Fact]
    public void Constructor_ThrowsArgumentOutOfRangeException_WhenIndexIsGreaterThanSeven()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Pos(0, 8));
    }

    [Fact]
    public void Equals_ReturnsTrue_WhenPosObjectsAreEqual()
    {
        var pos1 = new Pos(0, 0);
        var pos2 = new Pos(0, 0);

        var areEqual = pos1.Equals(pos2);

        Assert.True(areEqual);
    }

    [Fact]
    public void Equals_ReturnsFalse_WhenPosObjectsAreNotEqual()
    {
        var pos1 = new Pos(0, 0);
        var pos2 = new Pos(0, 1);

        var areEqual = pos1.Equals(pos2);

        Assert.False(areEqual);
    }

    [Fact]
    public void GetHashCode_ReturnsSameValue_WhenPosObjectsAreEqual()
    {
        var pos1 = new Pos(0, 0);
        var pos2 = new Pos(0, 0);

        var hashCode1 = pos1.GetHashCode();
        var hashCode2 = pos2.GetHashCode();

        Assert.Equal(hashCode1, hashCode2);
    }

    [Fact]
    public void GetHashCode_ReturnsDifferentValue_WhenPosObjectsAreNotEqual()
    {
        var pos1 = new Pos(0, 0);
        var pos2 = new Pos(0, 1);

        var hashCode1 = pos1.GetHashCode();
        var hashCode2 = pos2.GetHashCode();

        Assert.NotEqual(hashCode1, hashCode2);
    }
}
