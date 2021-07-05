using UnityEngine;

[CreateAssetMenu(fileName = "AutoClicker", menuName = "CoinModifiers/AutoClicker")]
public class AutoClicker : CoinModifier
{
    public Timer minerCD = new Timer(0.1f);
    public int minerAmmout = 1;

    public override int CalculateTotalCoins(int currentCoinCount)
    {
        return currentCoinCount;
    }

    public override int Tick()
    {
        minerCD.UpdateTimer(Time.deltaTime);
        if (minerCD.isReady)
        {
            minerCD.Reset();
            return minerAmmout;
        }

        return 0;
    }
}