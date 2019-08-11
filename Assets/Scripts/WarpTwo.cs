using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpTwo : MonoBehaviour
{
  
    public void OnTriggerEnter(Collider other)
    {
        //Swap to level 3
        Debug.Log("Col2 works");
        SceneManager.LoadScene("Level3", LoadSceneMode.Single);

    }


}