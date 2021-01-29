using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Written By Seth DeZwart
 * ***GOES ON THE COLORED OBJECT THAT CHECKS FOR SPACE***
 * Tracks all of the collision
 */

public class ColorSpaceChecker : MonoBehaviour, IColorable
{
    public bool playerInArea;
    public Colors myColors;

    public Collider2D myCollider;
    public SpriteRenderer mySprite;
    private void Awake()
    {
        myCollider = GetComponent<BoxCollider2D>();
        mySprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("player entered");
            playerInArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInArea = false;
        }
    }

    public void ColorSwapOff()
    {
        mySprite.enabled = false;
        myCollider.isTrigger = true;
    }

    public void ColorSwapOn()
    {
        if (!playerInArea)
        {
            mySprite.enabled = true;
            myCollider.isTrigger = false;
        }
    }
}
