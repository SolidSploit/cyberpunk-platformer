using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public GameObject projectile;
    public PlayerMovement player;
    public float speed, distanceX, distanceY, fireRate = .75f, nextFire = 0f; 
    public Rigidbody2D rb;
    public PolygonCollider2D collider;
    private Transform target;


    void Start()
    {
        speed = 5f;
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<PolygonCollider2D>();
        target = GameObject.Find("Player").GetComponent<Transform>();
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    
    void Update()
    {
        CheckDistance();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "Player")
        {
            player.GetHurt();
        }
       else if(collision.tag == "Projectile")
        {
            //Destroy(this.Gameobject);
        }
    }

    public void FollowPlayer()
    {
        if(target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void CheckDistance()
    {
        if(target != null)
        {
            distanceX = (target.transform.position.x - transform.position.x);
            distanceY = (target.transform.position.y - transform.position.y);

            if (distanceX > 3f || distanceX < -3f)
            {
                FollowPlayer();
            }
            else if (distanceY > 3f || distanceY < -3f)
            {
                FollowPlayer();
            }
            else
            {
                FireProjectile();
            }
        }
    }

    void FireProjectile()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;

        }
    }
}
