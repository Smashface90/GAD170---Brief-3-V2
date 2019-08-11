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

    //Default sens settings 
    void Start()
    {
        if (keyboardOn)
        {
            sens = 50f;
        }
        else
        {
            sens = 20f;
        }
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
        
        //What limits the tilt. Clamps to -20f, 20f or whatever you want to set it in the inspector
        vAngle = Mathf.Clamp(vAngle, minVClamp, maxVClamp);
        hAngle = Mathf.Clamp(hAngle, minHClamp, maxHClamp);

        transform.rotation = Quaternion.Euler(vAngle, 0, hAngle);

    }     
}