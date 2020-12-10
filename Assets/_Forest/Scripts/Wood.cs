using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Wood : MonoBehaviour
{
    GameObject CanvasWoodStock;
    public GameObject Particle;
    Player player;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        CanvasWoodStock = GameObject.Find("CanvasWoodStock");
    }
    private void OnMouseDown()
    {
        //Vector3 pos = Camera.main.WorldToScreenPoint();
        InvokeRepeating("MoveWood",0,1);
        Particle.SetActive(false);
    }
    void MoveWood()
    {
        transform.DOMove(CanvasWoodStock.transform.position, 0.3f, false);
        transform.DOScale(0, 0.3f);
        Invoke("DestroyWood", 0.3f);
    }
    void DestroyWood()
    {
        player.SetWood(1);
        transform.DOKill();
        Destroy(gameObject);
    }
    
}
