using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float distanceX, distanceY, fireRate = .25f, nextFire = 0;
    public PlayerMovement player;
    public GameObject projectile;
    public Transform target;
    public BoxCollider2D collider;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        target = GameObject.Find("Player").GetComponent<Transform>();
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    private void CheckDistance()
    {
        if(target != null)
        {
            distanceX = (target.transform.position.x - transform.position.x);
            distanceY = (target.transform.position.y - transform.position.y);

            if(distanceX < 7f && distanceX > -7f && distanceY < 1f && distanceY > -1f)
            {
                FireProjectile();
            }
        }
    }

    void FireProjectile()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;

        }
    }
}
