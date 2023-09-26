using Verifier = VerifyNUnit.Verifier;

namespace VendingMachine_Approval_Kata;

using NUnit.Framework;

public class VendingMachineNUnitTest
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
        _machine = new VendingMachine("", new Dictionary<string, int> { });
        _printer = new(_machine);
        _story = new Story(_printer);
    }


    [Test]
    public Task accept_nickel()
    {
        _story.Init("Feature: Accept nickel");
        _story.Arrange();

        _story.Act(insert_coin("nickel"));

        return Verifier.Verify(_story.ToString());
    }
    [Test]
    public Task accept_dime()
    {
        _story.Init("Feature: Accept dime");
        _story.Arrange();

        _story.Act(insert_coin("dime"));

        return Verifier.Verify(_story.ToString());
    }
    [Test]
    public Task accept_quarter()
    {
        _story.Init("Feature: Accept quarter");
        _story.Arrange();

        _story.Act(insert_coin("nickel"));

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

    [Test]
    public Task select_product()
    {
        _story.Init("Feature: Select product and see price");
        _story.Arrange();

        _story.Act(SelectProduct("Cola"));
        _story.Act(Wait5Secs());
        _story.Act(SelectProduct("Chips"));
        _story.Act(Wait5Secs());

        return Verifier.Verify(_story.ToString());
    }

    [Test]
    public Task pay_for_product()
    {
        _story.Init("Feature: Pay for product");
        _machine.SelectedProduct = "Cola";
        _machine.Stock = new Dictionary<string, int> { { "Cola", 1 } };
        _story.Arrange();

        _story.Act(insert_coin("quarter"));
        _story.Act(insert_coin("quarter"));
        _story.Act(insert_coin("quarter"));
        _story.Act(insert_coin("quarter"));
        _story.Act(Wait5Secs());
        _story.Act(Wait5Secs());

        return Verifier.Verify(_story.ToString());
    }

    [Test]
    public Task pay_for_chips()
    {
        _story.Init("Feature: Pay for Chips");
        _machine.SelectedProduct = "Chips";
        _machine.Stock = new Dictionary<string, int> { { "Cola", 1 }, { "Chips", 1 } };
        _story.Arrange();

        _story.Act(insert_coin("quarter"));
        _story.Act(insert_coin("quarter"));
        _story.Act(Wait5Secs());
        _story.Act(Wait5Secs());

        return Verifier.Verify(_story.ToString());
    }

    [Test]
    public Task pay_then_select()
    {
        _story.Init("Feature: Pay first then select product");
        _machine.Stock = new Dictionary<string, int> { { "Chips", 1 }, { "Candy", 1 } };
        _machine.InsertAllCoins(new int[] { 25, 25, 5, 10 });
        _story.Arrange();

        _story.Act(SelectProduct("Candy"));
        _story.Act(Wait5Secs());

        return Verifier.Verify(_story.ToString());
    }

    [Test]
    public Task sold_out()
    {
        _story.Init("Feature: Sold out");
        _machine.Stock = new Dictionary<string, int> { { "Chips", 0 }, { "Candy", 1 } };
        _machine.InsertAllCoins(new int[] { 25, 25 });
        _story.Arrange();

        _story.Act(SelectProduct("Chips"));
        _story.Act(Wait5Secs());

        return Verifier.Verify(_story.ToString());
    }

    [Test]
    public Task returnCoins()
    {
        _story.Init("Feature: Return Coins");
        _machine.InsertAllCoins(new int[] { 25, 5 });
        _story.Arrange();

        _story.Act(ReturnCoins());

        return Verifier.Verify(_story.ToString());
    }

    [Test]
    public Task changeAvailable()
    {
        _story.Init("Feature: Change Is Available");
        _machine.BankCoins(25, 10, 5);
        _story.Arrange();

        return Verifier.Verify(_story.ToString());
    }

    [Test]
    public Task giveChange()
    {
        _story.Init("Feature: Change Is Returned following Purchase");
        _machine.Stock = new Dictionary<string, int> { { "Chips", 0 }, { "Candy", 1 } };
        _machine.BankCoins(25, 10, 5);
        _machine.InsertAllCoins(new int[] { 25, 25, 25 });
        _story.Arrange();

        _story.Act(SelectProduct("Candy"));
        _story.Act(Wait5Secs());

        return Verifier.Verify(_story.ToString());
    }

    private string SelectProduct(string product)
    {
        _machine.SelectProduct(product);
        return $"select product: {product}";
    }

    private string Wait5Secs()
    {
        _machine.Tick();
        return "wait 5 seconds for display to refresh";
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