using UnityEngine;
using TMPro;
using Zenject;
using System;
using UnityEngine.UI;

public class ClickerUI : MonoBehaviour
{
    public event Action ShopOpening;

    [SerializeField] private TextMeshProUGUI _coinCountText;
    [SerializeField] private Image _background;
    public Image background => _background;
    private Clicker _clicker;

    [Inject]
    private void Construct(Clicker clicker)
    {
        _clicker = clicker;
        _clicker.CoinCountChanged += OnCoinCountChanged;
    }

    private void OnDestroy()
    {
        _clicker.CoinCountChanged -= OnCoinCountChanged;
    }

    public void Click()
    {
        _clicker.Click();
    }

    public void OpenShop()
    {
        ShopOpening?.Invoke();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void OnCoinCountChanged()
    {
        _coinCountText.text = _clicker.currentCoinCount.ToString();
    }
}
