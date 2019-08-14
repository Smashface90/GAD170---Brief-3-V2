using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpEnd : MonoBehaviour
{
    public GameObject GratsUI;

    void Start()
    {
        GratsUI.SetActive(false);

    }

    //brings up congrats screen with menu and quit buttons

        //trisd to make a disble pause menu part of scipt but couldnt find a way

    public void OnTriggerEnter(Collider other)
    {
        Camera.main.GetComponent<PauseScript>().menuDisabled = true;
        Time.timeScale = 0;
        GratsUI.SetActive(true);
        Cursor.visible = true;
    }
}
