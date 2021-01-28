using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform myMove;
    private Rigidbody2D rb;
    private bool canJump;
    public int jumpHeight = 20;
    public float speed = .8f;
    // Start is called before the first frame update
   void Start()
    {
        myMove = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
                {
            myMove.transform.position = myMove.position + new Vector3(-speed,0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            myMove.transform.position = myMove.position + new Vector3(speed, 0);
        }
        if (Input.GetKey("space"))
        {
            if (canJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                canJump = false;
            }
        }
            if(Input.GetKeyUp("space"))
            {
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
            }
            }

        
    }
    public void JumpAgain()
    {
        canJump = true;
    }
}
