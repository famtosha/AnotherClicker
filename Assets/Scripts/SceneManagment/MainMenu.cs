using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private LoadScreen _loadScreen;
    [SerializeField] private TextMeshProUGUI _gameName;
    [SerializeField] private float _nameRemoveDelay;

    private AsyncOperation _loadOperation;

    public void LoadGame()
    {
        var state = SceneManager.LoadSceneAsync(1);
        state.allowSceneActivation = false;
        _loadScreen.OpenLoadSceen();
        _loadScreen.AnimationCompleted += OnAnimationComplete;
        _loadOperation = state;
    }

    private void OnAnimationComplete()
    {
        _loadOperation.allowSceneActivation = true;
        _loadScreen.AnimationCompleted -= OnAnimationComplete;
    }

    public void HideGameName()
    {
        StartCoroutine(Hide());

        IEnumerator Hide()
        {
            while (_gameName.text != "")
            {
                yield return new WaitForSeconds(_nameRemoveDelay);
                _gameName.text = _gameName.text.MoveLeft();
            }
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
