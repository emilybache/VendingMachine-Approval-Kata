using System.Globalization;

namespace VendingMachine_Approval_Kata;

public class VendingMachine
{
    private readonly List<int> _acceptedCoins = new() { 5, 10, 25 };

    public List<int> Coins { get; } = new();
    public string? DispensedProduct = "";

    private Dictionary<string, int> _prices = new()
    {
        { "Cola", 100 }, { "Chips", 50 }, { "Candy", 65 }
    };

    private readonly CultureInfo _en_Us_Culture;

    public List<int> Returns { get; private set; } = new();
    public string? SelectedProduct { get; set; }
    public Dictionary<string, int> Stock { get; set; } = new();

    public VendingMachine()
    {
        Display = "";
        Balance = 0;
        SelectedProduct = "";
        _en_Us_Culture = CultureInfo.CreateSpecificCulture("en-US");

        DisplayBalance();
    }

    public string Display { get; private set; }
    public int Balance { get; private set; }

    private void DisplayBalance()
    {
        if (Balance != 0)
        {
            Display = FormatAsDollars(Balance);
        }
        else 
            Display = "INSERT COIN";
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

    private string FormatAsDollars(int cents)
    {
        return (cents / 100.0).ToString("C", _en_Us_Culture);
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
        else if (
            Display.Contains("THANK YOU") 
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
    

    public void ReturnCoins()
    {
        Balance = 0;
        Returns.AddRange(Coins);
        Coins.Clear();
        DisplayBalance();
    }

    
}