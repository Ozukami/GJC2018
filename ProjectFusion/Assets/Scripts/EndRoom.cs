using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRoom : MonoBehaviour
{
    private int colliders;

    // Use this for initialization
    void Start()
    {
        colliders = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        colliders++;

        if (colliders == 4)
        {
            GetComponentInParent<GameManager>().SetState(GameStates.LoadLevel, "SampleScene");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        colliders--;
    }
}