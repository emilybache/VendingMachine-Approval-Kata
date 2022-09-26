namespace VendingMachine_Approval_Kata;

public class Story
{
    private string _toVerify = "";
    private VendingMachinePrinter _printer;

    public Story(VendingMachinePrinter printer) => _printer = printer;
    public void Init(string name) => _toVerify += $"{name}\n\n";

    public void Arrange() =>
        _toVerify += _printer.PrintEverything();

    public void Act(string action) =>
        _toVerify += $"\n{action}\n\n{_printer.PrintEverything(includeEmpty:false)}";

    public override string ToString() => _toVerify;
}