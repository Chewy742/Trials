using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : MonoBehaviour
{
    public float attackDamage;
    private Player player;
    private int attackAgain = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.GetComponent<Player>();
        if (player)
        {
            Attack(player);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        attackAgain++;
        player = collision.GetComponent<Player>();
        if (player)
        {
            if(attackAgain % 25 == 0)
            {
                Attack(player);
            }
        }
    }

    void Attack(Player player)
    {
        player.takeDamage(attackDamage);
    }


}
