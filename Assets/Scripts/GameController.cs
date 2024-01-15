using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{ private static GameController instance;
    public static GameController Instance { get { return instance; } }
     public static int level=1;

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
        
    }
    
    public static void nextScreen() {
        level++;
        if (level == 2) {
            SceneManager.LoadScene("Level2");
        }
    }
}
