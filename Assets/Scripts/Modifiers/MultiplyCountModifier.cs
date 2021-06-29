using UnityEngine;

[CreateAssetMenu(fileName = "MultiplyCountModifier", menuName = "CoinModifiers/MultiplyCountModifier")]
public class MultiplyCountModifier : CoinModifier
{
    public float multiplyAmout;

    public override int CalculateTotalCoins(int currentCoinCount)
    {
        return Mathf.RoundToInt(currentCoinCount * multiplyAmout);
    }
}
