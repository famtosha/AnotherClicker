using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private LoadScreen _loadScreen;

    public TextMeshProUGUI tmp;

    public bool isShitting = false;

    IEnumerator Wierd()
    {
        isShitting = true;
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            tmp.text = MoveLeft(tmp.text);
        }
    }

    public void Shit()
    {
        if (!isShitting)
        {
            StartCoroutine(Wierd());
        }
        else
        {
            isShitting = true;
        }
    }

    private string MoveLeft(string text)
    {
        if (string.IsNullOrEmpty(text)) return "";
        text = text.Remove(0, 1);
        return text;
    }

    public void LoadGame()
    {
        StartCoroutine(LoadAsync());
        IEnumerator LoadAsync()
        {
            _loadScreen.Show();
            yield return new WaitForSeconds(1);
            var asyncResult = SceneManager.LoadSceneAsync(1);
            asyncResult.completed += OnSceneLoaded;
        }
    }


    private void OnSceneLoaded(AsyncOperation asyncOperation)
    {

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
