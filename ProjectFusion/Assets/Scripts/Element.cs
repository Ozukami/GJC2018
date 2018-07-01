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
    private List<Element> elements;
    
    [SerializeField] private float Fire;
    [SerializeField] private float Earth;
    [SerializeField] private float Water;
    [SerializeField] private float Wind;
    [SerializeField] private string MainCarac;


    [SerializeField] private ElementType element;

    private void Start()
    {
        switch (element)
        {
            case ElementType.fire:
                Fire = 100;
                MainCarac = "Fire";
                break;
            case ElementType.earth:
                Earth = 100;
                MainCarac = "Earth";
                break;
            case ElementType.water:
                Water = 100;
                MainCarac = "Water";
                break;
            case ElementType.wind:
                Wind = 100;
                MainCarac = "Wind";
                break;
        }
    }

    private void SetMainCarac(string type)
    {
        var main = 0;

        if (type == MainCarac)
        {
            type = GetSecondMainCarac(type)
        }

        if (MainCarac == "Fire")
        {
            Fire -= type != "Fire" ?  10 : 0;
            main = Fire == Earth ? 1 :
                Fire == Water ? 3 :
                Fire == Wind ? 4 : 0;
        }
        else if (MainCarac == "Earth")
        {
            Earth -= 10;
            main = Earth == Fire ? 1 :
                Earth == Water ? 2 :
                Earth == Wind ? 2 : 0;
        }
        else if (MainCarac == "Water")
        {
            Water -= 10;
            main = Water == Fire ? 3 :
                Water == Earth ? 2 :
                Water == Wind ? 3 : 0;
        }
        else if (MainCarac == "Wind")
        {
            Wind -= 10;
            main = Wind == Fire ? 4 :
                Wind == Earth ? 2 :
                Wind == Water ? 3 : 0;
        }

        if (main == 0)
        {
            if (Fire > Earth && Fire > Water &&
                Fire > Wind)
            {
                MainCarac = "Fire";
            }
            else if (Earth > Fire && Earth > Water &&
                     Earth > Wind)
            {
                MainCarac = "Earth";
            }
            else if (Water > Fire && Water > Earth &&
                     Water > Wind)
            {
                MainCarac = "Water";
            }
            else if (Wind > Fire && Wind > Earth &&
                     Wind > Water)
            {
                MainCarac = "Wind";
            }
        }
        else
        {
            MainCarac = main == 1 ? "Fire" :
                main == 2 ? "Earth" :
                main == 3 ? "Water" :
                main == 4 ? "Wind" : "FUSION";
        }
    }

    public void SetCaracs(string type)
    {
        switch (type)
        {
            case "Earth":
                Earth += 10;
                break;
            case "Fire":
                Fire += 10;
                break;
            case "Water":
                Water += 10;
                break;
            case "Wind":
                Wind += 10;
                break;
            default:
                break;
        }

        SetMainCarac(type);
        Debug.Log(Fire);
        Debug.Log(Earth);
        Debug.Log(Water);
        Debug.Log(Wind);
        Debug.Log(MainCarac);
    }

    

    public string GetMainCarac ()
    {
        return MainCarac;
    }

    public string GetSecondMainCarac(string type)
    {
        
    }
    
}