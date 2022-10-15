using AutoFixture.Xunit2;

namespace Assessment.Testlet.UnitTests.Utils;

public class InlineAutoNDataAttribute : CompositeDataAttribute
{
    public InlineAutoNDataAttribute(params object[] values)
        : base(
            new InlineDataAttribute(values),
            new AutoNDataAttribute()
        )
    {
    }
}