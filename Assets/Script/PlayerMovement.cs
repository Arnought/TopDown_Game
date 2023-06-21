using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 movementInput;
    public Rigidbody2D rigidbodyGO;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyGO = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.enabled = true;
            anim.SetTrigger("Backward");
            
        }
         if (Input.GetKeyUp(KeyCode.S))
        {
            anim.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.enabled = true;
            anim.SetTrigger("Forward");
        }
         if (Input.GetKeyUp(KeyCode.W))
        {
            anim.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.enabled = true;
            anim.SetTrigger("Right");
        }
         if (Input.GetKeyUp(KeyCode.D))
        {
            anim.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.enabled = true;
            anim.SetTrigger("Left");
        }
         if (Input.GetKeyUp(KeyCode.A))
        {
            anim.enabled = false;
        }


    }

    private void FixedUpdate()
    {
        rigidbodyGO.velocity = movementInput * moveSpeed;
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }


}
