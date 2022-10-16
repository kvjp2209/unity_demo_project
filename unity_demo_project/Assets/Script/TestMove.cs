using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    private void Awake()
    {
        //references for rigid and animator
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y); 

        //FlipTool player when moving
        if(horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(2,2,2);
        } else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }

        if(Input.GetKey(KeyCode.UpArrow) && grounded)
            Jump(); 

        anim.SetBool("Run", horizontalInput != 0); 
        anim.SetBool("Grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed * 1.5f);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            grounded = true;
    }
}
