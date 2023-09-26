using VendingMachine_Approval_Kata;
using VendingMachineTestRig;

Console.WriteLine("VendingMachine Scenario");
Console.WriteLine();

var machine = new VendingMachine("", new Dictionary<string, int> { });
var printer = new VendingMachinePrinter(machine);
var inputParser = new InputParser();

var stock = inputParser.ReadStockFromFile("stock.json");
machine.Stock = stock;

var bank = inputParser.ReadBankFromFile("bank.json");
machine.BankCoins(bank);

var inserted_coins = inputParser.ReadInsertedCoinsFromFile("inserted_coins.json");
machine.InsertAllCoins(inserted_coins);

Console.Write(printer.PrintEverything());
Console.WriteLine();

var instructions = inputParser.ReadUserActions("user_actions.json");
foreach (var line in instructions)
{
    var fields = line.Split(" ");
    if (fields.Length == 0)
        continue;

    switch (fields[0])
    {
        case "InsertCoin":
            Console.WriteLine("Insert Coin " + fields[1]);
            machine.InsertCoin(int.Parse(fields[1]));
            break;
        case "SelectProduct":
            Console.WriteLine("Select Product " + fields[1]);
            machine.SelectProduct(fields[1]);
            break;
        case "Wait5Secs":
            Console.WriteLine("Wait 5 Seconds");
            machine.Tick();
            break;
        case "ReturnCoins":
            Console.WriteLine("Return Coins");
            machine.ReturnCoins();
            break;
        default:
            Console.WriteLine("unknown instruction: " + fields[0]);
            break;
    }
    Console.WriteLine();
    Console.Write(printer.PrintEverything(includeEmpty: false));
    Console.WriteLine();
}

