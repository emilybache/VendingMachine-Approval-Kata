namespace VendingMachine_Approval_Kata;

public class VendingMachine_exercise0 : VendingMachine
{
    public VendingMachine_exercise0(string selectedProduct, Dictionary<string, int> stock) : base(selectedProduct, stock)
    {
        AcceptedCoins = new() { 1, 5, 10, 25 };
    }
    
    protected override void DispenseProduct()
    {
        if (SelectedProduct != null && Stock[SelectedProduct] >= 1)
        {
            Stock[SelectedProduct] -= 1;
            Display = "ENJOY!";
            DispensedProduct = SelectedProduct;
            Balance -= _prices[SelectedProduct];
            foreach (var coin in Coins)
            {
                Bank.Add(coin);
            }

            Coins.Clear();
            if (Balance > 0)
            {
                var change = GetChangeRequired(Balance);
                Returns = change;
                foreach (var coin in change) Bank.Remove(coin);
                Balance = 0;
            }

            SelectedProduct = null;
        }
        else
        {
            Display = "SOLD OUT";
            SelectedProduct = null;
        }
    }
    public override void Tick()
    {
        if (Display.Contains("PRICE"))
        {
            DisplayBalance();
        }
        else if (
            Display.Contains("ENJOY!") ||
            Display.Contains("SOLD OUT")
        )
        {
            DisplayBalance();
            DispensedProduct = null;
            Returns = new List<int>();
        }
        else if (SelectedProduct != null && Balance >= _prices[SelectedProduct])
        {
            DispenseProduct();
        }
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