using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAnimation : MonoBehaviour
{
    public Animator anim;
    public PlayerMovement playerMovement;
    public int trapDamage;
    public bool playerOnTop;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerOnTop = true;
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("isActive", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerOnTop = false;
        anim.SetBool("isActive", false);

    }

    public void PlayerDamage()
    {
        if(playerOnTop)
        {
            playerMovement.healthPoints -= trapDamage;
        }

    }
}
