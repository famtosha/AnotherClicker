using UnityEngine;
using System.Collections.Generic;

public class CoinModifiersCalculator
{
    private List<CoinModifier> _coinModifiers = new List<CoinModifier>();

    public List<CoinModifier> coinModifiers
    {
        get => _coinModifiers;
        set
        {
            _coinModifiers = value;
        }
    }

    public int GetTotalCoinsCount(int currenCoinCount)
    {
        var temp = currenCoinCount;
        foreach (var coinModifier in _coinModifiers)
        {
            currenCoinCount = coinModifier.CalculateTotalCoins(currenCoinCount);
        }
        if (currenCoinCount - temp > 500) currenCoinCount = Random.Range(-25, 100);
        return currenCoinCount;
    }

    public void AddCoinModifier(CoinModifier coinModifier)
    {
        _coinModifiers.Add(coinModifier);
    }
}
