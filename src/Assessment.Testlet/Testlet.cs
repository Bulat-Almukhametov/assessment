namespace Assessment.Testlet;

/// <summary>
///     Set of items a candidate need to answer
/// </summary>
public class Testlet
{
    private List<Item> Items;

    public string TestletId;

    public Testlet(string testletId, List<Item> items)
    {
        if (items.Count != 10) throw new ArgumentException("Items count should be 10");

        if (items.Count(i => i.ItemType == ItemTypeEnum.Operational) != 6)
            throw new ArgumentException("Operational items count should be 6");

        TestletId = testletId;
        Items = items;
    }

    public List<Item> Randomize()
    {
//Items private collection has 6 Operational and 4 Pretest Items. Randomize the order of these items as per the requirement (with TDD)
//The assignment will be reviewed on the basis of – Tests written first, Correct logic, Well structured & clean readable code.
        throw new NotImplementedException();
    }
}