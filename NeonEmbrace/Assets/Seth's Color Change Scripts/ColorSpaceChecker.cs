using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Written By Seth DeZwart
 * ***GOES ON THE COLORED OBJECT THAT CHECKS FOR SPACE***
 * Tracks all of the collision and changes colors
 */

public class ColorSpaceChecker : MonoBehaviour, IColorable
{
    public bool check = true;
    private bool playerInArea;
    public Colors myColors;

    public Collider2D myCollider;
    public SpriteRenderer mySprite;
    private void Awake()
    {
        myCollider = GetComponent<BoxCollider2D>();
        mySprite = GetComponent<SpriteRenderer>();
    }

    // Tracks if the player is in the way of spawning the object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("player entered");
            playerInArea = true;
        }
    }

    // Tracks if the player is clear of the spawning object
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInArea = false;
        }
    }

    // Turns the color tile off
    public void ColorSwapOff()
    {
        if(check)
        {
            mySprite.enabled = false;
            myCollider.isTrigger = true;
        }
        else
        {
            mySprite.enabled = false;
        }
    }

    // Turns the color tile on
    public void ColorSwapOn()
    {
        if (!playerInArea && check)
        {
            mySprite.enabled = true;
            myCollider.isTrigger = false;
        }
        else
        {
            mySprite.enabled = true;
        }
    }

    public bool PlayerInArea
    {
        get
        {
            return playerInArea;
        }
    }
}
