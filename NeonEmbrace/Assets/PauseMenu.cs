using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //when the esc key is pressed pause the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        //sets the pause menu to active/inactive
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            //freeze game time
            Time.timeScale = 0f;
        }
        else
        {
            //continue game if unpaused
            Time.timeScale = 1f;
        }
    }

    //buttons 
    public void LevelSelect(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void quitGame(string quitButton)
    {
        //end this game's life
        Debug.Log("gamequit...");
        Application.Quit();
    }
}
