using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;

namespace Assessment.Testlet.UnitTests.Utils;

public class AutoNDataAttribute : AutoDataAttribute
{
    public AutoNDataAttribute()
        : base(() =>
        {
            var f = new Fixture().Customize(new AutoNSubstituteCustomization
            {
                ConfigureMembers = true,
                GenerateDelegates = true
            });
            f.Register(() => DateTime.UtcNow);

            return f;
        })
    {
    }
}