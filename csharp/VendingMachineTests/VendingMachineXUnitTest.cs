using static Xunit.Assert;

namespace VendingMachine_Approval_Kata;

public class VendingMachineXUnitTest
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

        Equal("INSERT COIN", machine.Display);

        machine.InsertCoin(Coins["nickel"]);

        Equal(5, machine.Balance);
        Equal(new List<int> { 5 }, machine.Coins);
        Equal("$0.05", machine.Display);
    }
}