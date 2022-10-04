using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goku : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //get obj moving
        //Rigidbody2D rb2d = GetComponent<Rigidbody2D>();

        //rb2d.AddForce(new Vector2(1, 0), 
        //    ForceMode2D.Impulse);
        const float MinImpulseForce = 3f;
        const float MaxImpulseForce = 5f;

        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            direction * magnitude,
            ForceMode2D.Impulse);
    }

    /// <summary>
    /// Called on a collision
    /// </summary>
    /// <param name="col">collision info</param>
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Au!");
    }
}
