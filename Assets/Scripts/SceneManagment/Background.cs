using UnityEngine;
using System.Collections;
using Zenject;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField] private AudioSource _mainSource;
    [SerializeField] private AudioSource _clockSource;

    private Image _altBackgroundSprite;
    private Clicker _clicker;
    private bool _isClockSoundPlayed;

    [Inject]
    private void Construct(Clicker clicker, ClickerUI clickerUI)
    {
        _clicker = clicker;
        _altBackgroundSprite = clickerUI.background;
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
        _mainSource.volume = state;
        if (_clicker.currentCoinCount >= 3333 && !_isClockSoundPlayed)
        {
            _clockSource.Play();
            _isClockSoundPlayed = true;
        }
        if (_clicker.currentCoinCount >= 6666)
        {
            Application.Quit();
        }
    }

    public void SetState(float t)
    {
        var tempA = _altBackgroundSprite.color;
        tempA.a = t;
        _altBackgroundSprite.color = tempA;
    }
}