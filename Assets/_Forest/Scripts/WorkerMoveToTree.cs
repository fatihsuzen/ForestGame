using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class WorkerMoveToTree : MonoBehaviour
{
    public Vector3 target;
    public GameObject targetObject;
    public GameObject MauseTarget;
    bool Allow;
    
    public static bool isTarget = true;

    private void Start()
    {
        MauseTarget = GameObject.Find("MauseTarget");
    }
    private void FixedUpdate()
    {
        float step = 5 * Time.deltaTime;
        if (isTarget)
        {            
            transform.position = Vector3.MoveTowards(transform.position, target * 0.99f, step);
            Allow = true;
        }
        else
        {   
            if(GetComponent<Worker>().AutomaticMove.isOn)
            {
                RandomPos();
            }
            transform.position = Vector3.MoveTowards(transform.position, target, step);            
        }
        transform.LookAt(target);

        if (GetComponent<Worker>().AutomaticTreeCut.isOn)
        {
            if (transform.position == target * 0.99f && targetObject.tag == "Tree")
            {
                GetComponent<Animator>().SetInteger("Status", 1);//cutter anim            
            }
            else
            {
                GetComponent<Animator>().SetInteger("Status", 0);//walk anim            
            }
        }
        else
        {
            if (MauseTarget.activeSelf)
            {
                GetComponent<Animator>().SetInteger("Status", 0);
            }
            else
            {
                GetComponent<Animator>().SetInteger("Status", -1);
            }
           
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Tree")
        {
            
            if (GetComponent<Worker>().AutomaticTreeCut.isOn)
            {
                isTarget = true;
                target = other.gameObject.transform.position;
                targetObject = other.gameObject;
            }
            
        }
        if (other.tag == "targer")
        {
            GetComponent<Animator>().SetInteger("Status", -1);//stop anim
            other.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "targer")
        {
            //GetComponent<Animator>().SetInteger("Status", 0);//stop anim
        }
    }
    public void RandomPos()
    {
        if (GetComponent<Worker>().AutomaticMove.isOn)
        {
            if (Allow)
            {
                target = new Vector3(Random.Range(-250, 250), 0, Random.Range(-250, 250));
                Allow = false;
            }
        }        
    }
}
