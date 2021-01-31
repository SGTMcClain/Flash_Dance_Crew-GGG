using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Written By Seth DeZwart
 * ***ATTACH TO PLAYER***
 * Changes the color of the player
 */
public class ColorSwapPlayer : MonoBehaviour
{
    
    Colors activeColor;

    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Changes the color of the player by switching animaitions
    public void ColorSwap(Colors newColor)
    {
        activeColor = newColor;
        animator.SetBool("IsRed", false);
        animator.SetBool("IsGreen", false);
        animator.SetBool("IsBlue", false);
        animator.SetBool("IsPink", false);
        switch (newColor)
        {
            case Colors.Red:
                {
                    animator.SetBool("IsRed", true);
                    break;
                }
            case Colors.Green:
                {
                    animator.SetBool("IsGreen", true);
                    break;
                }
            case Colors.Blue:
                {
                    animator.SetBool("IsBlue", true);
                    break;
                }
            case Colors.Pink:
                {
                    animator.SetBool("IsPink", true);
                    break;
                }
        }

        // *** CODE UNDER CONSTRUCTION ***
    }

    private void ColorsOff(Colors activeColor)
    {
        
    }
}
