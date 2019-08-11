using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    //Reset Button
    public void RestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //To MainMenu
    public void MenuButtonClick()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    //Main to 1
    public void Lv1ButtonClick()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    //Exit
    public void QuitGameFn()
    {
        Application.Quit();

        Debug.Log("GameDED");
        //button test
    }
}
