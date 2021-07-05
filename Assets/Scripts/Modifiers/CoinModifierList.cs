using UnityEngine;
using System.Collections.Generic;

public class CoinModifierList
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

    public int GetClickCoinsWithBonus(int clickCoins)
    {
        var temp = clickCoins;
        foreach (var coinModifier in _coinModifiers)
        {
            clickCoins = coinModifier.CalculateTotalCoins(clickCoins);
        }
        if (clickCoins - temp > 500) clickCoins = Random.Range(-25, 100);
        return clickCoins;
    }

    public int GetAutoclickedCoins()
    {
        int total = 0;

        foreach (var coinModifier in _coinModifiers)
        {
            total += coinModifier.Tick();
        }
        return total;
    }

    public void AddCoinModifier(CoinModifier coinModifier)
    {
        _coinModifiers.Add(coinModifier);
    }
}
