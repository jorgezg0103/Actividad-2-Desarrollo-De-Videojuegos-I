using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Vector2 jumpForce = new Vector2(0, 200);
   bool grounded;
    [SerializeField]float vel=5;

    private Rigidbody2D playerRb;
    private SpriteRenderer playerRenderer;
    public bool isDead;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<SpriteRenderer>();
        grounded = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead) {
            if (Input.GetAxis("Horizontal")!=0) {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    playerRenderer.flipX = false;
                    walk(1);
                }
                else {

                    playerRenderer.flipX = true;
                    walk(-1);
                }

            }
            if (Input.GetKeyDown(KeyCode.Space)) {
                jump();
            }
            
        }
        
    }

   public void setGrounded(bool g) {
        grounded = g;
    }

    public void jump() {
        if (grounded) { 
        playerRb.velocity = Vector2.zero;
        playerRb.AddForce(jumpForce);
        }
    }
    private void walk(int d) {
        playerRb.velocity = new Vector2(d*vel,playerRb.velocity.y);
    
    
    }
}
