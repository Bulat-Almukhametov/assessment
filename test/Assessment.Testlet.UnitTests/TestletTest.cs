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
        var items = Enumerable.Repeat(0, 10)
            .Select(_ => fixture.Create<Item>())
            .ToList();

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
        string testletId,
        Fixture fixture
    )
    {
        // Arrange
        var operationals = Enumerable.Repeat(ItemTypeEnum.Operational, operationalsCount);
        var pretests = Enumerable.Repeat(ItemTypeEnum.Pretest, pretestsCount);
        var items = operationals.Concat(pretests)
            .Select(itemType =>
            {
                var item = fixture.Create<Item>();
                item.ItemType = itemType;

                return item;
            })
            .ToList();

        // Act
        var act = () => new Testlet(testletId, items);

        // Arrange
        Assert.Throws<ArgumentException>(act);
    }
}