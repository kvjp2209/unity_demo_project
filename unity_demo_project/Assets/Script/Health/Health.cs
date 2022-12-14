using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    [SerializeField] private Object Object;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
            //iframe
        } else
        {
            if (!dead)
            {
                anim.SetTrigger("Die");
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<TestMove>().enabled = false;
                
                dead = true;
            }
        }
    }

    public void DamageEnemy(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
            //iframe
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("Die");
                GetComponent<Enemy>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                dead = true;
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
}
