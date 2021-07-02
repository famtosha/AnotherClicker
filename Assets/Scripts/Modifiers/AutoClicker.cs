using UnityEngine;

[CreateAssetMenu(fileName = "AutoClicker", menuName = "CoinModifiers/AutoClicker")]
public class AutoClicker : CoinModifier
{
    public Timer _minerCD = new Timer(0.1f);
    public int _minerAmmout;

    public override int CalculateTotalCoins(int currentCoinCount)
    {
        return currentCoinCount;
    }

    public override int Tick()
    {
        _minerCD.UpdateTimer(Time.deltaTime);
        if (_minerCD.isReady)
        {
            _minerCD.Reset();
            return _minerAmmout;
        }

        return 0;
    }
}