using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{ private static GameManager instance;
    public static GameManager Instance { get { return instancie; } }
    public static level=1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this
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

    public void siguiente pantalla() {
        level++;
        if (level == 2) {
            SceneManager.LoadScene("PlayerTesting");
        }
    }
}
