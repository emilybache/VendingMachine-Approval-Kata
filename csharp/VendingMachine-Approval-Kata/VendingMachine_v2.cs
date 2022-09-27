namespace VendingMachine_Approval_Kata;

public class VendingMachine_v2
{
    private readonly List<int> _acceptedCoins = new()
    {
        5, 10, 25
    };

    public List<int> Coins { get; } = new();
    public List<int> Returns { get; } = new();
    public string Display { get; private set; }
    public int Balance { get; private set; }

    public VendingMachine_v2()
    {
        Display = "";
        DisplayBalance();
    }

    private void DisplayBalance()
    {
        if (Balance != 0)
        {
            Display = "" + Balance;
        }
        else
        {
            Display = "INSERT COIN";
        }
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
}