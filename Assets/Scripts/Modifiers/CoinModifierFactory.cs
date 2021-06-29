using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopAccortimentFactoryCoinModifierFactory", menuName = "Factories/CoinModifierFactory")]
public class CoinModifierFactory : ScriptableObject
{
    public List<CoinModifier> coinModifiers = new List<CoinModifier>();

    private void Awake()
    {
        for (int i = 0; i < coinModifiers.Count; i++)
        {
            coinModifiers[i].modifierID = i;
        }
    }

    public CoinModifier GetCoinModifier(int id)
    {
        return Instantiate(coinModifiers[id]);
    }

    public CoinModifier GetNext()
    {
        return Instantiate(coinModifiers[Random.Range(0, coinModifiers.Count)]);
    }
}
