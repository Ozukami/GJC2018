using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRoom : MonoBehaviour {
    [SerializeField] private string nextLevel;
    private int colliders = 0;

    public void OnTriggerEnter2D (Collider2D other) {
        colliders++;

        if (colliders == 4) {
            GameManager.Gm.SetState(GameStates.LoadLevel, nextLevel);
        }
    }

    private void OnTriggerExit2D (Collider2D other) {
        colliders--;
    }
}