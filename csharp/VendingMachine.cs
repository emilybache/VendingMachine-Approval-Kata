using System.Globalization;

namespace VendingMachine_Approval_Kata;

public class VendingMachine
{
    private readonly List<int> _acceptedCoins = new() { 5, 10, 25 };

    public List<int> Coins { get; } = new();


    private Dictionary<string, int> _prices = new()
    {
        { "Cola", 100 }, { "Chips", 50 }, { "Candy", 65 }
    };

    private readonly CultureInfo _en_Us_Culture;

    public List<int> Returns { get; private set; } = new();



    public VendingMachine(string selectedProduct, Dictionary<string, int> stock)
    {
        Display = "";
        Balance = 0;
        _en_Us_Culture = CultureInfo.CreateSpecificCulture("en-US");

        DisplayBalance();
    }

    public string Display { get; private set; }
    public int Balance { get; private set; }

    private void DisplayBalance()
    {
        Display = Balance != 0 ? FormatAsDollars(Balance) : "INSERT COIN";
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


    private string FormatAsDollars(int cents)
    {
        return (cents / 100.0).ToString("C", _en_Us_Culture);
    }

    
    public void ReturnCoins()
    {
        Balance = 0;
        Returns.AddRange(Coins);
        Coins.Clear();
        DisplayBalance();
    }






}