using static Xunit.Assert;

namespace VendingMachine_Approval_Kata;

[UsesVerify]
public partial class VendingMachineTest
{
    private readonly Dictionary<string, int> _coins = new()
    {
        { "penny", 1 },
        { "nickel", 5 },
        { "dime", 10 },
        { "quarter", 25 }
    };

    private readonly VendingMachine _machine;
    private readonly VendingMachinePrinter _printer;
    private readonly Story _story;

    public VendingMachineTest()
    {
        _machine = new("", new Dictionary<string, int> {  });
        _printer = new(_machine);
        _story = new Story(_printer);
    }


    [Fact]
    public Task accept_coins()
    {
        _story.Init("Feature: Accept coins");
        _story.Arrange();

        _story.Act(insert_coin("nickel"));
        _story.Act(insert_coin("dime"));
        _story.Act(insert_coin("quarter"));

        return Verify(_story.ToString());
    }
    [Fact]
    public Task reject_penny()
    {
        _story.Init("Feature: Reject penny");
        _story.Arrange();

        _story.Act(insert_coin("penny"));

        return Verify(_story.ToString());
    }
    

    

    

    

    
  
    
    [Fact]
    public Task returnCoins()
    {
        _story.Init("Feature: Return Coins");
        insert_coin("quarter");
        insert_coin("nickel");
        _story.Arrange();

        _story.Act(ReturnCoins());

        return Verify(_story.ToString());
    }    


    private string ReturnCoins()
    {
        _machine.ReturnCoins();
        return "Return coins";
    }

    private string insert_coin(string coinName)
    {
        _machine.InsertCoin(_coins[coinName]);
        return $"insert coin: {coinName}";
    }
}