using Assessment.Testlet.UnitTests.Utils;
using AutoFixture;

namespace Assessment.Testlet.UnitTests;

public class TestletTest
{
    [Theory]
    [AutoNData]
    public void Testlet_ShouldHave10Items(
        string testletId,
        Fixture fixture
    )
    {
        // Arrange
        var items = Items(6, 4);

        // Act
        new Testlet(testletId, items);
    }

    [Theory]
    [InlineAutoNData(0, 0)]
    [InlineAutoNData(1, 2)]
    [InlineAutoNData(11, 7)]
    [InlineAutoNData(5, 5)]
    [InlineAutoNData(10, 0)]
    [InlineAutoNData(0, 10)]
    public void Testlet_ShouldThrowArgumentException_WhenIncorrectNumberOfItemsWerePassed(
        int operationalsCount,
        int pretestsCount,
        string testletId
    )
    {
        // Arrange
        var items = Items(operationalsCount, pretestsCount);

        // Act
        var act = () => new Testlet(testletId, items);

        // Arrange
        Assert.Throws<ArgumentException>(act);
    }

    [Theory]
    [AutoNData]
    private void Testlet_ShouldReturnFirst2PretestItems_WhenRandomize(string testletId)
    {
        // Arrange
        var items = Items(6, 4);
        var testlet = new Testlet(testletId, items);

        // Act
        var randomized = testlet.Randomize();

        // Assert
        Assert.True(randomized
            .Take(2)
            .All(i => i.ItemType == ItemTypeEnum.Pretest));
    }

    [Theory]
    [AutoNData]
    private void Testlet_ShouldRandomizeFirst2PretestItems_WhenRandomize(string testletId)
    {
        // Arrange
        var fixture = new Fixture();
        var pretests = Enumerable.Repeat(ItemTypeEnum.Pretest, 4)
            .Select(itemType =>
            {
                var item = fixture.Create<Item>();
                item.ItemType = itemType;

                return item;
            })
            .ToList();
        var operationals = Enumerable.Repeat(ItemTypeEnum.Operational, 6)
            .Select(itemType =>
            {
                var item = fixture.Create<Item>();
                item.ItemType = itemType;

                return item;
            });
        var items = pretests.Concat(operationals).ToList();

        var testlet = new Testlet(testletId, items);

        // Act
        var firstPretests = testlet.Randomize();

        // Assert
        Assert.NotEqual(firstPretests.Take(2), pretests.Take(2));
    }

    #region Private methods

    private static List<Item> Items(int operationalsCount, int pretestsCount)
    {
        var fixture = new Fixture();
        var rnd = new Random();

        var operationals = Enumerable.Repeat(ItemTypeEnum.Operational, operationalsCount);
        var pretests = Enumerable.Repeat(ItemTypeEnum.Pretest, pretestsCount);
        var items = operationals.Concat(pretests)
            .OrderBy(_ => rnd.Next())
            .Select(itemType =>
            {
                var item = fixture.Create<Item>();
                item.ItemType = itemType;

                return item;
            })
            .ToList();

        return items;
    }

    #endregion
}