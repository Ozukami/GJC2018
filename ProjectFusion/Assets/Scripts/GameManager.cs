using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStates
{
    Intro,
    Mainmenu,
    LevelSelection,
    LoadLevel
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
    
    }

    public GameStates SetState(GameStates state, [CanBeNull] string scene)
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
                case GameStates.LoadLevel:
                    SceneManager.LoadScene(scene, LoadSceneMode.Additive);
                    break;
                default:
                    break;
            }
        }

        return currentState;
    }
}