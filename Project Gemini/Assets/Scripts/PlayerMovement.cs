using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class PlayerMovement : MonoBehaviour
{
    public int health;
    //we need a reference to our Rigidbody to move the player w/ Unity's physics engine
    private Rigidbody2D _rigid;
    //when moving the player we need to know at which speed we want to move it
    private float runSpeed = 10f;
    float horizontalInput = 0f;


    void Start()
    {
        health = 100;
        _rigid = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        //we need to take input from keyboard to move player
        float horizontalInput = Input.GetAxisRaw("Horizontal") * runSpeed;

        _rigid.velocity = new Vector2(horizontalInput, _rigid.velocity.y);

        Debug.Log("PLAYER HEALTH: " + health);
    }

    public void GetHurt()
    {

        health -= 25;
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
        
    }
}