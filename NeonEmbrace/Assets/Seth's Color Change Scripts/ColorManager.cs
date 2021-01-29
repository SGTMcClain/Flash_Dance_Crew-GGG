using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Written By Seth DeZwart
 * ***GOES ON COLOR MANAGER***
 * Makes the calls to all objects that need to switch.
 * Tracks Current Color
 */
public class ColorManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> colorObjects = new List<GameObject>();

    List<ColorSpaceChecker> redObjects = new List<ColorSpaceChecker>();
    List<ColorSpaceChecker> greenObjects = new List<ColorSpaceChecker>();
    List<ColorSpaceChecker> blueObjects = new List<ColorSpaceChecker>();
    List<ColorSpaceChecker> pinkObjects = new List<ColorSpaceChecker>();

    Colors activeColor;

    private void Awake()
    {
        ColorSpaceChecker colors;
        foreach(GameObject obj in colorObjects)
        {
            colors = obj.GetComponent<ColorSpaceChecker>();
            switch (colors.myColors)
            {
                case Colors.Red:
                    {
                        redObjects.Add(colors);
                        break;
                    }
                case Colors.Green:
                    {
                        greenObjects.Add(colors);
                        break;
                    }
                case Colors.Blue:
                    {
                        blueObjects.Add(colors);
                        break;
                    }
                case Colors.Pink:
                    {
                        pinkObjects.Add(colors);
                        break;
                    }
            }
        }
    }

    // Main color change block
    public void ColorChanger(Colors newColors)
    {
        if(activeColor != newColors)
        {
            switch (newColors)
            {
                case Colors.Red:
                    {
                        // * Check if switch is blocked
                        if (redObjects.Count == 0)
                        {
                            return;
                        }
                        foreach (ColorSpaceChecker obj in redObjects)
                        {
                            if(obj.playerInArea)
                            {
                                return;
                            }
                        }

                        // * If Clear make switch. If not clear break.
                        activeColor = Colors.Red;
                        Debug.Log(activeColor);
                        foreach (ColorSpaceChecker obj in redObjects)
                        {
                            ColorSwapAllOff();
                            obj.ColorSwapOn();
                        }
                        break;
                    }
                case Colors.Green:
                    {
                        // * Check if switch is blocked
                        if (greenObjects.Count == 0)
                        {
                            return;
                        }
                        foreach (ColorSpaceChecker obj in greenObjects)
                        {
                            if (obj.playerInArea)
                            {
                                return;
                            }
                        }

                        // * If Clear make switch. If not clear break.
                        activeColor = Colors.Green;
                        Debug.Log(activeColor);
                        foreach (ColorSpaceChecker obj in greenObjects)
                        {
                            ColorSwapAllOff();
                            obj.ColorSwapOn();
                        }
                        break;
                    }
                case Colors.Blue:
                    {
                        // * Check if switch is blocked
                        if (blueObjects.Count == 0)
                        {
                            return;
                        }
                        foreach (ColorSpaceChecker obj in blueObjects)
                        {
                            if (obj.playerInArea)
                            {
                                return;
                            }
                        }

                        // * If Clear make switch. If not clear break.
                        activeColor = Colors.Blue;
                        ColorSwapAllOff();
                        foreach (ColorSpaceChecker obj in blueObjects)
                        {
                            obj.ColorSwapOn();
                        }
                        Debug.Log(activeColor);
                        break;
                    }
                case Colors.Pink:
                    {
                        // * Check if switch is blocked
                        if(pinkObjects.Count == 0)
                        {
                            return;
                        }
                        foreach (ColorSpaceChecker obj in pinkObjects)
                        {
                            if (obj.playerInArea)
                            {
                                return;
                            }
                        }

                        // * If Clear make switch. If not clear break.
                        activeColor = Colors.Pink;
                        ColorSwapAllOff();
                        foreach (ColorSpaceChecker obj in pinkObjects)
                        {
                            obj.ColorSwapOn();
                        }
                        Debug.Log(activeColor);
                        break;
                    }
            }
        }
    }

    private void ColorSwapOff(Colors colors)
    {
        switch (colors)
        {
            case Colors.Red:
                {
                    foreach (ColorSpaceChecker obj in redObjects)
                    {
                        obj.myCollider.isTrigger = true;
                        obj.mySprite.enabled = false;
                    }
                    break;
                }
            case Colors.Green:
                {
                    foreach (ColorSpaceChecker obj in greenObjects)
                    {
                        obj.myCollider.isTrigger = true;
                        obj.mySprite.enabled = false;
                    }
                    break;
                }
            case Colors.Blue:
                {
                    foreach (ColorSpaceChecker obj in blueObjects)
                    {
                        obj.myCollider.isTrigger = true;
                        obj.mySprite.enabled = false;
                    }
                    break;
                }
            case Colors.Pink:
                {
                    foreach (ColorSpaceChecker obj in pinkObjects)
                    {
                        obj.myCollider.isTrigger = true;
                        obj.mySprite.enabled = false;
                    }
                    break;
                }
        }
    }

    private void ColorSwapAllOff()
    {
        switch (activeColor)
        {
            case Colors.Red:
                {
                    foreach (ColorSpaceChecker obj in greenObjects)
                    {
                        obj.ColorSwapOff();
                    }
                    foreach (ColorSpaceChecker obj in blueObjects)
                    {
                        obj.ColorSwapOff();
                    }
                    foreach (ColorSpaceChecker obj in pinkObjects)
                    {
                        obj.ColorSwapOff();
                    }
                    break;
                }
            case Colors.Green:
                {
                    foreach (ColorSpaceChecker obj in redObjects)
                    {
                        obj.ColorSwapOff();
                    }
                    foreach (ColorSpaceChecker obj in blueObjects)
                    {
                        obj.ColorSwapOff();
                    }
                    foreach (ColorSpaceChecker obj in pinkObjects)
                    {
                        obj.ColorSwapOff();
                    }
                    break;
                }
            case Colors.Blue:
                {
                    foreach (ColorSpaceChecker obj in redObjects)
                    {
                        obj.ColorSwapOff();
                    }
                    foreach (ColorSpaceChecker obj in greenObjects)
                    {
                        obj.ColorSwapOff();
                    }
                    foreach (ColorSpaceChecker obj in pinkObjects)
                    {
                        obj.ColorSwapOff();
                    }
                    break;
                }
            case Colors.Pink:
                {
                    foreach (ColorSpaceChecker obj in redObjects)
                    {
                        obj.ColorSwapOff();
                    }
                    foreach (ColorSpaceChecker obj in greenObjects)
                    {
                        obj.ColorSwapOff();
                    }
                    foreach (ColorSpaceChecker obj in blueObjects)
                    {
                        obj.ColorSwapOff();
                    }
                    break;
                }
        }
    }  
}
