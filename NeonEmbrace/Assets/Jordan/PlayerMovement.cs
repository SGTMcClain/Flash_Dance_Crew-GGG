using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform myMove;
    private Rigidbody2D rb;
    private bool canJump;
    public int jumpHeight = 20;
    public float speed = 10;
    float moveDir;
    private SceneManager LoadThis;
    // Start is called before the first frame update
   void Start()
    {
        myMove = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
     
       moveDir = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(speed * moveDir, rb.velocity.y);
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
    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Spikes")
        {
            Debug.Log("CollisionSpikes");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Spikes")
        {
            Debug.Log("TriggerSpikes");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
