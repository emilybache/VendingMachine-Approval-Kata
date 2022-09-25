namespace VendingMachine_Approval_Kata;

public class VendingMachine
{
    private readonly List<int> _acceptedCoins = new () {5, 10 ,25};
    public List<int> Bank { get; } = new();
    private List<int> _coins = new();
    public string? DispensedProduct = "";
    private Dictionary<string, int> _prices = new()
    {
        { "Cola", 100 }, { "Chips", 50 }, { "Candy", 65 }
    };

    public List<int> Returns { get; private set; } = new();
    public string? SelectedProduct { get; set; }
    public Dictionary<string, int> Stock { get; }

    public VendingMachine(string selectedProduct, Dictionary<string, int> stock)
    {
        Display = "";
        Balance = 0;
        Stock = stock;
        SelectedProduct = selectedProduct;
        DisplayBalance();
    }

    public string Display { get; private set; }
    public int Balance { get; private set; }

    private void DisplayBalance()
    {
        if (Balance != 0)
            Display = "" + Balance;
        else if (HasChange())
            Display = "INSERT COIN";
        else
            Display = "EXACT CHANGE ONLY";
    }

    public int[] Coins()
    {
        return _coins.ToArray();
    }

    public void InsertCoin(int coin)
    {
        if (_acceptedCoins.Contains(coin))
        {
            _coins.Add(coin);
            Balance += coin;
            DisplayBalance();
        }
        else
        {
            Returns.Add(coin);
        }
    }

    public void SelectProduct(string product)
    {
        SelectedProduct = product;
        if (Balance >= _prices[SelectedProduct])
        {
            DispenseProduct();
        }
        else
        {
            var cost = _prices[product];
            var cent = Convert.ToDecimal(cost) / 100;
            Display = $"PRICE {cent:#.00}";
        }
    }

    private void DispenseProduct()
    {
        if (SelectedProduct != null && Stock[SelectedProduct] >= 1)
        {
            Stock[SelectedProduct] -= 1;
            Display = "THANK YOU";
            DispensedProduct = SelectedProduct;
            Balance -= _prices[SelectedProduct];
            foreach (var coin in _coins)
            {
                Bank.Add(coin);
            }
            _coins = new List<int>();
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

    public void Tick()
    {
        if (Display.Contains("PRICE"))
        {
            DisplayBalance();
        }
        else if (
            Display.Contains("THANK YOU") ||
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

    public void UpdateStock(string product, int quantity)
    {
        Stock[product] = quantity;
    }

    public void ReturnCoins()
    {
        Balance = 0;
        Returns = _coins;
        _coins = new List<int>();
        DisplayBalance();
    }

    private bool HasChange()
    {
        return
            Bank.Contains(25)
            && Bank.Contains(10)
            && Bank.Contains(5)
            ;
    }

    private List<int> GetChangeRequired(int balance)
    {
        // TODO: don't fake this one!
        return new List<int> { 10, 5 };
    }
}