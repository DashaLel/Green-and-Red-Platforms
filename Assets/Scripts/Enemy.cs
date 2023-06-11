using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{

    public float moveSpeed = 1f;
    public float rotationSpeed = 3f;
    public float radius = 3f;
    private Vector3 centerPoint;
    private Vector3 targetPoint;
    public float attackDistance = 0.5f;
    public PlayerController player;
    private bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        centerPoint = transform.position;
        targetPoint = RandomPointInCircle();




    }

    // Update is called once per frame
    void Update()
    {
        
        
            if (Vector3.Distance(transform.position, targetPoint) < 0.1f )
            {

                targetPoint = RandomPointInCircle();

            }
        MoveToThePoint();
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
}




