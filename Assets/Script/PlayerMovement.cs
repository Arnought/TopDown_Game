using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using TMPro;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 movementInput;
    public Rigidbody2D rigidbodyGO;
    public Animator anim;
    // Start is called before the first frame update
    public int coinCounter, healthPoints, speedPowerUpValue, duration;
    public TextMeshProUGUI healthcounter, coinsCounter;
    private float basemovespeed = 3;
    void Start()
    {
        rigidbodyGO = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
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
        }*/

        healthcounter.text = healthPoints.ToString();
        coinsCounter.text = coinCounter.ToString();

        anim.SetFloat("Horizontal", movementInput.x);
        anim.SetFloat("Vertical", movementInput.y);
        anim.SetFloat("Speed", movementInput.sqrMagnitude);
       
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Coins"))
        {
            coinCounter++;
            Destroy(collision.gameObject);
        }

        if(collision.CompareTag("health_pwr"))
        {
            healthPoints += 5;
            Destroy(collision.gameObject);
        }

        if(collision.CompareTag("spd_pwr"))
        {
            moveSpeed += speedPowerUpValue;
            Destroy(collision.gameObject);
            StartCoroutine(returnToBaseSpeed());
        }
    }

    IEnumerator returnToBaseSpeed()
    {
        yield return new WaitForSeconds(duration);
        moveSpeed = basemovespeed;
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
