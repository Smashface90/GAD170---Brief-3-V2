using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltControls : MonoBehaviour
{
    public Transform pivot;
    [Header("Clamping")]
    public float minHClamp;
    public float maxHClamp;
    public float minVClamp;
    public float maxVClamp;
    [Header("Angles")]
    public float vAngle;
    public float hAngle;
    [Space]
    public float sens;
    [Header("Control")]
    public bool keyboardOn;
    [Header("Pause Menu")]
    public GameObject pauseMenu;
    public bool paused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        paused = false;

        if (keyboardOn)
        {
            sens = 50f;
        }
        else
        {
            sens = 20f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();

        PauseFunction();
    }

    void PlayerInput()
    {
        if (keyboardOn)
        {
            vAngle += Input.GetAxis("Vertical") * Time.deltaTime * sens;
            hAngle += Input.GetAxis("Horizontal") * Time.deltaTime * sens;
        }
        else
        {
            vAngle += Input.GetAxis("Mouse Y") * Time.deltaTime * sens;
            hAngle += Input.GetAxis("Mouse X") * Time.deltaTime * sens;
        }

        vAngle = Mathf.Clamp(vAngle, minVClamp, maxVClamp);
        hAngle = Mathf.Clamp(hAngle, minHClamp, maxHClamp);

        transform.rotation = Quaternion.Euler(vAngle, 0, hAngle);

    }

    void PauseFunction()
    {
        if (Input.GetButtonDown("Cancel") && !paused)
        {
            paused = true;
           
        }
        else if (Input.GetButtonDown("Cancel") && paused)
        {
            paused = false;
            
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
