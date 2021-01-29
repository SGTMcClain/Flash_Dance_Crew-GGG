using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningScreen : MonoBehaviour
{
    public GameObject controlPanel;

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

    public void controls()
    {
        controlPanel.SetActive(!controlPanel.activeSelf);

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            controlPanel.SetActive(!controlPanel.activeSelf);

        }
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
