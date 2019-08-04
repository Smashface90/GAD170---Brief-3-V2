using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltControls : MonoBehaviour
{
    public Vector3 currentRot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentRot = GetComponent<Transform> ().eulerAngles;

        if ((Input.GetAxis ("Horizontal") > .2) && (currentRot.z <=20 || currentRot.z >=338))
        {
            transform.Rotate (0, 0, 1); 
        }

        if ((Input.GetAxis ("Horizontal") < -.2) && (currentRot.z >=339 || currentRot.z <=21))
        {
            transform.Rotate(0, 0, -1);
        }

        if ((Input.GetAxis("Vertical") > .2) && (currentRot.x <=20 || currentRot.x >=338))
        {
            transform.Rotate(1, 0, 0);
        }

        if ((Input.GetAxis("Vertical") < -.2) && (currentRot.x >=339 || currentRot.x <=21))
        {
            transform.Rotate(-1, 0, 0);
        }
    }
}
