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
    private static UIController UIController;
    private AudioSource source;
    public static float audioVolume=1; // from 0 to 1
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else { Destroy(gameObject); }

        UIController = GameObject.Find("Canvas").GetComponent<UIController>();
        source = GetComponent<AudioSource>();
        if(SceneManager.GetActiveScene().name == "Level1") {
            pauseGame();
        }
        UIController.changeScore(coins);
    }

    private void OnEnable() {
        Coin.OnCoinCollected += increaseScore;
    }

    private void OnDisable() {
        Coin.OnCoinCollected -= increaseScore;
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
        source.volume = audioVolume;
        source.Play();
        UIController.changeScore(coins);
    }

    public static void changePlayerLives(int value) {
        lives = value;
        UIController.changeHealth(lives);
        Debug.Log("Lives:" + lives);
        if(lives <= 0) {
            UIController.setUIComponent(UIController.UI.GameOverMenu);
            UIController.setGameOverScore(coins);
            instance.StartCoroutine("setCreditsScreen");
        }
    }

    private IEnumerator setCreditsScreen() {
        yield return new WaitForSeconds(5f);
        UIController.setUIComponent(UIController.UI.CreditsMenu);
    }

    public static void resetGame() {
        SceneManager.LoadScene("Level1");
        time = 0;
        coins = 0;
    }

    public static void pauseGame() {
        Time.timeScale = 0;
    }
    public static void resumeGame() {
        Time.timeScale = 1;
    }

    public void controlVolume(System.Single vol) {
        audioVolume = vol;
    }
}
