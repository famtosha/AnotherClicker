using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Zenject;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private TextMeshProUGUI _gameName;
    [SerializeField] private float _nameRemoveDelay;

    [Inject]
    private void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
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

    public void LoadGame()
    {
        _sceneLoader.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        _sceneLoader.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
