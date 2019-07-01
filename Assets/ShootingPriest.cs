using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPriest : MonoBehaviour
{
    public float health;
    public Rigidbody2D rb;
    public float speed;
    public int maxSteps;
    public bool immuneToIce;

    public bool facingRight = false;
    private int stepCount = 0;


    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void takeDamage(float damage)
    {

        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
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
