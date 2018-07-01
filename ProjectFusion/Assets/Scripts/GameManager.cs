using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameStates {
    Intro,
    Mainmenu,
    LevelSelection,
    LoadLevel
}

public class GameManager : MonoBehaviour {
    private BoxCollider2D endRoom;
    public bool paused;
    private GameStates currentState;
    public static GameManager Gm = null;
    
    private int life = 5;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    private bool gameOver = false;

    private GameObject _hud;

    void Awake () {
        if (Gm == null) {
            Gm = this;
        }
        else if (Gm != this) {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        endRoom = GetComponentInChildren<BoxCollider2D>();
        _hud = GameObject.Find("HUD");
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Return) && gameOver)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        /* Debug Inputs */
        if (Input.GetKeyDown(KeyCode.T))
            TakeDamage();
        if (Input.GetKeyDown(KeyCode.H))
            Heal();
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public GameStates SetState (GameStates state, [CanBeNull] string scene) {
        if (currentState != state) {
            currentState = state;

            switch (state) {
                case GameStates.Intro:
                    break;
                case GameStates.Mainmenu:
                    break;
                case GameStates.LevelSelection:
                    break;
                case GameStates.LoadLevel:
                    SceneManager.LoadScene(scene, LoadSceneMode.Single);
                    break;
                default:
                    break;
            }
        }

        return currentState;
    }

    public void TakeDamage () {
        if (life <= 0) return;
        _hud.transform.GetChild(0).GetChild(--life).GetComponent<Image>().sprite = emptyHeart;
        if (life == 0) {
            Time.timeScale = 0;
            gameOver = true;
            _hud.transform.Find("GameOver").gameObject.SetActive(true);
        }
    }

    public void Heal () {
        if (life >= 5) return;
        _hud.transform.GetChild(0).GetChild(life++).GetComponent<Image>().sprite = fullHeart;
    }
    
}