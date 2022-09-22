namespace VendingMachine_Approval_Kata;

public class VendingMachine
{
    private readonly List<int> _coins;
    private readonly List<int> _returns;
    public string Display { get; private set; }
    public int Balance { get; private set; }
    private readonly int[] _acceptedCoins;

    public VendingMachine():this("", new List<int>(), new List<int>(), 0, new int[]{5, 10, 25})
    {
    }

    public VendingMachine(String display, List<int> coins, List<int> returns, int balance, int[] acceptedCoins) {
        Display = display;
        _coins = coins;
        _returns = returns;
        Balance = balance;
        _acceptedCoins = acceptedCoins;

        displayBalance();
    }

    private void displayBalance() {
        if(Balance != 0){
            Display = "" + Balance;
        }
        else{
            Display = "INSERT COIN";
        }
    }

    public int[] Coins()
    {
        return _coins.ToArray();
    }

    public void InsertCoin(int coin){
        if(_acceptedCoins.Contains(coin)){
            _coins.Add(coin);
            Balance += coin;
            displayBalance();
        }
        else{
            _returns.Add(coin);
        }
    }
}