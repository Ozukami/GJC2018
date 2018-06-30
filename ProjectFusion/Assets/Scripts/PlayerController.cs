using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Element {
    fire, earth, water, wind
}

public enum Orientation {
    up = 0, down = 1, right = 2, left = 3
}

public class PlayerController : MonoBehaviour {
    
    [SerializeField]
    private float speed;
    [SerializeField]
    private Element element;
    private bool isDead = false;

    private int life = 10;
    private int orientation;

    private Animator _animator;
    private Rigidbody2D _rb2d;

    // Use this for initialization
    void Start () {
        _animator = GetComponent<Animator>();
        _rb2d = GetComponent<Rigidbody2D>();
        Debug.Log("I'm alive");
    }
    
    // Update is called once per frame
    void Update () {
        
    }
    
    void FixedUpdate () {
        InputHandler();
        OrientPlayer();
    }

    void InputHandler () {
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
    }

    void OrientPlayer () {
        switch (orientation) {
                
        }
    }

    void CheckAlive () {
        if (life <= 0)
            isDead = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("at range");
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
