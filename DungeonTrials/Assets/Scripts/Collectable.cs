using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Collectable : MonoBehaviour
{
    public string typename;

    private void OnTriggerEnter2D(Collider2D collision){

        Player player = collision.GetComponent<Player>();

        //only interact if player is involved in the collision
        if (player) {
            Debug.Log("player");
            player.addCollectables(typename);

            Destroy(gameObject);

        }
    }
}
