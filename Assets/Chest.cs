using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public float health = 5f;
    public Transform chestPos;
    public GameObject[] items = new GameObject[5];

    public void takeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        int i = 0;
        foreach (GameObject item in items)
        {
            if(i == 0)
            {
                Instantiate(item, chestPos.position, chestPos.rotation);
            }
            else if (i == 1)
            {
                Instantiate(item, chestPos.position + new Vector3(.75f, 0, 0), transform.rotation);
            }else if (i == 2)
            {
                Instantiate(item, chestPos.position + new Vector3(0, .75f, 0), transform.rotation);
            }else if (i == 3)
            {
                Instantiate(item, chestPos.position + new Vector3(-.75f, 0, 0), transform.rotation);
            }else if (i == 4){
                Instantiate(item, chestPos.position + new Vector3(0, -.75f, 0), transform.rotation);
            }
            else
            {

            }
            i++;
        }
    }
}
