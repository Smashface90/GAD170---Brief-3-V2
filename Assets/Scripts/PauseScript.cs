//Evan Waters 1017144 T1 GAD 170

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    //shown in inspector 
    [Header("Pause Menu")]
    public GameObject pauseMenu;
    public bool paused;
    public bool menuDisabled =false;

    // Start is called before the first frame update
    void Start()
    {
        //turns cursor and pause menu off at start
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        PauseFunction();
    }

    void PauseFunction()
   {

        if (menuDisabled)
        {
            return;
        }
        //if ESC is pressed, do the following
        if (Input.GetButtonDown("Cancel") && !paused)
        {
            paused = true;
            Debug.Log ("Paused");

        }
        else if (Input.GetButtonDown("Cancel") && paused)
        {
            paused = false;
            Debug.Log ("Unpaused");

       }
        //if paused, turn cursor on and show the pause menu. also stopping the time of the game
       if (paused)
       {
           Time.timeScale = 0;
           pauseMenu.SetActive(true);
           Cursor.visible = true;
       }
       if (!paused)
       {
           Time.timeScale = 1;
           pauseMenu.SetActive(false);
           Cursor.visible = false;
       }
   }
}
