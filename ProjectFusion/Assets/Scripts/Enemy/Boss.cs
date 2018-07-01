using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    public GameObject[] patrolPoints;
    public string element;
    public float moveSpeed;
    private int currentPoint;
    private Animator _animator;
    private Vector3 old_pos;
    float axisX = 0;
    float axisY = 0;
    public float life = 10;

    // Use this for initialization
    void Start()
    {


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Fire" || collision.gameObject.tag == "Water" || collision.gameObject.tag == "Wind" || collision.gameObject.tag == "Earth" )
        {
            life--;
            if(life<=0)
            {
                Destroy(gameObject);
            }
        }
    }
}
