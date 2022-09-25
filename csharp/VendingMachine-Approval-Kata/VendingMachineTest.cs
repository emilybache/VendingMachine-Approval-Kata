﻿using static Xunit.Assert;

namespace VendingMachine_Approval_Kata;

[UsesVerify]
public class VendingMachineTest
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

    class Story
    {
        private string _toVerify = "";
        private VendingMachinePrinter _printer;

        public Story(VendingMachinePrinter printer) => _printer = printer;
        public void Init(string name) => _toVerify += $"{name}\n\n";

        public void Arrange() =>
            _toVerify += _printer.PrintEverything();

        public void Act(string action) =>
            _toVerify += $"{action}\n\n{_printer.PrintEverything()}";

        public override string ToString() => _toVerify;
    }

    public VendingMachineTest()
    {
        _machine = new("", new Dictionary<string, int> { { "Cola", 1 } });
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
    public Task select_product()
    {
        _story.Init("Feature: Select product and see price");
        _story.Arrange();

        _story.Act(SelectProduct("Cola"));
        _story.Act(Wait5Secs());
        _story.Act(SelectProduct("Chips"));
        _story.Act(Wait5Secs());
        
        return Verify(_story.ToString());
    }
    
    [Fact]
    public Task pay_for_product()
    {
        _story.Init("Feature: Pay for product");
        _machine.SelectedProduct = "Cola";
        _story.Arrange();

        _story.Act(insert_coin("quarter"));
        _story.Act(insert_coin("quarter"));
        _story.Act(insert_coin("quarter"));
        _story.Act(insert_coin("quarter"));
        _story.Act(Wait5Secs());
        _story.Act(Wait5Secs());
        
        return Verify(_story.ToString());
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