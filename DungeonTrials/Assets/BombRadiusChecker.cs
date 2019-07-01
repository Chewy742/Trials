using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombRadiusChecker : MonoBehaviour
{
    public Bomb bomb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player pl = collision.GetComponent<Player>();
        if (pl)
        {
            Debug.Log("Player in Radius");
            bomb.playerInRadius = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player pl = collision.GetComponent<Player>();
        if (pl)
        {
            Debug.Log("Player out of radius");
            bomb.playerInRadius = false;
        }
    }
}
