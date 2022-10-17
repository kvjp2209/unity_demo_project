using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Attack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        // Play an attack animation
        animator.SetTrigger("Attack");

        // Detect ememies in range of attack
        Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damege them
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
