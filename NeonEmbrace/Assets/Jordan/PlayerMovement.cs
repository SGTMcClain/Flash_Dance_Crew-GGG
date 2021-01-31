using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private LayerMask platformLayer;
    private Transform myMove;
    private Rigidbody2D rb;
    private bool canJump;
    public int jumpHeight = 20;
    public float speed = 10;
    float moveDir;
    private SceneManager LoadThis;
    private CapsuleCollider2D CC;
    // Start is called before the first frame update
   void Start()
    {
        myMove = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        CC = GetComponent<CapsuleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        CanJump();
       moveDir = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(speed * moveDir, rb.velocity.y);
        if (CanJump() && Input.GetKeyDown("space"))
        {
               rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                canJump = false;
            
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
       // canJump = true;
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
    public bool CanJump()
    {
       
      RaycastHit2D hit =  Physics2D.Raycast(CC.bounds.center, Vector2.down, CC.bounds.extents.y + .01f,platformLayer);
        Color rayColor = Color.green;
      
        return hit.collider != null;
      
        //else
        //  canJump = false;
    }
}
