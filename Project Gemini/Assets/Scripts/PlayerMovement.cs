using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class PlayerMovement : MonoBehaviour
{
    public int health;
    //we need a reference to our Rigidbody to move the player w/ Unity's physics engine
    private Rigidbody2D _rigid;

    //jumpForce = height of jump
    public float jumpForce;
    public float runSpeed;
    float horizontalInput;

    private bool facingRight = true;

    private Animator anim;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;

    public int ExtraJumpsValue;



    void Start()
    {

        extraJumps = ExtraJumpsValue;

        health = 100;


        _rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        //we need to take input from keyboard to move player left/right
        float horizontalInput = Input.GetAxisRaw("Horizontal") * runSpeed;
        _rigid.velocity = new Vector2(horizontalInput, _rigid.velocity.y);


        if (facingRight == false && horizontalInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && horizontalInput < 0)
        {
            Flip();
        }

        if (horizontalInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else 
        {
            anim.SetBool("isRunning", true);
        }
    }

    void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = 2;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            _rigid.velocity = Vector2.up * jumpForce;
            extraJumps--; //so player doesn't have unlimited jumps
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true) 
        {
            _rigid.velocity = Vector2.up * jumpForce;
        } 
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void GetHurt()
    {
        health -= 10;
        //Debug.Log("HEALTH: " + health);
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}