using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    public float angularSpeed;
    public float targetAngle;
    //public GameObject square;

    // Start is called before the first frame update
    void Start()
    {
        //angularSpeed = 30;
        //targetAngle = 130;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + transform.up, Color.blue);
        
        float currentrotation = transform.rotation.eulerAngles.z + 90;
        currentrotation = StandardizedAngle(currentrotation);
        //Debug.Log(currentrotation);
        if (targetAngle - currentrotation < 0)
        {
            if (currentrotation > targetAngle)
            {
                transform.Rotate(0, 0, -angularSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (currentrotation < targetAngle)
            {
                transform.Rotate(0, 0, angularSpeed * Time.deltaTime);
            }
        }

        
    }


    public float StandardizedAngle(float inAngle)
    {
        inAngle %= 360;

        if (inAngle > 180)
        {
            inAngle -= 360;
        }

        return inAngle;


    }





}
