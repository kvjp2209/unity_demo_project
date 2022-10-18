using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    [SerializeField] private float speed;

    // Update is called once per frame
    void Start()
    {
        currentHealth = maxHealth;
        animator.SetBool("IsRuning", true);
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");
        //play hurt animation
        if(currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Debug.Log("Enemy died!");
        animator.SetBool("IsDead", true);
        
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }
}
