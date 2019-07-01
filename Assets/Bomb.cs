using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public float lifeSpan;
    private float startTime;
    public bool playerInRadius;
    public int radiusDamage;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > startTime + lifeSpan)
        {
            Debug.Log("about to destroy bomb");
            if (playerInRadius)
            {

            }
            Destroy(gameObject);
        }
    }
}
