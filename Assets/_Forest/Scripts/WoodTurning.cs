using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodTurning : MonoBehaviour
{
    float RotationAngle;
    void Start()
    {
        InvokeRepeating("Turner",0,0.05f);
    }
    void Turner()
    {
        RotationAngle+=1f;
        transform.rotation = Quaternion.Euler(0, RotationAngle, -37f);
    }       
}
