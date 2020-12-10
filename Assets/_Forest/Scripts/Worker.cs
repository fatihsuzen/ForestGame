using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Worker : MonoBehaviour
{
    public int TargetRingNum;
    int counter;
    GameObject Joystick;
    GameObject MauseTarget;
    public GameObject WorkerPanel;
    public Toggle AutomaticMove;
    public Toggle AutomaticTreeCut;
    void Start()
    {
        Joystick = GameObject.Find("Joystick");
        MauseTarget = GameObject.Find("MauseTarget");
        
    }
    private void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0) && WorkerList.StaticTargetRing[TargetRingNum].activeSelf && AutomaticMove.isOn == false)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out hit,Mathf.Infinity))
            {
                MauseTarget.transform.position = new Vector3(hit.point.x, 0, hit.point.z);
                GetComponent<WorkerMoveToTree>().target = new Vector3(hit.point.x,0, hit.point.z);
                GetComponent<Animator>().SetInteger("Status", 0);
                MauseTarget.SetActive(true);                
            }
        }
    }
    private void OnMouseDown()
    {
        WorkerList.OpenWorkerPanel(TargetRingNum);
        for (int i = 0; i < WorkerList.StaticTargetRing.Count; i++)
        {
            if (TargetRingNum==i)
            {
                WorkerList.StaticTargetRing[i].SetActive(true);
                dg_simpleCamFollow.Target = GameObject.Find("Worker" + i).transform;
            }
            else
            {
                WorkerList.StaticTargetRing[i].SetActive(false);
            }
        }
        if(TargetRingNum==5)//free cam
        {
            WorkerList.StaticTargetRing[WorkerList.StaticTargetRing.Count].SetActive(false);
            MauseTarget.SetActive(false);
        }
        Joystick.SetActive(false);
    }
}
