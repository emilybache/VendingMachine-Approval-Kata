using System.Globalization;

namespace VendingMachine_Approval_Kata;

public class VendingMachine
{
    public List<int> Coins { get; } = new();
    public string Display { get; private set; }
    public int Balance { get; private set; }

    public List<int> Returns { get; private set; } = new();


    private readonly CultureInfo _en_Us_Culture;

    public VendingMachine()
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
        var acceptedCoins = new List<int>() { 5, 10, 25 };

        if (acceptedCoins.Contains(coin))
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

}