using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{

    public float moveSpeed = 1f;
    public float rotationSpeed = 3f;
    public float radius = 5f;
    private Vector3 centerPoint;
    private Vector3 targetPoint;
    public float attackDistance = 0.5f;
    private bool isAttacking;
    public GameObject Player;
    private Rigidbody enemyRb;
    private Animator animator;
    private int HelthPoint = 100;
    public Slider healthBar;
    public Transform attackPoint;
    
    public float EnemyAttackRange;
    public int damageAmount;
    public LayerMask playerLayers;

    public int score;
    public Text scoreText;








    void Start()
    {
        score = 0;
        scoreText.text = "Убито врагов: " + score;

        enemyRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        targetPoint = RandomPointInCircle();


        Player = GameObject.FindGameObjectWithTag("Player");

    }


    void Update()
    {
        healthBar.value = HelthPoint;
        
        if (isAttacking == false)
        {

            if (Vector3.Distance(transform.position, targetPoint) < 0.1f)
            {

                targetPoint = RandomPointInCircle();

            }
            MoveToThePoint();



        }

        if (Vector3.Distance(transform.position, Player.transform.position) < attackDistance)
        {
            isAttacking = true;


        }

        if (isAttacking == true)
        {
            animator.SetTrigger("Attack");
            Vector3 lookDirection = (Player.transform.position - transform.position).normalized;
            

            Quaternion lookRotation = Quaternion.LookRotation(lookDirection);
            
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);
            

            Attack();
        }


    }


    

    private Vector3 RandomPointInCircle()
    {
        float angle = Random.Range(0f, Mathf.PI * 2f);
        float distance = Random.Range(0f, radius);
        Vector3 offset = new Vector3(Mathf.Cos(angle) * distance, 0f, Mathf.Sin(angle) * distance);
        return centerPoint + offset;
    }


    private void MoveToThePoint()
    {
       
        Vector3 direction = (targetPoint - transform.position).normalized;
        

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);
        
    }
    void Attack()
    {
        Collider[] hitPlayers = Physics.OverlapSphere(attackPoint.position, EnemyAttackRange, playerLayers);
        foreach (Collider player in hitPlayers)
        {
            player.GetComponent<PlayerAttack>().TakeDamage(damageAmount);
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, EnemyAttackRange);

    }

    public void PlayerTakeDamage(int damageAmount)
    {
        HelthPoint -= damageAmount;
        if (HelthPoint <= 0)
        {
            Destroy(gameObject);
            score++;
            scoreText.text = "Убито врагов: " + score;

        }

    }

}




