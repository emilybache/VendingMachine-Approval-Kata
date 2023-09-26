using System.Collections;

namespace VendingMachineTestRig;

public class InputParser
{
    public Dictionary<string, int> ReadStockFromFile(string filename)
    {
        // TODO: actually read the file
        return new Dictionary<string, int>() { { "Chips", 1 }, { "Candy", 1 } };
    }

    public int[] ReadBankFromFile(string filename)
    {
        // TODO: actually read the file
        return new int[] { 25, 10, 5 };
    }

    public int[] ReadInsertedCoinsFromFile(string filename)
    {
        // TODO: actually read the file
        return new int[] { 25, 25, 10, 5 };
    }

    public IEnumerable<string> ReadUserActions(string userActionsJson)
    {
        // TODO: actually read the file
        return new List<string>()
        {
            "SelectProduct Candy",
            "Wait5Secs"
        };
    }
}