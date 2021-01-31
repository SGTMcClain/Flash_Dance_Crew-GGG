using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Level1Movement : MonoBehaviour
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
    public delegate void isJumping();
    public static event isJumping jumpHappen;
    public GameObject background;
    public SpriteRenderer BackSprite;
    // Start is called before the first frame update
   void Start()
    {
        myMove = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        CC = GetComponent<CapsuleCollider2D>();
        BackSprite = background.GetComponent<SpriteRenderer>();
        BackSprite.color = new Color(1f, 1f, 1f, .5f);
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
          //if (jumpHappen() != null)
            { jumpHappen(); }
        }
            if(Input.GetKeyUp("space"))
            {
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
            }
            }
    if(Input.GetKeyDown("left"))
        {
            BackSprite.color = new Color(1f, 0f, 0f, .3f);
        }
        if (Input.GetKeyDown("up"))
        {
            BackSprite.color = new Color(0f, 0f, 1f, .1f);
        }
        if (Input.GetKeyDown("down"))
        {
            BackSprite.color = new Color(1f, .01f, .6f, .1f);
        }
        if (Input.GetKeyDown("right"))
        {
            BackSprite.color = new Color(0f, 1f, 0f, .1f);
        }

    }
    void isJump()
    {
      // if(jumpHappen() != null)
        { jumpHappen(); }
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
        if (col.gameObject.name == "End")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public bool CanJump()
    {
       
      RaycastHit2D hit =  Physics2D.Raycast(CC.bounds.center, Vector2.down, CC.bounds.extents.y + .01f,platformLayer);
        Color rayColor = Color.green;
        if(hit.collider != null)
        { canJump = true; }
        return hit.collider != null;
      
        //else
        //  canJump = false;
    }
}
