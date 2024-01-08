using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSensor : MonoBehaviour
{
    [SerializeField] string name;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Walls") { 
       
                player.GetComponent<PlayerController>().touchWall(collision,  name);
          
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Walls")
        {
            if (name == "right")
            {
                player.GetComponent<PlayerController>().rWall = false;
            }
            else if (name == "left")
            {
                player.GetComponent<PlayerController>().lWall = false;
            }
        }
    }
}
