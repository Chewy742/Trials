using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform exitPortal;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            Vector3 newPos = exitPortal.position;
            player.transform.position = new Vector3(newPos.x, newPos.y, 0);
        }
    }
}
