﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum ElementType {
    earth,
    fire,
    water,
    wind
}

public class Element : MonoBehaviour {
    private PlayerController pc;
    [SerializeField] private ElementType initialElem;
    private Dictionary<ElementType, int> elementValues;

    [SerializeField] private ElementType currentElem;

    private void Start () {
        pc = GetComponent<PlayerController>();
        elementValues = new Dictionary<ElementType, int>();
        elementValues.Add(ElementType.fire, 0);
        elementValues.Add(ElementType.earth, 0);
        elementValues.Add(ElementType.water, 0);
        elementValues.Add(ElementType.wind, 0);
        elementValues[initialElem] = 100;
        currentElem = initialElem;
    }

    private void Update () { pc.ChangeParticleColor(currentElem); }

    public ElementType GetCurrentElem () { return currentElem; }

    public void Induction (ElementType elementType) {
        DecreaseElem(elementType);
        IncreaseElem(elementType);
        GameManager.Gm.UpdateElementsHUD();
    }

    private void IncreaseElem (ElementType elemType) {
        elementValues[elemType] = Mathf.Min(100, elementValues[elemType] + 10);
        if (elementValues[elemType] > 50) {
            currentElem = elemType;
            gameObject.layer = 19 + (int) elemType;
//            pc.transform.tag = elemType.ToString().ToLower();
            pc.ChangeAnimatorController(currentElem);
            pc.ChangeParticleColor(currentElem);
        }
    }

    private void DecreaseElem (ElementType elemType) {
        ElementType maxElem = currentElem;
        int maxValue = 0;
        foreach (var elem in elementValues) {
            if (!elem.Key.Equals(elemType) && elem.Value > maxValue) {
                maxValue = elem.Value;
                maxElem = elem.Key;
            }
        }

        elementValues[maxElem] = Mathf.Max(0, elementValues[maxElem] - 10);
    }

    public Dictionary<ElementType, int> GetElemDictionnary () { return elementValues; }
}