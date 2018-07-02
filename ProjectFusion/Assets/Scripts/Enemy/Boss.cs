using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    public float life = 30;

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.tag == "Fire" || collision.gameObject.tag == "Water"
                                               || collision.gameObject.tag == "Wind"
                                               || collision.gameObject.tag == "Earth") {
            life--;
            if (life <= 0) {
                Destroy(gameObject);
            }
        }
    }
}