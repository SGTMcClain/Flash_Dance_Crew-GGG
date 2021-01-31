using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Written By Seth DeZwart
 * ***ATTACH TO PLAYER***
 * Controls to switch the active color. 
 */

public class ColorInteraction : MonoBehaviour
{
    public bool ownRed;
    public bool ownGreen;
    public bool ownBlue;
    public bool ownPink;

    public KeyCode Red = KeyCode.LeftArrow;
    public KeyCode Green = KeyCode.UpArrow;
    public KeyCode Blue = KeyCode.RightArrow;
    public KeyCode Pink = KeyCode.DownArrow;

    private bool makeCall; // ensures only one call will be made per update to the color manager by in the by the player
    public GameObject CM; // ColorManager GameObject
    private ColorManager colorManager; // ColorManager
    private Colors nextColor; // var for holding the color that will be called at the end of update if color change is requested

    private void Awake()
    {
        colorManager = CM.GetComponent<ColorManager>(); // gets the ColorManager for quick reference.
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Checks for ownership of color and if key was pressed.
        if(Input.GetKeyDown(Red) && ownRed)
        {
            nextColor = Colors.Red;
            makeCall = true; // ensures only one call will be made per update in the by the player
        }
        // Checks for ownership of color and if key was pressed.
        if (Input.GetKeyDown(Green) && ownGreen)
        {
            nextColor = Colors.Green;
            makeCall = true; // ensures only one call will be made per update in the by the player
        }
        // Checks for ownership of color and if key was pressed.
        if (Input.GetKeyDown(Blue) && ownBlue)
        {
            nextColor = Colors.Blue;
            makeCall = true; // ensures only one call will be made per update in the by the player
        }
        // Checks for ownership of color and if key was pressed.
        if (Input.GetKeyDown(Pink) && ownPink)
        {
            nextColor = Colors.Pink;
            makeCall = true; // ensures only one call will be made per update in the by the player
        }
        // Makes call to the colormanager if a color key was pressed.
        if (makeCall)
        {
            colorManager.ColorChanger(nextColor);
            makeCall = false; // ensures only one call will be made per update in the by the player
        }
        
    }

    
}
