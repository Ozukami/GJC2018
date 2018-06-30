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
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        colliders++;

        
        print(colliders);
        if (colliders == 4)
        {
            GetComponentInParent<GameManager>().SetState(GameStates.LevelSelection);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        colliders--;
    }
}