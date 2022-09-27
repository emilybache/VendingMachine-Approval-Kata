namespace VendingMachine_Approval_Kata;

public class VendingMachine
{
    public List<int> Coins { get; }
    public string Display { get; private set; }
    public int Balance { get; private set; }

    public VendingMachine()
    {
        Coins = new List<int>();
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
        Coins.Add(coin);
        Balance += coin;
        DisplayBalance();
    }
}