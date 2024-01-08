using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float jumpForce =  200;

    [SerializeField] public bool grounded, lWall, rWall;
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
            if (Input.GetAxis("Horizontal")!=0 && grounded) {
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
        if (grounded)
        {
            //playerRb.velocity = Vector2.zero;
            playerRb.AddForce(new Vector2(0,jumpForce));
        }
        else if (lWall)
        {
            playerRb.velocity = Vector2.zero;
            playerRb.AddForce(new Vector2(jumpForce*2, jumpForce * 2));

        }
        else if (rWall) {
            playerRb.velocity = Vector2.zero;
            playerRb.AddForce(new Vector2(-jumpForce * 2, jumpForce * 2));
        }
    }
    private void walk(int d) {
        playerRb.velocity = new Vector2(d*vel,playerRb.velocity.y);
    
    
    }
}
