using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{ private static GameController instance;
    public static GameController Instance { get { return instance; } }
 
    public static int level=1;
    public static int lives = 3;
    public static float time = 0;
    public static int coins = 0;

    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else { Destroy(gameObject); }


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
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

   
}
