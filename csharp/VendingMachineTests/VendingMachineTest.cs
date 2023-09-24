using VendingMachine_Approval_Kata;
using Verifier = VerifyNUnit.Verifier;

namespace VendingMachineTests;

using NUnit.Framework;

public class VendingMachineTest
{
    private readonly Dictionary<string, int> _coins = new()
    {
        { "penny", 1 },
        { "nickel", 5 },
        { "dime", 10 },
        { "quarter", 25 }
    };

    private VendingMachine _machine;
    private VendingMachinePrinter _printer;
    private Story _story;

    [SetUp]
    public void SetUp()
    {
        _machine = new VendingMachine();
        _printer = new(_machine);
        _story = new Story(_printer);
    }


    [Test]
    public Task accept_nickel()
    {
        _story.Init("Feature: Nickel is accepted");
        _story.Arrange();

        _story.Act(insert_coin("nickel"));

        return Verifier.Verify(_story.ToString());
    }
   [Test]
    public Task accept_dime()
    {
        _story.Init("Feature: Dime is accepted");
        _story.Arrange();

        _story.Act(insert_coin("dime"));

        return Verifier.Verify(_story.ToString());
    }
   [Test]
    public Task accept_quarter()
    {
        _story.Init("Feature: Quarter is accepted");
        _story.Arrange();

        _story.Act(insert_coin("quarter"));

        return Verifier.Verify(_story.ToString());
    }
   [Test]
    public Task update_balance()
    {
        _story.Init("Feature: Update balance displayed when coin inserted");
        insert_coin("nickel");
        insert_coin("quarter");
        _story.Arrange();

        _story.Act(insert_coin("dime"));
        
        return Verifier.Verify(_story.ToString());
    }

    [Test]
    public Task reject_penny()
    {
        _story.Init("Feature: Reject penny");
        _story.Arrange();

        _story.Act(insert_coin("penny"));

        return Verifier.Verify(_story.ToString());
    }
    
    

    //[Test]
    public Task return_coins()
    {
        _story.Init("Feature: Return Coins");
        insert_coin("quarter");
        insert_coin("nickel");
        _story.Arrange();

        _story.Act(ReturnCoins());

        return Verifier.Verify(_story.ToString());
    }

    private string insert_coin(string coinName)
    {
        _machine.InsertCoin(_coins[coinName]);
        return $"insert coin: {coinName}";
    }

    private string ReturnCoins()
    {
        //_machine.ReturnCoins();
        return "Return coins";
    }
}