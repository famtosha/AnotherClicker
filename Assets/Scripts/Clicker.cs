using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using TMPro;

public class Clicker : MonoBehaviour
{
    public event Action CoinCountChanged;

    private CoinModifiersCalculator _coinModifiersCalculator = new CoinModifiersCalculator();

    public CoinModifiersCalculator coinModifiersCalculator => _coinModifiersCalculator;

    private int _currentCoinCount;
    public int currentCoinCount
    {
        get => _currentCoinCount;
        set
        {
            _currentCoinCount = value;
            CoinCountChanged?.Invoke();
        }
    }

    private void Update()
    {
        currentCoinCount += _coinModifiersCalculator.GetTotalAddAmount();
    }

    public void Click()
    {
        currentCoinCount += _coinModifiersCalculator.GetTotalCoinsCount(1);
    }

    public void AddModifier(CoinModifier coinModifier)
    {
        _coinModifiersCalculator.AddCoinModifier(coinModifier);
    }
}