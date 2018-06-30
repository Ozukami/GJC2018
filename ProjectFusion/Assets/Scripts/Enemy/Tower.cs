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
        StartCoroutine("FireRoutine");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Fire()
    {

        if (ballUp)
        {
            fireballPos = transform.position;
            fireballPos += new Vector2(0, 0.15f);
            Instantiate(ballUp, fireballPos, Quaternion.identity);
        }
        if (ballRight)
        {
            fireballPos = transform.position;
            fireballPos += new Vector2(0.15f, 0.07f);
            Instantiate(ballRight, fireballPos, Quaternion.identity);
        }
        if (ballDown)
        {
            fireballPos = transform.position;
            fireballPos += new Vector2(0, -0.05f);
            Instantiate(ballDown, fireballPos, Quaternion.identity);
        }
        if (ballLeft)
        {
            fireballPos = transform.position;
            fireballPos += new Vector2(-0.15f, 0.07f);
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
