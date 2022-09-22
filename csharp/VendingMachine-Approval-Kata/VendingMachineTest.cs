using static Xunit.Assert;

namespace VendingMachine_Approval_Kata;

public class VendingMachineTest
{

    [Fact]
    public void test_accept_coins() {
        // TODO: use the printer and Approvals.verify instead of assertions
        var coins = new Dictionary<string, int>(){
            {"penny", 1 },
            {"nickel", 5},
            {"dime", 10},
            {"quarter", 25},
        };
        
        var machine = new VendingMachine();

        Equal("INSERT COIN", machine.Display);

        machine.InsertCoin(coins["nickel"]);

        Equal(5, machine.Balance);
        Equal(new int[]{5}, machine.Coins());
        Equal("5", machine.Display);
    }
}