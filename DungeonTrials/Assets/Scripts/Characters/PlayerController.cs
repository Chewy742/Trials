using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Rigidbody2D myBody;
    public bool facingRight = true;

    private void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    myBody.MovePosition(myBody.position + Vector2.left);
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    myBody.MovePosition(myBody.position + Vector2.right);
        //}
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    myBody.MovePosition(myBody.position + Vector2.up);
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    myBody.MovePosition(myBody.position + Vector2.down);
        //}



        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime *speed;

        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        //if you are facing right, about to move left
        if (horizontal < 0 && facingRight){ 
            facingRight = false;
            myBody.transform.Rotate(0f, 180f, 0f);
        }else if (horizontal > 0 && !facingRight){ //if you are facing left, about to move right
            facingRight = true;
            myBody.transform.Rotate(0f, 180f, 0f);
        }

        myBody.MovePosition(myBody.position + new Vector2(horizontal, vertical));
        /*
        if (horizontal < 0){
            myBody.MovePosition(myBody.position + new Vector2(-1, 0));
        }

        if(horizontal > 0){
            myBody.MovePosition(myBody.position + new Vector2(1, 0));
        }
        if(vertical < 0){
            myBody.MovePosition(myBody.position + new Vector2(0, -1));
        }
        if (vertical > 0)
        {
            myBody.MovePosition(myBody.position + new Vector2(0, 1));
        }
*/
    }
}
