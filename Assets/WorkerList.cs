using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerList : MonoBehaviour
{
    public List<GameObject> TargetRing = new List<GameObject>();
    public static List<GameObject> StaticTargetRing = new List<GameObject>();

    public List<GameObject> workerPanelList = new List<GameObject>();
    public static List<GameObject> WorkerPanelList = new List<GameObject>();

    private void Start()
    {
        StaticTargetRing = TargetRing;
        CameraController.StaticTargetRing = TargetRing;

        WorkerPanelList = workerPanelList;
    }

    public static void OpenWorkerPanel(int WorkerNo)
    {
        for (int i = 0; i < WorkerPanelList.Count; i++)
        {
            WorkerPanelList[i].SetActive(false);
        }

        if (WorkerNo < WorkerPanelList.Count)
        {
            if(WorkerNo==0)
            {
                WorkerPanelList[WorkerNo].SetActive(true);
            }
            else
            {                
                WorkerPanelList[WorkerNo].SetActive(true);
            }
        }
    }
    public static void CloseAllWorkerPanel()
    {
        for (int i = 0; i < WorkerPanelList.Count; i++)
        {
            WorkerPanelList[i].SetActive(false);
        }
    }
}
