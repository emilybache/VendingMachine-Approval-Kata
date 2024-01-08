namespace VendingMachine_Approval_Kata;

public class VendingMachine_exercise3 : VendingMachine
{
    public VendingMachine_exercise3(string selectedProduct, Dictionary<string, int> stock) : base(selectedProduct, stock)
    {
    }

    protected override void DisplayBalance()
    {
        if (Balance != 0)
        {
            Display = FormatAsDollars(Balance);
        }
        else if (HasChange())
            Display = "INSERT COIN";
        else
            Display = "NO CHANGE AVAILABLE";
    }
}