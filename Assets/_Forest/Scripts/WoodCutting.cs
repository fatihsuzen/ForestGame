using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WoodCutting : MonoBehaviour
{
    public GameObject WoodParticleSystem;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Tree")
        {
            WoodParticleSystem.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        WoodParticleSystem.SetActive(false);
    }
    void Cutting()
    {
        //animator.SetInteger("Status", 0);
    }

}
