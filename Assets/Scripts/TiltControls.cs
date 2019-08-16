//Evan Waters 1017144 T1 GAD 170

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TiltControls : MonoBehaviour
{
    //showing clamp in inspector
    [Header("Clamping")]
    public float minHClamp;
    public float maxHClamp;
    public float minVClamp;
    public float maxVClamp;
    //showing max angles in inspector
    [Header("Angles")]
    public float vAngle;
    public float hAngle;
    public Transform pivot;
    [Space]
    //control settings in inspector
    [Header("Control & Sensitivity")]
    public bool keyboardOn;
    public int kbInt;
    public Slider mySlider;
    public float sens;

    void Start()
    {
        //PlayPref. Saves settings in between scenes. can determine what controls are used and the sensitivity
       sens  = PlayerPrefs.GetFloat("sens");
       kbInt = PlayerPrefs.GetInt("kbInt");

        if(kbInt == 1)
        {
            keyboardOn = false;
        }
        else
        {
            keyboardOn = true;
        }
       
    }

    void Update()
    {
        //all is needed per frame
        PlayerInput();
    }

    //sensitivity settings
    public void SetSensitivity(bool i)
    {
        if (i)//mouse on
        {
                   
            PlayerPrefs.SetInt("kbInt", 1);
            kbInt = 1;
            keyboardOn = false;
        }
        else//keyboard on
        {
                     
            PlayerPrefs.SetInt("kbInt", 0);
            kbInt = 0;
            keyboardOn = true;
        }
        if (kbInt == 1)
        {
            mySlider.minValue = 0;
            mySlider.maxValue = 30;
            PlayerPrefs.SetFloat("sens", mySlider.value);
        }
        else
        {
            mySlider.minValue = 0;
            mySlider.maxValue = 20;
            PlayerPrefs.SetFloat("sens", mySlider.value);
        }
    }

    public void SensitivityControl(float input)
    {
        //input from slider
        sens = input;
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

        //what keeps it XY tilting
        transform.rotation = Quaternion.Euler(vAngle, 0, hAngle);

    }
}