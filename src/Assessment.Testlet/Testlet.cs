namespace Assessment.Testlet;

/// <summary>
///     Set of items a candidate need to answer
/// </summary>
public class Testlet
{
    private readonly List<Item> Items;

    public string TestletId;

    public Testlet(string testletId, List<Item> items)
    {
        if (items.Count != 10) throw new ArgumentException("Items count should be 10.");

        if (items.Count(i => i.ItemType == ItemTypeEnum.Operational) != 6)
            throw new ArgumentException("Operational items count should be 6.");

        TestletId = testletId;
        Items = items;
    }

    public List<Item> Randomize()
    {
        var rnd = new Random();

        var pretests = Items.Where(i => i.ItemType == ItemTypeEnum.Pretest)
            .OrderBy(_ => rnd.Next())
            .Take(2)
            .ToList();

        var mix = Items.Where(i => !pretests.Contains(i))
            .OrderBy(_ => rnd.Next());

        return pretests.Concat(mix).ToList();
    }
}