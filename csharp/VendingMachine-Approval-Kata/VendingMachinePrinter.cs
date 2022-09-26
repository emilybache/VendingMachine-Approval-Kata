using System.ComponentModel.DataAnnotations;

namespace VendingMachine_Approval_Kata;

public class VendingMachinePrinter
{
    private readonly int _columns;
    private readonly VendingMachine _machine;

    public VendingMachinePrinter(VendingMachine machine)
    {
        _columns = 60;
        _machine = machine;
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



    public string PrintEverything(bool includeEmpty=true)
    {
        var fields = new Dictionary<string, string>
        {
            {"Display", _machine.Display},
            {"Balance", "" + _machine.Balance},
            {"Coins", format(_machine.Coins)},
            {"Returns", format(_machine.Returns)},
            {"Selected product", "" + _machine.SelectedProduct},
            {"Dispensed product", "" + _machine.DispensedProduct},
            {"Stock", format(_machine.Stock)},
            {"Banked Coins", format(_machine.Bank)},
        };
        var text = "VendingMachine\n";
        foreach (var field in fields)
        {
            if (includeEmpty || (field.Value != "" && field.Value != "{}" && field.Value != "[]"))
            {
                text += $@"{Line(field.Key, field.Value)}";
            }
        }

        return text;
    }
}