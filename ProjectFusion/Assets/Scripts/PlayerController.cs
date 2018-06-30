﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Orientation {
    up = 0, down = 1, right = 2, left = 3
}

public class PlayerController : MonoBehaviour {
    
    [SerializeField]
    private float speed;
    [SerializeField]
    private bool isDead = false;

    private int life = 10;
    private int orientation;

    private Animator _animator;
    private Rigidbody2D _rb2d;

    // Use this for initialization
    void Start () {
        _animator = GetComponent<Animator>();
        _rb2d = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update () {
        _animator.SetBool("isActive", (transform.parent != null));
    }
    
    void FixedUpdate () {
        InputHandler();
        OrientPlayer();
    }

    void InputHandler () {
        if (transform.root.name == "ActivePlayer") {
            float axisX = Input.GetAxis("Horizontal");
            float axisY = Input.GetAxis("Vertical");
            if (axisX != 0 || axisY != 0) {
                _animator.SetBool("isWalking", true);
                _animator.SetFloat("orientationX", axisX);
                _animator.SetFloat("orientationY", axisY);
                GetComponent<SpriteRenderer>().flipX = (axisX < 0) ? true : false;
            } 
            else
                _animator.SetBool("isWalking", false);
            _animator.SetFloat("axisX", axisX);
            _animator.SetFloat("axisY", axisY);
            transform.Translate(Vector3.right * axisX * Time.deltaTime * speed);
            transform.Translate(Vector3.up * axisY * Time.deltaTime * speed);
            if (Input.GetKeyDown(KeyCode.Space)) {
                UseSpell();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && name == "PlayerFire") {
            GameObject.Find("ActivePlayer").transform.GetChild(0).parent = null;
            transform.parent = GameObject.Find("ActivePlayer").transform;
        } else if (Input.GetKeyDown(KeyCode.Alpha2) && name == "PlayerEarth") {
            GameObject.Find("ActivePlayer").transform.GetChild(0).parent = null;
            transform.parent = GameObject.Find("ActivePlayer").transform;
        } else if (Input.GetKeyDown(KeyCode.Alpha3) && name == "PlayerWater") {
            GameObject.Find("ActivePlayer").transform.GetChild(0).parent = null;
            transform.parent = GameObject.Find("ActivePlayer").transform;
        } else if (Input.GetKeyDown(KeyCode.Alpha4) && name == "PlayerWind") {
            GameObject.Find("ActivePlayer").transform.GetChild(0).parent = null;
            transform.parent = GameObject.Find("ActivePlayer").transform;
        }
    }

    void OrientPlayer () {
        switch (orientation) {
                
        }
    }

    void CheckAlive () {
        if (life <= 0)
            isDead = true;
    }

    private void UseSpell () {
        Debug.Log("Pew");
        GetComponent<CircleCollider2D>().enabled = true;
        Collider2D[] results = new Collider2D[10];
        GetComponent<CircleCollider2D>().OverlapCollider(new ContactFilter2D(), results);
        foreach (var col in results) {
            if (col && col.name != name && col.gameObject.layer == 10)
                Debug.Log(col.name);
        }
        GetComponent<CircleCollider2D>().enabled = false;
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Switch"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Activtion");
                other.GetComponent<Switch>().ActivateSwitch();
            }
        }
    }
}
