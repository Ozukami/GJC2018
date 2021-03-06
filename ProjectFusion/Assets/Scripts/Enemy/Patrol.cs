﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

    public GameObject[] patrolPoints;
    public string element;
    public float moveSpeed;
    private int currentPoint;
    private Animator _animator;
    private Vector3 old_pos;
    float axisX = 0;
    float axisY = 0;
    [SerializeField] private bool isStatic = false;

    void Start () {
        if (patrolPoints.Length > 0)
            transform.position = patrolPoints[0].transform.position;
        currentPoint = 0;

        old_pos = transform.position;
        _animator = GetComponent<Animator>();
    }

    void Update () {
        if (!isStatic) {
            Patroling();
            CheckOrientation();
            Animations();
        }
    }

    void Patroling () {
        if (transform.position == patrolPoints[currentPoint].transform.position) {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].transform.position,
            moveSpeed * Time.deltaTime);
    }

    void Animations () {
        if (axisX != 0 || axisY != 0) {
            _animator.SetBool("isWalking", true);
            _animator.SetFloat("orientationX", axisX);
            _animator.SetFloat("orientationY", axisY);
            GetComponent<SpriteRenderer>().flipX = (axisX < 0) ? true : false;
        } else
            _animator.SetBool("isWalking", false);

        _animator.SetFloat("axisY", axisY);
        _animator.SetFloat("axisX", axisX);
    }

    void CheckOrientation () {
        if (old_pos.x < transform.position.x)
            axisX = 1;
        else if (old_pos.x > transform.position.x)
            axisX = -1f;
        else
            axisX = 0;
        if (old_pos.y < transform.position.y)
            axisY = 1;
        else if (old_pos.y > transform.position.y)
            axisY = -1f;
        else
            axisY = 0;
        old_pos = transform.position;
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            GameObject cat = collision.gameObject;
            string elementPlayer = cat.GetComponent<Element>().GetCurrentElem().ToString();
            if (elementPlayer != element) {
                GameManager.Gm.TakeDamage();
                SoundManager.soundMan.PlaySound(0);
            }
        }
    }
}