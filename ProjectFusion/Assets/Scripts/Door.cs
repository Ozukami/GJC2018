using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _animator;
    private Collider2D _collider;

    private bool opened = false;

    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            _animator.SetTrigger("open");
            _collider.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            _animator.SetTrigger("close");
            _collider.enabled = true;
        }
    }

    public void Open()
    {
        if (!opened)
        {
            _animator.SetTrigger("open");
            _collider.enabled = false;
            opened = true;
        }
    }

    public void Close()
    {
        if (opened)
        {
            _animator.SetTrigger("close");
            _collider.enabled = true;
            opened = false;
        }
    }
}