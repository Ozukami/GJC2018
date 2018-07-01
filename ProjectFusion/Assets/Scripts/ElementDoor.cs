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
   // private CircleCollider2D _detector;

    // Use this for initialization
    void Start()
    {
        _collider = GetComponentInChildren<BoxCollider2D>();
        _collider.enabled = true;
       // _detector = GetComponentInChildren<CircleCollider2D>();
       // _detector.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.GetComponent<Element>().GetCurrentElem());
        //if (col.gameObject.CompareTag(_type.ToString()))
            //Physics2D
            if (col.gameObject.GetComponent<Element>().GetCurrentElem() == _type)
                Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), _collider);
         //   _collider.enabled = false;
        //else
        //{
         //   _collider.enabled = true;
        //}

        // Debug.Log(Physics2D.GetIgnoreCollision(col.gameObject.GetComponent<Collider2D>(), _collider));
    }
    
//    void OnCollisionExit(Collision col) { 
//        if (col.gameObject == TheObject) {
//            ObjectToDestroy.SetActive (true);
//        }
//    }
}