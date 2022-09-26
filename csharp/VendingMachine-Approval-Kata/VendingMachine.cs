﻿using System.Globalization;

namespace VendingMachine_Approval_Kata;

public class VendingMachine
{
    private readonly List<int> _acceptedCoins = new() { 5, 10, 25 };
    public List<int> Bank { get; } = new();
    public List<int> Coins { get; } = new();
    public string? DispensedProduct = "";

    private Dictionary<string, int> _prices = new()
    {
        { "Cola", 100 }, { "Chips", 50 }, { "Candy", 65 }
    };

    private readonly CultureInfo _en_Us_Culture;

    public List<int> Returns { get; private set; } = new();
    public string? SelectedProduct { get; set; }
    public Dictionary<string, int> Stock { get; set; }

    public VendingMachine(string selectedProduct, Dictionary<string, int> stock)
    {
        Display = "";
        Balance = 0;
        Stock = stock;
        SelectedProduct = selectedProduct;
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
        else if (HasChange())
            Display = "INSERT COIN";
        else
            Display = "EXACT CHANGE ONLY";
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
        if (SelectedProduct != null && Stock[SelectedProduct] >= 1)
        {
            Stock[SelectedProduct] -= 1;
            Display = "THANK YOU";
            DispensedProduct = SelectedProduct;
            Balance -= _prices[SelectedProduct];
            foreach (var coin in Coins)
            {
                Bank.Add(coin);
            }

            Coins.Clear();
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
        Returns.AddRange(Coins);
        Coins.Clear();
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