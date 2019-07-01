﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TrapArrowDown : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public float damage = 5f;

    // Start is called before the first frame update
    void Start()
    {
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
