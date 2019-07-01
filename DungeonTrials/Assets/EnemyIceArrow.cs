using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyIceArrow : MonoBehaviour
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
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            player.takeDamage(damage);
            Destroy(gameObject);
        }
        Tilemap tilemap = collision.GetComponent<Tilemap>();
        if (tilemap)
        {
            Destroy(gameObject);
        }

    }
}
