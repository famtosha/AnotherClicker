using UnityEngine;

public abstract class CoinModifier : ScriptableObject
{
    public int modifierID;
    public int modifierCost;
    public Sprite sprite;
    public abstract int CalculateTotalCoins(int currentCoinCount);
    public abstract int Tick();
}
