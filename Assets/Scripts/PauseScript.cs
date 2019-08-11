using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [Header("Pause Menu")]
    public GameObject pauseMenu;
    public bool paused;

    // Start is called before the first frame update
    void Start()
    {
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
