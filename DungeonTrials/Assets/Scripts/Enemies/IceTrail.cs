using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTrail : MonoBehaviour
{
    public float damage = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            player.takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
