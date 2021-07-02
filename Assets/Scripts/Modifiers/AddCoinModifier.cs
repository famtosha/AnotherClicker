using UnityEngine;

[CreateAssetMenu(fileName = "AddCoinModifier", menuName = "CoinModifiers/AddCoinModifier")]
public class AddCoinModifier : CoinModifier
{
    public int addAmount;

    public override int CalculateTotalCoins(int currentCoinCount)
    {
        return currentCoinCount + addAmount;
    }

    public override int Tick()
    {
        return 0;
    }
}
