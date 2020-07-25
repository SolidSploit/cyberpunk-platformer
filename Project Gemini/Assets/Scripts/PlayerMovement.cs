using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //we need a reference to our Rigidbody to move the player w/ Unity's physics engine
    private Rigidbody2D _rigid;
    //when moving the player we need to know at which speed we want to move it
    private float runSpeed = 10f;
    float horizontalInput = 0f;
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //we need to take input from keyboard to move player
        float horizontalInput = Input.GetAxisRaw("Horizontal") * runSpeed;

        _rigid.velocity = new Vector2(horizontalInput, _rigid.velocity.y);
    }
}