using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class SceneLoader : MonoBehaviour
{
    public event Action AnimationCompleted;

    private Animator _animator;
    private AsyncOperation _loadOperation;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void LoadScene(int buildIndex)
    {
        if (_loadOperation != null) Debug.LogError($"Scene already loading");
        var state = SceneManager.LoadSceneAsync(buildIndex);
        state.allowSceneActivation = false;
        OpenLoadScreen();
        AnimationCompleted += OnAnimationComplete;
        _loadOperation = state;
        _loadOperation.completed += OnSceneLoaded;
    }

    private void OnAnimationComplete()
    {
        _loadOperation.allowSceneActivation = true;
        AnimationCompleted -= OnAnimationComplete;
    }

    private void OnSceneLoaded(AsyncOperation obj)
    {
        CloseLoadScreen();
        _loadOperation.completed -= OnSceneLoaded;
        _loadOperation = null;
    }

    private void OpenLoadScreen()
    {
        _animator.SetBool("Hide", true);
        StartCoroutine(WaitLoad());
        IEnumerator WaitLoad()
        {
            yield return new WaitForSeconds(0.5f);
            AnimationCompleted?.Invoke();
        }
    }

    private void CloseLoadScreen()
    {
        _animator.SetBool("Hide", false);
    }
}
