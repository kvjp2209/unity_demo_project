using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid;
    float force = 3;
    float gravityScale = 2;
    float fallGravityScale = 10;
    bool leftFacing = true;
    Vector2 localScale;

    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void GoLeft(float force)
    {
        Vector2 v = new Vector2(-0.2f, 0);
        rigid.AddForce(v * force, ForceMode2D.Impulse);
    }

    void GoRight(float force)
    {
        Vector2 v = new Vector2(0.2f, 0);
        rigid.AddForce(v * force, ForceMode2D.Impulse);
    }

    void Jump(float force)
    {
        Vector2 v = new Vector2(0, 1);
        rigid.AddForce(v * force, ForceMode2D.Impulse);
    }

    void Facing()
    {
        localScale = transform.localScale;
        localScale.x *= -1;
        this.gameObject.transform.localScale = localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 localScale = transform.localScale;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Jump(0.1f);
        } else if (Input.GetKey(KeyCode.DownArrow))
        {
            Facing();
        }
         else if (Input.GetKey(KeyCode.RightArrow))
        {
            GoRight(0.5f);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            GoLeft(0.2f);
        }

        if (rigid.velocity.y >= 0)
            rigid.gravityScale = gravityScale;
        else
            rigid.gravityScale = fallGravityScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gameObject = collision.gameObject;
        Debug.Log("Va cham " + gameObject.name);
    }

    
}
