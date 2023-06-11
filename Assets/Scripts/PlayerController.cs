using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    public Animator animator;
    public Joystick joystick;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = joystick.Horizontal;
        float verticallInput = joystick.Vertical;
        Vector3 directionVector = new Vector3(horizontalInput, 0, verticallInput);
        animator.SetFloat("speed", Vector3.ClampMagnitude(directionVector, 1).magnitude);

        rb.velocity = Vector3.ClampMagnitude(directionVector, 1) * speed;

        

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }




    }
    private void OnTriggerEnter(Collider other)
    {
        speed = speed * -1;
    }


}
