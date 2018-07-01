using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ElementType
{
    fire,
    earth,
    water,
    wind
}

public class Element : MonoBehaviour
{
    [SerializeField] private ElementType initialElem;
    private Dictionary<ElementType, int> elementValues;
    
    [SerializeField] private ElementType currentElem;
    
    [SerializeField] private float Fire;
    [SerializeField] private float Earth;
    [SerializeField] private float Water;
    [SerializeField] private float Wind;

    private void Start() {
        elementValues = new Dictionary<ElementType, int>();
        elementValues.Add(ElementType.fire, 0);
        elementValues.Add(ElementType.earth, 0);
        elementValues.Add(ElementType.water, 0);
        elementValues.Add(ElementType.wind, 0);
        elementValues[initialElem] = 100;
        currentElem = initialElem;
    }

    private void Update () {
        Fire = elementValues[ElementType.fire];
        Earth = elementValues[ElementType.earth];
        Water = elementValues[ElementType.water];
        Wind = elementValues[ElementType.wind];
    }

    public ElementType GetCurrentElem () {
        return currentElem;
    }

    public void Induction (ElementType elementType) {
        DecreaseElem(elementType);
        IncreaseElem(elementType);
    }

    private void IncreaseElem (ElementType elemType) {
        elementValues[elemType] = Mathf.Min(100, elementValues[elemType] + 10);
        if (elementValues[elemType] > 50)
            currentElem = elemType;
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
    
}