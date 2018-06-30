using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public GameObject ballUp;
    public GameObject ballRight;
    public GameObject ballDown;
    public GameObject ballLeft;
    private Vector2 fireballPos;
    public float fireRate;
    // Use this for initialization
    void Start()
    {
        fireballPos = transform.position;
        StartCoroutine("FireRoutine");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Fire()
    {
        if(ballUp)
        {
            Instantiate(ballUp, fireballPos, Quaternion.identity);
        }
        if (ballRight)
        {
            Instantiate(ballRight, fireballPos, Quaternion.identity);
        }
        if (ballDown)
        {
            Instantiate(ballDown, fireballPos, Quaternion.identity);
        }
        if (ballLeft)
        {
            Instantiate(ballLeft, fireballPos, Quaternion.identity);
        }

  
    }

    IEnumerator FireRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(fireRate);
            Fire();
        }
    }
}
