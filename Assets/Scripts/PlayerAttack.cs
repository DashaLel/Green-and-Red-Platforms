using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public int damageAmount = 20;


    private bool isAttacking = false;
    private Animator animator;
    public float attackRange;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;
    public Slider healthBar;
    private int HealthPoint = 200;
    

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        healthBar.value = HealthPoint;
        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            isAttacking = true;
            animator.SetTrigger("Attack"); // Воспроизводим анимацию атаки
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;


        }
        isAttacking = false;
    }
    void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(damageAmount);
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    public void PlayerTakeDamage(int damageAmount)
    {
        HealthPoint -= damageAmount;
        if (HealthPoint <= 0)
        {
            Destroy(gameObject);

        }

    }
}
