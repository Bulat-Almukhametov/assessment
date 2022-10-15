﻿namespace Assessment.Testlet;

/// <summary>
///     Set of items a candidate need to answer
/// </summary>
public class Testlet
{
    private List<Item> Items;
    public string TestletId;

    public Testlet(string testletId, List<Item> items)
    {
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