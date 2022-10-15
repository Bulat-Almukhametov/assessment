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
}