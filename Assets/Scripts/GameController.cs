using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{ private static GameController instance;
    public static GameController Instance { get { return instance; } }
 
    public static int level=1;
    public static int lives = 3;
    private static float time = 0;
    private static int coins = 0;
    private UIController UIController; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else { Destroy(gameObject); }

        UIController = GameObject.Find("Canvas").GetComponent<UIController>();

    }

    private void OnEnable() {
        Coin.OnCoinCollected += increaseScore;
    }

    private void OnDisable() {
        Coin.OnCoinCollected += increaseScore;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        UIController.changeTime((int)time);
    }
    
    public static void nextScreen() {
        level++;
        Debug.Log(time);
        if (level == 2) {
            SceneManager.LoadScene("Level2");
        }
        if (level == 3) {
            SceneManager.LoadScene("Level3");
        }
        if (level == 3) {
            SceneManager.LoadScene("End");
        }
    }

    private void increaseScore() {
        coins++;
        UIController.changeScore(coins);
    }

    public static void changePlayerLives(int value) {
        lives = value;
        UIController.changeHealth(lives);
        Debug.Log("Lives:" + lives);
    }
}
