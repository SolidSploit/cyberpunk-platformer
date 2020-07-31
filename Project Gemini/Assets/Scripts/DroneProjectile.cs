using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneProjectile : MonoBehaviour
{

    private PlayerMovement player;
    private Rigidbody2D rb;
    private BoxCollider2D collider;
    private Transform target;
    private int speed;
    public Vector2 moveDirection;
   
    void Start()
    {
        speed = 10;
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        target = GameObject.Find("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }

    private void Update()
    {
        if (transform.position.y < -10 || transform.position.y > 25 || transform.position.x < -20 || transform.position.x > 75)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.GetHurt();
            Destroy(this.gameObject);
        }
    }
}
