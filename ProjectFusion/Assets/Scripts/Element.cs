using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ElementType {
    fire, earth, water, wind
}

public class Element : MonoBehaviour {
    
    [SerializeField]
    private float fire;
    [SerializeField]
    private float earth;
    [SerializeField]
    private float water;
    [SerializeField]
    private float wind;
    
    [SerializeField]
    private ElementType element;

    private void Start () {
        switch (element) {
            case ElementType.fire:
                fire = 100;
                break;
            case ElementType.earth:
                earth = 100;
                break;
            case ElementType.water:
                water = 100;
                break;
            case ElementType.wind:
                wind = 100;
                break;
        }
    }
}