using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float jumpForce =  200;

    private ArrayList walls;
    private Collider2D wall;
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
        walls = new ArrayList();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead) {
            if (Input.GetAxis("Horizontal")!=0) {
                if (Input.GetAxis("Horizontal") > 0 && !rWall)
                {
                    playerRenderer.flipX = false;
                    walk(1);
                }
                else if(Input.GetAxis("Horizontal") < 0 && !lWall){

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
        walls.Clear();
    }

    public void jump() {
        if (grounded)
        {
            //playerRb.velocity = Vector2.zero;
            playerRb.AddForce(new Vector2(0,jumpForce));
        }
        else if (lWall && !checkWall())
        {
            playerRb.velocity = Vector2.zero;
            playerRb.AddForce(new Vector2(jumpForce*2, jumpForce * 2));

        }
        else if (rWall && !checkWall()) {
            playerRb.velocity = Vector2.zero;
            playerRb.AddForce(new Vector2(-jumpForce * 2, jumpForce * 2));
        }
    }
    private void walk(int d) {
        playerRb.velocity = new Vector2(d*vel,playerRb.velocity.y);
    
    
    }

    private bool checkWall() {
        bool check;
        check = walls.Contains(this.wall);
            if (!check) {
            walls.Add(this.wall);
        }

            return check;
    }

    public void touchWall(Collider2D wall, string name) {
        if (name == "right")
        {
            rWall = true;
        }
        else if (name == "left")
        {
            lWall = true;
        }
        this.wall = wall;
    }
}
