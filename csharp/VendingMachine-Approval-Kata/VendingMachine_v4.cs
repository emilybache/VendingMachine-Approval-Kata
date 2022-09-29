using System.Globalization;

namespace VendingMachine_Approval_Kata;

public class VendingMachine_v4
{
    public List<int> Coins { get; } = new();
    public List<int> Returns { get; } = new();
    public string Display { get; private set; }
    public int Balance { get; private set; }

    public string? SelectedProduct { get; set; }
    public string? DispensedProduct { get; set; }
    public Dictionary<string, int> Stock { get; set; } = new();

    private readonly CultureInfo _en_Us_Culture;

    private readonly List<int> _acceptedCoins = new()
    {
        5, 10, 25
    };

    private readonly Dictionary<string, int> _prices = new()
    {
        { "Cola", 100 }, { "Chips", 50 }, { "Candy", 65 }
    };

    public VendingMachine_v4()
    {
        Display = "";
        SelectedProduct = "";
        DispensedProduct = "";
        _en_Us_Culture = CultureInfo.CreateSpecificCulture("en-US");

        DisplayBalance();
    }

    private void DisplayBalance()
    {
        Display = Balance != 0 ? FormatAsDollars(Balance) : "INSERT COIN";
    }

    private string FormatAsDollars(int cents)
    {
        return (cents / 100.0).ToString("C", _en_Us_Culture);
    }

    public void InsertCoin(int coin)
    {
        if (_acceptedCoins.Contains(coin))
        {
            Coins.Add(coin);
            Balance += coin;
            DisplayBalance();
        }
        else
        {
            Returns.Add(coin);
        }
    }

    public void ReturnCoins()
    {
        Balance = 0;
        Returns.AddRange(Coins);
        Coins.Clear();
        DisplayBalance();
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
            var dollars = FormatAsDollars(cost);
            Display = $"PRICE {dollars}";
        }
    }

    private void DispenseProduct()
    {
        Stock[SelectedProduct] -= 1;
        Display = "THANK YOU";
        DispensedProduct = SelectedProduct;
        Balance -= _prices[SelectedProduct];
        
        Coins.Clear();

        SelectedProduct = null;
    }

    public void Tick()
    {
        if (Display.Contains("PRICE"))
        {
            DisplayBalance();
        }
        else if (Display.Contains("THANK YOU"))
        {
            DisplayBalance();
            DispensedProduct = null;
            Returns.Clear();
        }
        else if (SelectedProduct != null && Balance >= _prices[SelectedProduct])
        {
            DispenseProduct();
        }
    }
}