using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    //create array of levels
    public Button[] levelButtons;

    // Start is called before the first frame update
    void Start()
    {
        //keeps track of what level we are on (starts at level 1)
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        //disable all buttons but level 1 to start
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }

        }


    }
    public void Select(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Debug.Log("8 pressed");
            //inable all buttons 
            for (int i = 0; i < levelButtons.Length; i++)
            {
                levelButtons[i].interactable = true;
            }
        }
    }

    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
