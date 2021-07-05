using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using TMPro;

public class Clicker : MonoBehaviour
{
    public event Action CoinCountChanged;

    private CoinModifierList _coinModifiersList = new CoinModifierList();

    public CoinModifierList coinModifiersList => _coinModifiersList;

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
        currentCoinCount += _coinModifiersList.GetAutoclickedCoins();
    }

    public void Click()
    {
        currentCoinCount += _coinModifiersList.GetClickCoinsWithBonus(1);
    }

    public void AddModifier(CoinModifier coinModifier)
    {
        _coinModifiersList.AddCoinModifier(coinModifier);
    }
}