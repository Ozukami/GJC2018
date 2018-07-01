using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Orientation {
    up = 0,
    down = 1,
    right = 2,
    left = 3
}

public class PlayerController : MonoBehaviour {
    
    [SerializeField] private float speed;
//    private GameObject sounds;

    [SerializeField] private AnimatorOverrideController[] animatorControllers;

    private Element _element;
    private Animator _animator;
    private Rigidbody2D _rb2d;
    private CircleCollider2D _inductionRange;
    private ParticleSystem _inductionParticle;

    // Use this for initialization
    void Start () {
        _animator = GetComponent<Animator>();
        _rb2d = GetComponent<Rigidbody2D>();
        _element = GetComponent<Element>();
        _inductionRange = GetComponent<CircleCollider2D>();
        _inductionParticle = transform.Find("InductionParticle").GetComponent<ParticleSystem>();
//        sounds = GameObject.Find("Gm");
    }

    // Update is called once per frame
    void Update () {
        _animator.SetBool("isActive", (transform.parent != null));
    }

    void FixedUpdate () {
        InputHandler();
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

        if (Input.GetKeyDown(KeyCode.Alpha1) && name == "PlayerFire")
            ChangeActivePlayer();
        else if (Input.GetKeyDown(KeyCode.Alpha2) && name == "PlayerEarth")
            ChangeActivePlayer();
        else if (Input.GetKeyDown(KeyCode.Alpha3) && name == "PlayerWater")
            ChangeActivePlayer();
        else if (Input.GetKeyDown(KeyCode.Alpha4) && name == "PlayerWind")
            ChangeActivePlayer();
    }

    private void ChangeActivePlayer()
    {
        GameObject.Find("ActivePlayer").transform.GetChild(0).parent = null;
        transform.parent = GameObject.Find("ActivePlayer").transform;
        GameManager.Gm.UpdateElementsHUD();
    }

    private void UseSpell () {
        Debug.Log("Pew");
        transform.Find("InductionParticle").GetComponent<ParticleSystem>().Play();
        _inductionRange.enabled = true;
        Collider2D[] results = new Collider2D[10];
        _inductionRange.OverlapCollider(new ContactFilter2D(), results);
        foreach (var col in results) {
            if (col && col.name != name && col.gameObject.layer == 10) {
                Debug.Log(col.name);
                col.GetComponent<Element>().Induction(_element.GetCurrentElem());
            }
        }
        
        _inductionRange.enabled = false;
    }

    private void OnTriggerStay2D (Collider2D other) {
        if (other.CompareTag("Switch")) {
            if (Input.GetKeyDown(KeyCode.E)) {
                other.GetComponent<Switch>().ActivateSwitch();
            }
        }
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Fire" || collision.gameObject.tag == "Earth" ||
            collision.gameObject.tag == "Air" || collision.gameObject.tag == "Water") {
            if (collision.gameObject.tag != this.gameObject.tag) {
                Destroy(gameObject);
            }
        }
    }

    public void ChangeAnimatorController (ElementType elem) {
        _animator.runtimeAnimatorController = animatorControllers[(int)elem];
    }
}