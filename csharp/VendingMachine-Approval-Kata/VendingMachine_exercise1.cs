namespace VendingMachine_Approval_Kata;

public class VendingMachine_exercise1 : VendingMachine
{
    public VendingMachine_exercise1(string selectedProduct, Dictionary<string, int> stock) : base(selectedProduct, stock)
    {
        AcceptedCoins = new() { 1, 5, 10, 25 };
    }
    
}