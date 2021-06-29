using UnityEngine;

public class LoadScreen : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Show()
    {
        _animator.SetBool("Hide", true);
    }
}
