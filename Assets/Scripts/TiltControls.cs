using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TiltControls : MonoBehaviour
{
    
    [Header("Clamping")]
    public float minHClamp;
    public float maxHClamp;
    public float minVClamp;
    public float maxVClamp;
    [Header("Angles")]
    public float vAngle;
    public float hAngle;
    public Transform pivot;
    [Space]
    [Header("Control & Sensitivity")]
    public bool keyboardOn;
    public int kbInt;
    public Slider mySlider;
    public float sens;

    void Start()
    {
        PlayerPrefs.GetFloat("sens");
        PlayerPrefs.GetInt("kbInt");
       
    }

    void Update()
    {
        PlayerInput();
    }

    //What moves the board
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
        
        //What limits the tilt
        vAngle = Mathf.Clamp(vAngle, minVClamp, maxVClamp);
        hAngle = Mathf.Clamp(hAngle, minHClamp, maxHClamp);

        transform.rotation = Quaternion.Euler(vAngle, 0, hAngle);

    }

    public void SetSensitivity(bool i)
    {
        if (i)//mouse on
        {
            mySlider.minValue = 0;
            mySlider.maxValue = 30;
            kbInt = 1; 
        }
        else//keyboard on
        {
            mySlider.minValue = 0;
            mySlider.maxValue = 20;
            kbInt = 0;
        }
        if (kbInt = 1)
        {

        }
    }

    public void SensitivityControl(float input)
    {
        //input from slider
        sens = input;
    }

}