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
    public GameObject redStuff;
    public bool hasRed = false;
    public Animator animate;
    // Start is called before the first frame update
   void Start()
    {
        myMove = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        CC = GetComponent<CapsuleCollider2D>();
        BackSprite = background.GetComponent<SpriteRenderer>();
        BackSprite.color = new Color(1f, 1f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        CanJump();
       moveDir = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(speed * moveDir, rb.velocity.y);
        if(moveDir == 0 && !hasRed && rb.velocity.y == 0)
        {
            animate.Play("GreyRun");
        }
        if (moveDir == 0 && hasRed && rb.velocity.y == 0)
        {
            animate.Play("IdleAniRed");
        }
        if(moveDir != 0 && canJump && !hasRed)
        {
            animate.Play("GreyRun");
        }
        if (moveDir != 0 && canJump && hasRed)
        {
            animate.Play("RunAniRed");
        }


        if (CanJump() && Input.GetKeyDown("space"))
        {
            if (!hasRed && canJump)
            {
                animate.Play("GreyJump");
}

                     if (hasRed&& canJump)
                {
                animate.Play("JumpAniRed");
                    }
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                canJump = false;
          //if (jumpHappen() != null)
           // { jumpHappen(); }
        }
            if(Input.GetKeyUp("space"))
            {
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
             
                       
            }

            }
       //     if(rb.velocity.y < -.1 && !hasRed)
        {
         //   animate.Play("GreyFall");
        }
        if (rb.velocity.y < 0 && hasRed)
        {
            animate.Play("LandingAniRed");
        }

        if (hasRed)
        {
            BackSprite.color = new Color(1f, 0f, 0f, .3f);

        }

    }
    void isJump()
    {
      // if(jumpHappen() != null)
      //  { jumpHappen(); }
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
        if(col.gameObject.name== "RedAdd")
        {
            redStuff.gameObject.SetActive(true);
            Destroy(col.gameObject);
            hasRed = true;
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
