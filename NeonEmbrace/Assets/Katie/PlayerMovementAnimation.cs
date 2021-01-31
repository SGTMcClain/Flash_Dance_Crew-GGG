using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAnimation : MonoBehaviour
{
    Animator animator;
    SpriteRenderer sprite;
    float hor;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        if (hor < -0.01)
        {
            sprite.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }
        else if (hor > 0.01)
        {
            sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
        animator.SetFloat("Movement", Mathf.Abs(hor));
    }
}
