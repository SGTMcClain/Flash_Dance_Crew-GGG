using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCollect : MonoBehaviour
{
    public int Power;
    public ColorInteraction colorInterection;

    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.gameObject.tag == "Player")
        {
            colorInterection = Col.GetComponent<ColorInteraction>();
            switch (Power)
                { 
            case 1:
            colorInterection.ownRed = true;
                break;
             case 2:
            colorInterection.ownBlue = true;
                break;
             case 3:
            colorInterection.ownGreen = true;
                break;
             case 4:
            colorInterection.ownPink = true;
                break;
            }
            Destroy(gameObject);
        }
    }
}
