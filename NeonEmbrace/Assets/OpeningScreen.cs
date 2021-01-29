using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningScreen : MonoBehaviour
{
    public void play(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void quitGame()
    {
        //end this game's life
        Debug.Log("gamequit...");
        Application.Quit();
    }


   /* // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
