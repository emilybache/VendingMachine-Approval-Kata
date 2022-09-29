using System.Globalization;

namespace VendingMachine_Approval_Kata;

public class VendingMachine_v3
{
    public List<int> Coins { get; } = new();
    public List<int> Returns { get; } = new();
    public string Display { get; private set; }
    public int Balance { get; private set; }
    
    private readonly CultureInfo _en_Us_Culture;

    private readonly List<int> _acceptedCoins = new()
    {
        5, 10, 25
    };

    public VendingMachine_v3()
    {
        Display = "";
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

}