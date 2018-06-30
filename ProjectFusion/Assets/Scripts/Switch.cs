using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.Build;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private GameObject door;

    private bool activated = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ActivateSwitch()
    {
        if (!activated)
        {
            activated = true;
            door.GetComponent<Door>().Open();
        }
        else if (activated)
        {
            activated = false;
            door.GetComponent<Door>().Close();
        }
    }
}