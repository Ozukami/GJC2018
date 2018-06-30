using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public enum GameStates
{
    Intro,
    Mainmenu,
    LevelSelection
}

public class GameManager : MonoBehaviour
{
    private BoxCollider2D endRoom;
    public bool paused;
    private GameStates currentState;
    public static GameManager Gm = null;

    void Awake()
    {
        if (Gm == null)
        {
            Gm = this;
        }
        else if (Gm != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        endRoom = GetComponentInChildren<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentState);
    }

    public GameStates SetState(GameStates state)
    {
        if (currentState != state)
        {
            currentState = state;

            switch (state)
            {
                case GameStates.Intro:
                    
                    break;
                case GameStates.Mainmenu:
                    
                    break;
                case GameStates.LevelSelection:
                    
                    break;
                default:
                    break;
            }
        }

        return currentState;
    }
}