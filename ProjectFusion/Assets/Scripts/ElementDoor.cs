using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementDoor : MonoBehaviour
{
    [SerializeField] private Sprite open;
    [SerializeField] private Sprite close;
    [SerializeField] private ElementType _type;
    private Collider2D _collider;

    // Use this for initialization
    void Start()
    {
        _collider = GetComponentInChildren<BoxCollider2D>();
        _collider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.CompareTag(_type.ToString()))
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), _collider);
    }
}