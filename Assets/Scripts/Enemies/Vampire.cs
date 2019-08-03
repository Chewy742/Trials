using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire : MonoBehaviour
{
    public float health;
    public Rigidbody2D rb;
    public float speed;
    public int maxSteps;
    public bool immuneToIce;

    public GameObject bomb;
    public float bombDropRate;

    public bool facingRight = false;
    private int stepCount = 0;
    private bool inFrenzy;


    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("layBomb", 0f, bombDropRate);
    }

    public void layBomb()
    {
        Instantiate(bomb, rb.transform.position, rb.transform.rotation);
    }

    public void takeDamage(float damage)
    {
        
        health -= damage;
        if(health <= health / 2)
        {
            inFrenzy = true;
            startFrenzy();
        }

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void startFrenzy()
    {
        speed = speed * 3;
    }

    private void FixedUpdate()
    {

        Vector2 move = new Vector2(Time.deltaTime * speed, 0);

        //flipping body
        if (facingRight && stepCount == maxSteps)
        {
            rb.transform.Rotate(0, 180, 0);
            facingRight = !facingRight;
        }

        if (!facingRight && stepCount == (maxSteps * -1))
        {
            rb.transform.Rotate(0, 180, 0);
            facingRight = !facingRight;
        }

        //movement

        if (facingRight)
        {
            rb.MovePosition(rb.position + new Vector2(Time.deltaTime * speed, 0));
            stepCount++;
        }
        else
        {
            rb.MovePosition(rb.position + new Vector2(Time.deltaTime * speed * -1, 0));
            stepCount--;
        }


    }
}
