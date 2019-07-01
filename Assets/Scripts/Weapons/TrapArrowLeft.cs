using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


/*
 * 
 * REDUNDANT-ROTATE TRAPS
 * 
 */

public class TrapArrowLeft : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public float damage = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb.transform.Rotate(0, 0, -90);
        rb.velocity = -transform.up * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            player.takeDamage(damage);
            Destroy(gameObject);
        }

        Collectable collectable = collision.GetComponent<Collectable>();
        EnemySkeleton enemy = collision.GetComponent<EnemySkeleton>();

        Tilemap tilemap = collision.GetComponent<Tilemap>();
        if (tilemap)
        {
            Destroy(gameObject);
        }
    }
}
