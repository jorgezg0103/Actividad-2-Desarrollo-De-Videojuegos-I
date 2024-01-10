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

    [Header("Velocity")]
    [SerializeField]float speed;
    [SerializeField] float smoothTime;
    [SerializeField] float maxVel = 5;

    private Rigidbody2D playerRb;
    Vector2 targetVelocity;
    Vector2 dampVelocity;


    private SpriteRenderer playerRenderer;
    public bool isDead;
    bool jump;
    int direction;


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
            InputUpdate();
           
        }
        
    }
    private void InputUpdate() {
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") > 0 && !rWall)
            {
                playerRenderer.flipX = false;
                direction = 1;
            }
            else if (Input.GetAxis("Horizontal") < 0 && !lWall)
            {

                playerRenderer.flipX = true;
                direction = -1;
            }
            else { direction = 0; }

        }
        else { direction = 0; }
        targetVelocity = new Vector2(direction * speed, playerRb.velocity.y);
        jump = jump || Input.GetKeyDown(KeyCode.Space);


    }


    private void FixedUpdate()
    {

        playerRb.velocity = Vector2.SmoothDamp(playerRb.velocity,targetVelocity,ref dampVelocity,smoothTime);
        if (jump) { Jump(); }
        //clamp();
    }
    public void setGrounded(bool g) {
        grounded = g;
        walls.Clear();
    }

    private void clamp() {
        if (playerRb.velocity.x > maxVel) {
            playerRb.velocity = new Vector2(maxVel, playerRb.velocity.y);
        }
        else if (playerRb.velocity.x < -maxVel)
        {
            playerRb.velocity = new Vector2(-maxVel, playerRb.velocity.y);
        }
    }
    public void Jump() {
        if (grounded)
        {
           
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
        jump = false;
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
