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
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger("Backward");
        }
         if (Input.GetKeyUp(KeyCode.S))
        {

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("Forward");
        }
         if (Input.GetKeyUp(KeyCode.W))
        {

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("Right");
        }
         if (Input.GetKeyUp(KeyCode.D))
        {

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("Left");
        }
         if (Input.GetKeyUp(KeyCode.A))
        {

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
