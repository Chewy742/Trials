using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    public float health;
    public Rigidbody2D rb;
    public float speed;
    public int maxSteps;
    public bool startDown;
    public float damage;

    public Transform trailingPoint;
    public GameObject iceTrailLeft;
    public GameObject iceTrailRight;

    private bool facingRight = false;
    private int stepCount = 0;

    public void Start()
    {
        if (startDown)
            facingRight = true;

        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            player.takeDamage(damage);
        }
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
        if (facingRight)
        {
            Instantiate(iceTrailLeft, trailingPoint.position, trailingPoint.rotation);
        }
        else
        {
            Instantiate(iceTrailRight, trailingPoint.position, trailingPoint.rotation);
        }

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
            trailingPoint.transform.Rotate(0, 0, 180);
        }

        if (!facingRight && stepCount == (maxSteps * -1))
        {
            rb.transform.Rotate(0, 180, 0);
            facingRight = !facingRight;
            trailingPoint.transform.Rotate(0, 0, 180);
        }

        //movement

        if (facingRight)
        {
            rb.MovePosition(rb.position + new Vector2(0, Time.deltaTime * speed));
            stepCount++;
        }
        else
        {
            rb.MovePosition(rb.position + new Vector2(0, Time.deltaTime * speed * -1));
            stepCount--;
        }


    }
}
