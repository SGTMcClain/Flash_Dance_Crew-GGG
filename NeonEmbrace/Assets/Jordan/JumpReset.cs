using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpReset : MonoBehaviour
{
    // Start is called before the first frame update
   public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.GetComponent<PlayerMovement>())
        { col.gameObject.GetComponent<PlayerMovement>().JumpAgain(); }
    }
}
