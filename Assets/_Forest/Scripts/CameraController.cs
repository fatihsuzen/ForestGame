using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public Slider ZoomSlider;
    protected Joystick joystick;
    GameObject Joystick;
    public static List<GameObject> StaticTargetRing = new List<GameObject>();
    int counter;
    Transform Cam1;
    void Start()
    {
        Joystick = GameObject.Find("Joystick");
        joystick = FindObjectOfType<Joystick>();
    }
    private void FixedUpdate()
    {
        var rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = new Vector3(joystick.Horizontal * 20f,
            0, joystick.Vertical * 20f);
    }
    public void NextWorkerCamera()
    {        
       
        if(counter>=0)
        {
            WorkerList.OpenWorkerPanel(counter);
            StaticTargetRing[counter].SetActive(true);
            for (int i = 0; i < StaticTargetRing.Count; i++)
            {
                if (counter != i)
                    StaticTargetRing[i].SetActive(false);
                else
                    StaticTargetRing[i].SetActive(true);

            }
            dg_simpleCamFollow.Target = GameObject.Find("Worker" + counter).transform;
            Joystick.SetActive(false);
        }
        else
        {
            WorkerList.CloseAllWorkerPanel();
            StaticTargetRing[4].SetActive(false);
            Joystick.SetActive(true);
            dg_simpleCamFollow.Target = null;
            Camera.main.transform.position = this.transform.position;
            Camera.main.transform.rotation = this.transform.rotation;

        }

        counter++;                
        if (counter > StaticTargetRing.Count-1)
        {
            counter = -1;
        }
    }
    public void SelectWorker(int WorkerNumber)
    {
        WorkerList.OpenWorkerPanel(WorkerNumber);
        Joystick.SetActive(false);
        for (int i = 0; i < StaticTargetRing.Count; i++)
        {
            StaticTargetRing[i].SetActive(false);
        }
        dg_simpleCamFollow.Target = GameObject.Find("Worker" + WorkerNumber).transform;
        StaticTargetRing[WorkerNumber].SetActive(true);
    }
    public void CameraZoom()
    {
        transform.position = new Vector3(transform.position.x,
            ZoomSlider.value*80+5, transform.position.z); 
    }
}
