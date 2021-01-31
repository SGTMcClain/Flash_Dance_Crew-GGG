using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedActivate : MonoBehaviour
{
    public GameObject platforms;
    // Start is called before the first frame update
   

    // Update is called once per frame
   public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
          
            platforms.SetActive(true);
            Destroy(gameObject);
        }
    }
}
