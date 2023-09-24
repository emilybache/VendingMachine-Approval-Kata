using VendingMachine_Approval_Kata;

namespace VendingMachineTests;

public class VendingMachinePrinter
{
    private readonly int _columns;
    private readonly VendingMachine _machine;

    public VendingMachinePrinter(VendingMachine machine)
    {
        _columns = 60;
        _machine = machine;
    }

    public string Print()
    {
        var fields = new Dictionary<string, string>
        {
            {"Display", _machine.Display},
            {"Balance", "" + _machine.Balance},
            {"Coins", format(_machine.Coins)},
            {"Returns", format(_machine.Returns)},
        };
        var text = "VendingMachine\n";
        foreach (var field in fields)
        {
            text += $@"{Line(field.Key, field.Value)}";
        }

        return text;
    }

    private String Line(String name, String value)
    {
        int whitespaceSize = _columns - name.Length - value.Length;
        String whiteSpace = "";
        for (int i = 0; i < whitespaceSize; i++)
        {
            whiteSpace += " ";
        }

        return name + whiteSpace + value + "\n";
    }

    private string format(List<int> value)
    {
        return "[" + string.Join(", ", value) + "]";
    }

    private string format(Dictionary<string, int> value)
    {
        return "{" + string.Join(", ", value) + "}";
    }
}