using Assert = NUnit.Framework.Assert;

namespace VendingMachine_Approval_Kata;

public class VendingMachineNUnitTest
{
    public readonly Dictionary<string, int> Coins = new()
    {
        { "penny", 1 },
        { "nickel", 5 },
        { "dime", 10 },
        { "quarter", 25 },
    };

    [Fact]
    public void test_accept_coins()
    {
        // TODO: use the printer and Verifier.Verify instead of assertions
        var machine = new VendingMachine();

        Assert.AreEqual("INSERT COIN", machine.Display);

        machine.InsertCoin(Coins["nickel"]);

        Assert.AreEqual(5, machine.Balance);
        Assert.AreEqual(new List<int> { 5 }, machine.Coins);
        Assert.AreEqual("$0.05", machine.Display);
    }

}