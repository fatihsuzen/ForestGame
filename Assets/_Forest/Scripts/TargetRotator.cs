using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotator : MonoBehaviour
{
    float RotationAngle;
    void Start()
    {
        InvokeRepeating("Turner", 0, 0.02f);
    }
    void Turner()
    {
        RotationAngle += 2f;
        transform.rotation = Quaternion.Euler(transform.rotation.x, RotationAngle, transform.rotation.x);
    }
}
