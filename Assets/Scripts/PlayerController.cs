using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

    private ArrayList walls;
    private Collider2D wall;
   

    [Header("Velocity")]
    [SerializeField]float speed;
    [SerializeField] float smoothTime;
    int direction;

    [Header("Jump")]
    [SerializeField] float jumpForce = 200;
    bool jump;
    int jumps;

    [Header("Raycast")]
    [SerializeField] Transform groundCheck; //Punto origen del raycast
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float rayLenght;
    public bool grounded, lWall, rWall;

    private Rigidbody2D playerRb;
    Vector2 targetVelocity;
    Vector2 dampVelocity;


    private SpriteRenderer playerRenderer;
    Animator anim;
    public bool isDead;

    private float startX;
    private float startY;
  



    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        grounded = false;
        walls = new ArrayList();
        startX = this.transform.position.x;
        startY = this.transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead) {
            RaycastGrounded();
            InputUpdate();
            ChangeGravity();
            updateAnimations();
            

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
       
    }

    private void RaycastGrounded() {
        Debug.DrawRay(groundCheck.position, Vector2.down*rayLenght, Color.green);
        if (grounded != Physics2D.Raycast(groundCheck.position, Vector2.down, rayLenght, groundLayer)) {
            setGrounded(!grounded);
        }
    }

    public void setGrounded(bool g) {
        grounded = g;
        walls.Clear();
        jumps = 1;
    }

   
    public void Jump() {
        if (!grounded)
        {
            
             if (lWall && !checkWall())
            {
                playerRb.velocity = Vector2.zero;
                playerRb.AddForce((Vector2.up + Vector2.right) * jumpForce);

            }
            else if (rWall && !checkWall())
            {
                playerRb.velocity = Vector2.zero;
                playerRb.AddForce((Vector2.up - Vector2.right) * jumpForce);
            }
            else if ( jumps > 0)
            {
                playerRb.velocity = playerRb.velocity * Vector2.right;
                playerRb.AddForce(Vector2.up * jumpForce);

                jumps--;
            }
        }
        else {
            playerRb.velocity = playerRb.velocity * Vector2.right;
            playerRb.AddForce(Vector2.up * jumpForce);

            jumps--;
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
    private void updateAnimations()
    {
        if (direction != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        anim.SetBool("isJumping", !grounded);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            Debug.Log("cambio nivel");
            GameController.nextScreen();
        }
        else if (collision.tag == "Pit") {
            GameController.changePlayerLives(GameController.lives - 1);
            if (GameController.lives > 0) {
                this.transform.position = new Vector3(startX,startY,1);
            }
        
        }
        else if(collision.tag == "Respawn"){
            startX = collision.transform.position.x;
            startY = collision.transform.position.y;
        
        }
    }

    private void ChangeGravity() {
        if (playerRb.velocity.y < 0)
        {
            playerRb.gravityScale = 1.7f;
        }
        else {
            playerRb.gravityScale = 1;
        }
    }
}
