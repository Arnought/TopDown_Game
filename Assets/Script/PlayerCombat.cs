using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public float attackRange = 0.5f;
    public int attackDamage = 90;
    public LayerMask enemyLayers;
    public Transform attackpoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Attack();
        }
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

     private void OnDrawGizmosSelected() 
     {
        if(attackpoint == null)
        return;

        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
     }
}
