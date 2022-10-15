using Assessment.Testlet.UnitTests.Utils;
using AutoFixture;

namespace Assessment.Testlet.UnitTests;

public class TestletTest
{
    [Theory]
    [AutoNData]
    public void Testlet_ShouldHave10Items(
        string testletId
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
        var items = Items(6, 4);

        var testlet = new Testlet(testletId, items);

        // Act
        var randomize1 = testlet.Randomize();
        var randomize2 = testlet.Randomize();

        // Assert
        Assert.NotEqual(randomize1.Take(2), randomize2.Take(2));
    }

    [Theory]
    [AutoNData]
    private void Testlet_ShouldRandomizeMixedItems_WhenRandomize(string testletId)
    {
        // Arrange
        var items = Items(6, 4);

        var testlet = new Testlet(testletId, items);

        // Act
        var randomize1 = testlet.Randomize();
        var randomize2 = testlet.Randomize();

        // Assert
        Assert.NotEqual(randomize1.Skip(4), randomize2.Skip(4));
    }

    [Theory]
    [AutoNData]
    private void Testlet_ShouldReturnAllItems_WhenRandomize(string testletId)
    {
        // Arrange
        var items = Items(6, 4);
        var itemIds = items.OrderBy(i => i.ItemId);

        var testlet = new Testlet(testletId, items);

        // Act
        var randomized = testlet.Randomize()
            .OrderBy(i => i.ItemId);

        // Assert
        Assert.Equal(randomized, itemIds);
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