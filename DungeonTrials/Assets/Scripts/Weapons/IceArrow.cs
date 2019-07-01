using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IceArrow : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public float damage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
         * Enemy Collisions
         * 
         */

        //Enemy enemy = collision.GetComponent<Enemy>();
        //if (enemy)
        //{
        //    enemy.takeDamage(damage);
        //}

        EnemySkeleton enemy = collision.GetComponent<EnemySkeleton>();
        if (enemy){
            enemy.takeDamage(damage);
            Destroy(gameObject);
        }
        Ghost flyingGhost = collision.GetComponent<Ghost>();
        if (flyingGhost)
        {
            flyingGhost.takeDamage(damage);
            Destroy(gameObject);
        }
        Chest chest = collision.GetComponent<Chest>();
        if (chest)
        {
            chest.takeDamage(damage);
            Destroy(gameObject);
        }

        Debug.Log(collision.name);


        /*
         * Tilemap collision- arrow destroyed
         */

        Tilemap tilemap = collision.GetComponent<Tilemap>();
        if (tilemap)
        {
            Destroy(gameObject);
        }

    }
}
