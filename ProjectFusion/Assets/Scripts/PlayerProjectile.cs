using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {

    public float fireSpeed;
    public float VelX;
    public float VelY;

    void Start () { transform.right = new Vector2(VelX, VelY); }

    void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * fireSpeed);
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == gameObject.tag) {
            SoundManager.soundMan.PlaySound(1);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag != "Player") {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.CompareTag("Lava")) {
            Destroy(other.gameObject);
        }
        Debug.Log("Test2");
    }
}