using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Element {
    fire, earth, water, wind
}

public class PlayerController : MonoBehaviour {
    
    [SerializeField]
    private float speed;
    [SerializeField]
    private Element element;
    private bool isDead = false;

    private int life = 10;

    // Use this for initialization
    void Start () {
        Debug.Log("I'm alive");
    }
    
    // Update is called once per frame
    void Update () {
        InputHandler();
    }

    void InputHandler () {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        } else if (Input.GetKey(KeyCode.UpArrow)) {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
    }

    void CheckAlive () {
        if (life <= 0)
            isDead = true;
    }

}
