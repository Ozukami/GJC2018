using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private Animator _animator;
    
    void Start () {
        _animator = GetComponent<Animator>();
    }
    
    private void Update () {
        if (Input.GetKeyDown(KeyCode.O))
            _animator.SetTrigger("open");
        if (Input.GetKeyDown(KeyCode.F))
            _animator.SetTrigger("close");
    }
    
}