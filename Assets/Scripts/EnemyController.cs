using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float speed = 4f;
    float dirX = -1f;
    Rigidbody2D rb;
    bool facingRight = false;
    Vector3 localScale;

    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;
        speed = 4f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Walls")
        {
            dirX *= -1f;
        }
    }

    void Update()
    {
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
        if(dirX > 0)
        {
            facingRight = true;
        }
        else if(dirX < 0)
        {
            facingRight = false;
        }
        if( (facingRight && (localScale.x < 0)) || (!facingRight && (localScale.x >0)))
        {
            localScale.x *=-1;
        }

        transform.localScale = localScale;
    }
}
