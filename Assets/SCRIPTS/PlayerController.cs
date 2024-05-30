using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator Player_animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float speed = 5f;
    [SerializeField] public float jumpForce = 10f; // Force de saut du personnage
    [SerializeField] public float dashForce = 20f; // Force de dash du personnage
    [SerializeField] public float groundCheckDistance = 0.1f; // Distance de vérification du sol
    [SerializeField] public LayerMask groundLayer; // Layer du sol
    [SerializeField] public Rigidbody2D rb; // Rigidbody2D du personnage
    [SerializeField] public int memoryStele = 0;
    [SerializeField] public int memorySkull = 0;
    [SerializeField] public int memoryTech = 0;
    [SerializeField] public bool endGame = false;
    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (IsGrounded())
        {
            Player_animator.SetBool("BoolJump", false);
        }

        else if (!IsGrounded() && !Player_animator.GetBool("BoolJump"))
        {
            Player_animator.SetBool("BoolWalk", false);
            Player_animator.SetBool("BoolJump", true);
        }

        Player_animator.SetFloat("YVelocity", rb.velocity.y);

        Move();

        Jump();

    }


    void Jump()
    {

        // Si le personnage est au sol et la barre d'espace est pressée, effectuer un saut
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            Player_animator.SetBool("BoolJump", true);
            Player_animator.SetBool("BoolWalk", false); // stop run animation
            // Ajouter une force vers le haut pour effectuer un saut
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow)) // when right arrow
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);  // movement to the right
            if(IsGrounded())
            {
                Player_animator.SetBool("BoolJump", false);
                Player_animator.SetBool("BoolWalk", true); // run animation
            }
            spriteRenderer.flipX = false; // sprite not flipped
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Player_animator.SetBool("BoolWalk", false); // stop run animation
        }

        if (Input.GetKey(KeyCode.LeftArrow)) // when left arrow
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);  // movement to the left
            if (IsGrounded())
            {
                Player_animator.SetBool("BoolJump", false);
                Player_animator.SetBool("BoolWalk", true); // run animation
            }
            spriteRenderer.flipX = true; // sprite flip
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Player_animator.SetBool("BoolWalk", false); // stop run animation
        }

    }

    bool IsGrounded()
    {
        return rb.velocity.y == 0;
    }

    public void IncreaseSteleMemory()
    {
        memoryStele++;
    }

    public void IncreaseSkullMemory()
    {
        memorySkull++;
    }
    public void IncreaseTechMemory()
    {
        memoryTech++;
    }

}
