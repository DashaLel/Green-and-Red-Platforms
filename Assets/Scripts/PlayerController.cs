using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    private Animator animator;
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




    }

  
    }
