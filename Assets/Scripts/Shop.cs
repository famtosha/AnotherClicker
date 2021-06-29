using UnityEngine;
using System;
using System.Collections.Generic;
using Zenject;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<CoinModifier> _coinModifiers = new List<CoinModifier>();
    [SerializeField] private CoinModifierFactory _factory;
    private Clicker _clicker;

    public event Action AssortmentChanged;
    public List<CoinModifier> coinModifiers => _coinModifiers;


    [Inject]
    private void Construct(Clicker clicker)
    {
        _clicker = clicker;
        _clicker.CoinCountChanged += OnClickerCoinCountChanged;
        CopySO();
    }

    private void OnClickerCoinCountChanged()
    {
        if (_clicker.currentCoinCount > 1000)
        {
            AddAssortiment(_factory.GetNext());
            AddAssortiment(_factory.GetNext());
            AddAssortiment(_factory.GetNext());
            _clicker.CoinCountChanged -= OnClickerCoinCountChanged;
        }
    }

    public void SetAssortiment(List<CoinModifier> modifiers)
    {
        _coinModifiers = modifiers;
        AssortmentChanged?.Invoke();
    }

    public bool TryToBuyModilfer(int id)
    {
        var modifierToBuy = _coinModifiers[id];

        if (modifierToBuy.modifierCost < _clicker.currentCoinCount)
        {
            _clicker.currentCoinCount -= modifierToBuy.modifierCost;
            _clicker.AddModifier(modifierToBuy);
            _coinModifiers.RemoveAt(id);
            AddAssortiment(_factory.GetNext());
            return true;
        }
        return false;
    }

    private void AddAssortiment(CoinModifier coinModifier)
    {
        _coinModifiers.Add(coinModifier);
        AssortmentChanged?.Invoke();
    }

    private void CopySO()
    {
        for (int i = 0; i < _coinModifiers.Count; i++)
        {
            _coinModifiers[i] = Instantiate(_coinModifiers[i]);
        }
    }
}
