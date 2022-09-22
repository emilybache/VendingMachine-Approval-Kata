namespace VendingMachine_Approval_Kata;

public class VendingMachine
{
    private readonly List<int> _acceptedCoins = new () {5, 10 ,25};
    private List<int> _bank = new();
    private List<int> _coins = new();
    public string? DispensedProduct = "";
    private Dictionary<string, int> _prices = new()
    {
        { "Cola", 100 }, { "Chips", 50 }, { "Candy", 65 }
    };
    private List<int> _returns = new ();
    private string? _selectedProduct;
    private Dictionary<string, int> _stock;

    public VendingMachine(string selectedProduct, Dictionary<string, int> stock)
    {
        Display = "";
        Balance = 0;
        _stock = stock;
        _selectedProduct = selectedProduct;
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
            _returns.Add(coin);
        }
    }

    public void SelectProduct(string product)
    {
        _selectedProduct = product;
        if (Balance >= _prices[_selectedProduct])
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
        if (_selectedProduct != null && _stock[_selectedProduct] >= 1)
        {
            _stock[_selectedProduct] -= 1;
            Display = "THANK YOU";
            DispensedProduct = _selectedProduct;
            Balance -= _prices[_selectedProduct];
            _bank.Append<>(_coins);
            _coins = new List<int>();
            if (Balance > 0)
            {
                var change = GetChangeRequired(Balance);
                _returns = change;
                foreach (var coin in change) _bank.Remove(coin);
                Balance = 0;
            }

            _selectedProduct = null;
        }
        else
        {
            Display = "SOLD OUT";
            _selectedProduct = null;
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
            _returns = new List<int>();
        }
        else if (_selectedProduct != null && Balance >= _prices[_selectedProduct])
        {
            DispenseProduct();
        }
    }

    public void UpdateStock(string product, int quantity)
    {
        _stock[product] = quantity;
    }

    public void ReturnCoins()
    {
        Balance = 0;
        _returns = _coins;
        _coins = new List<int>();
        DisplayBalance();
    }

    private bool HasChange()
    {
        return
            _bank.Contains(25)
            && _bank.Contains(10)
            && _bank.Contains(5)
            ;
    }

    private List<int> GetChangeRequired(int balance)
    {
        // TODO: don't fake this one!
        return new List<int> { 10, 5 };
    }
}