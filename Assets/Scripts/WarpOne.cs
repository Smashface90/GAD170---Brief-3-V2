using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpOne : MonoBehaviour   
{

    public void OnTriggerEnter(Collider other)
    {
        //Swap to level 2
        Debug.Log("Col works");
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);           
            
    }

}
