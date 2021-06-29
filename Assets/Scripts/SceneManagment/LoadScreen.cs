using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LoadScreen : MonoBehaviour
{
    public event Action AnimationCompleted;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OpenLoadSceen()
    {
        _animator.SetBool("Hide", true);
        StartCoroutine(WaitLoad());
        IEnumerator WaitLoad()
        {
            yield return new WaitForSeconds(0.5f);
            AnimationCompleted?.Invoke();
        }
    }

    public void CloseLoadScreen()
    {
        _animator.SetBool("Hide", false);
    }
}
