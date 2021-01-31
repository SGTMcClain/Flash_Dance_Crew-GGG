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
    public Colors activeColor;

    GameObject player;
    ColorSwapPlayer csp;
    [SerializeField]
    List<GameObject> colorObjects = new List<GameObject>();

    List<ColorBGChanger> backgrounds = new List<ColorBGChanger>();

    List<ColorSpaceChecker> redObjects = new List<ColorSpaceChecker>();
    List<ColorSpaceChecker> greenObjects = new List<ColorSpaceChecker>();
    List<ColorSpaceChecker> blueObjects = new List<ColorSpaceChecker>();
    List<ColorSpaceChecker> pinkObjects = new List<ColorSpaceChecker>();
    

    private void Awake()
    {
        foreach(GameObject obj in colorObjects)
        {
            Sort(obj.GetComponent<ColorSpaceChecker>());
        }

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Background"))
        {
            backgrounds.Add(obj.GetComponent<ColorBGChanger>());
        }

        Debug.Log(backgrounds.Count);
    }

    // Sets the active color for the start of the level
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        csp = player.GetComponentInChildren<ColorSwapPlayer>();
        if(activeColor == Colors.Pink)
        {
            ColorChanger(activeColor - 1);
            ColorChanger(activeColor + 1);
        }
        else
        {
            ColorChanger(activeColor + 1);
            ColorChanger(activeColor - 1);
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
                        // Check if switch is blocked
                        if (redObjects.Count == 0)
                        {
                            return;
                        }

                        foreach (ColorSpaceChecker obj in redObjects)
                        {
                            if(obj.PlayerInArea && obj.check)
                            {
                                return;
                            }
                        }

                        // If Clear make switch.
                        activeColor = Colors.Red;
                        Debug.Log(activeColor);
                        ColorSwapAllOff();
                        if (player != null)
                        {
                            csp.ColorSwap(activeColor);
                        }
                        foreach (ColorSpaceChecker obj in redObjects)
                        {
                            obj.ColorSwapOn();
                        }
                        BackgroundChange();
                        break;
                    }
                case Colors.Green:
                    {
                        // Check if switch is blocked
                        if (greenObjects.Count == 0)
                        {
                            return;
                        }
                        foreach (ColorSpaceChecker obj in greenObjects)
                        {
                            if (obj.PlayerInArea && obj.check)
                            {
                                return;
                            }
                        }

                        // If Clear make switch.
                        activeColor = Colors.Green;
                        Debug.Log(activeColor);
                        ColorSwapAllOff();
                        if(player != null)
                        {
                            csp.ColorSwap(activeColor);
                        }
                        foreach (ColorSpaceChecker obj in greenObjects)
                        {
                            obj.ColorSwapOn();
                        }
                        BackgroundChange();
                        break;
                    }
                case Colors.Blue:
                    {
                        // Check if switch is blocked
                        if (blueObjects.Count == 0)
                        {
                            return;
                        }
                        foreach (ColorSpaceChecker obj in blueObjects)
                        {
                            if (obj.PlayerInArea && obj.check)
                            {
                                return;
                            }
                        }

                        // If Clear make switch.
                        activeColor = Colors.Blue;
                        Debug.Log(activeColor);
                        ColorSwapAllOff();
                        if (player != null)
                        {
                            csp.ColorSwap(activeColor);
                        }
                        foreach (ColorSpaceChecker obj in blueObjects)
                        {
                            obj.ColorSwapOn();
                        }
                        BackgroundChange();
                        break;
                    }
                case Colors.Pink:
                    {
                        // Check if switch is blocked
                        if(pinkObjects.Count == 0)
                        {
                            return;
                        }
                        foreach (ColorSpaceChecker obj in pinkObjects)
                        {
                            if (obj.PlayerInArea && obj.check)
                            {
                                return;
                            }
                        }

                        // If Clear make switch.
                        activeColor = Colors.Pink;
                        Debug.Log(activeColor);
                        ColorSwapAllOff();
                        if (player != null)
                        {
                            csp.ColorSwap(activeColor);
                        }
                        csp.ColorSwap(activeColor);
                        foreach (ColorSpaceChecker obj in pinkObjects)
                        {
                            obj.ColorSwapOn();
                        }
                        BackgroundChange();
                        break;
                    }
            }
        }
    }

    // This turns off a single color
    private void ColorSwapOff(Colors colors)
    {
        switch (colors)
        {
            case Colors.Red:
                {
                    foreach (ColorSpaceChecker obj in redObjects)
                    {
                        obj.ColorSwapOff();
                    }
                    break;
                }
            case Colors.Green:
                {
                    foreach (ColorSpaceChecker obj in greenObjects)
                    {
                        obj.ColorSwapOff();
                    }
                    break;
                }
            case Colors.Blue:
                {
                    foreach (ColorSpaceChecker obj in blueObjects)
                    {
                        obj.ColorSwapOff();
                    }
                    break;
                }
            case Colors.Pink:
                {
                    foreach (ColorSpaceChecker obj in pinkObjects)
                    {
                        obj.ColorSwapOff();
                    }
                    break;
                }
        }
    }

    // Turns off all colors but one.
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

    // Sorts an object into it's color set
    private void Sort(ColorSpaceChecker colors)
    {
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

    void BackgroundChange()
    {
        /*
         foreach (ColorBGChanger bg in backgrounds)
        {
            bg.ColorShift(Colors.Red);
        }
        */
    }
}
