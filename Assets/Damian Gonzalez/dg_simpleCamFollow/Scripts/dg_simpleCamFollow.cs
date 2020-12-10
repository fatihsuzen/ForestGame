//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class dg_simpleCamFollow : MonoBehaviour
{
    Camera camera;
    public Transform target;
    public static Transform Target;
    [Range(1f,40f)] public float laziness = 10f;
    public bool lookAtTarget = true;
    public bool takeOffsetFromInitialPos = true;
    public Vector3 generalOffset;
    Vector3 whereCameraShouldBe;
    bool warningAlreadyShown = false;

    private void Start() {
        Target = target;
        camera = Camera.main;
        if (takeOffsetFromInitialPos && Target != null) generalOffset = transform.position - Target.position;
    }

    void FixedUpdate()
    {
        if (Target != null) {
            whereCameraShouldBe = Target.position + generalOffset;
            transform.position = Vector3.Lerp(transform.position, whereCameraShouldBe, 1 / laziness);

            if (lookAtTarget) transform.LookAt(Target);
        }
        else 
        {
            if (!warningAlreadyShown) {
                Debug.Log("Warning: You should specify a target in the simpleCamFollow script.", gameObject);
                warningAlreadyShown = true;
            }
        }
    }
    public void ChangeCameraTarget(Transform Target)
    {
        target = Target;
    }
    public void CameraShake()
    {
        camera.DOShakePosition(1f, 1f);
    }
}
