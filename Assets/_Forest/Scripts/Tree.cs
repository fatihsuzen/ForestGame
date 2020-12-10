using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tree : MonoBehaviour
{
    dg_simpleCamFollow simpleCamFollow;
    public static float cutTime = 5f;
    GameObject DropWood;
    public GameObject Player;
    public bool isCutting;
    public static bool IsCutting;//any worker is cutting
    private void Start()
    {
        simpleCamFollow = Camera.main.GetComponent<dg_simpleCamFollow>();
        DropWood = GameObject.Find("Wood");
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            Invoke("CutTree", cutTime);
            Player = other.gameObject;
            isCutting = true;
            IsCutting = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isCutting = false;
        IsCutting = false;
    }
    public void CutTree()
    {
        if(isCutting)
        {
            //simpleCamFollow.CameraShake();
            
            WorkerMoveToTree.isTarget = false;
            isCutting = false;
            IsCutting = false;
            Player.GetComponentInParent<WorkerMoveToTree>().RandomPos();            

            GameObject dropwood = Instantiate<GameObject>(DropWood, transform.position + Vector3.up, Quaternion.identity);
            dropwood.transform.DOJump(new Vector3(transform.position.x + 2, transform.position.y + 2, transform.position.z), 2, 3, 2, false).SetEase(Ease.Linear);

            Destroy(gameObject);            
        }
    }
}
