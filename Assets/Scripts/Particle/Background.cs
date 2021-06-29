using UnityEngine;
using System.Collections;
using Zenject;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioSource _clockSource;

    private Image _firstSprite;
    private Clicker _clicker;

    private bool _isPlayerd;


    [Inject]
    private void Construct(Clicker clicker, ClickerUI clickerUI)
    {
        _clicker = clicker;
        _firstSprite = clickerUI.background;
        clicker.CoinCountChanged += OnCoinCountChanged;
    }

    private void OnDestroy()
    {
        _clicker.CoinCountChanged -= OnCoinCountChanged;
    }

    private void OnCoinCountChanged()
    {
        var state = (float)_clicker.currentCoinCount / (float)6666;
        SetState(1 - state);
        _source.volume = state;
        if (_clicker.currentCoinCount >= 3333 && !_isPlayerd)
        {
            _clockSource.Play();
            _isPlayerd = true;
        }
        if (_clicker.currentCoinCount >= 6666)
        {
            Application.Quit();
        }
    }

    public void SetState(float t)
    {
        var tempA = _firstSprite.color;
        tempA.a = t;
        _firstSprite.color = tempA;
    }
}